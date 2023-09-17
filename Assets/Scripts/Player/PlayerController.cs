using System;
using Tags;
using TanidaPlayers;
using UnityEngine;

public class PlayerController : MonoBehaviour,IPlayer
{
    public Rigidbody2D rigidbody;
    private bool isJump = false;
    public PlayerMove playermove;
    public int hp = 3;
    private const int MaxHp = 5;
    private const int MinHp = 0;
    private Animator playerAnimator;
    private bool isJumping;
    private bool isFalling;
    private bool isWalking;
    private bool isIdle;

    private Vector3 beforeFramePosition;
    public int possibleDoubleJumpCount = 0; //ダブルジャンプ可能な回数
    private bool BeforeJump = false;
    
    private void Awake()
    {
        Application.targetFrameRate = 60;
        playermove = GetComponent<PlayerMove>();
        rigidbody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    private void Start()
    {
        beforeFramePosition = transform.position;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isJump)
        {
            Jump();
            Debug.Log("jump");
        }
        if (Input.GetKeyDown(KeyCode.Space) && possibleDoubleJumpCount > 0 && !BeforeJump && !isJump)
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, 0);
            Jump();
            Debug.Log("count");
            possibleDoubleJumpCount--;
            BeforeJump = true;
        }

        //isFalling = SetIsFalling();
        playermove.Move(rigidbody);
        MoveAnimation();
    }
    public void MoveAnimation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.localScale =
                new Vector3(Mathf.Abs(transform.localScale.x) * -1, transform.localScale.y, transform.localScale.z);
            Debug.Log($"Push A");
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.localScale =
                new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            Debug.Log($"Push D");
        }

        
        isWalking = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D);
        isIdle = !isWalking && !isJumping && !isFalling;
        
        playerAnimator.SetBool(PlayerAnimatorFrag.IsJumping.ToString(),isJumping);
        playerAnimator.SetBool(PlayerAnimatorFrag.IsWalking.ToString(),isWalking);
        playerAnimator.SetBool(PlayerAnimatorFrag.IsFalling.ToString(),isFalling);
        playerAnimator.SetBool(PlayerAnimatorFrag.IsIdle.ToString(),isIdle);
    }

    private bool SetIsFalling()
    {
        if (!isJumping)
        {
            beforeFramePosition = transform.position;
            return false;
        }

        if (transform.position.y <= beforeFramePosition.y)
        {
            beforeFramePosition = transform.position;
            return true;
        }

        beforeFramePosition = transform.position;
        return false;
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            isJump = true;
            isJumping = false;
            BeforeJump = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            isJump = false;
            isJumping = true;
        }
    }

    public void Jump()
    {
        rigidbody.AddForce(new Vector2(0, 1000));
    }
    
    public void Heal(int value = 1)
    {
        var tmp  = hp + value;
        hp = Math.Min(tmp, MaxHp);
    }

    public void Damage(int value)
    {
        var tmp = hp - value;
        hp = Math.Max(tmp, MinHp);
    }

    public void IncreasePossibleDoubleJumpCount(int value = 1)
    {
        possibleDoubleJumpCount += value;
        Debug.Log("item");
    }
    
    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.CompareTag(GameTags.Enemy.ToString()))
        {
            Damage(1);
        }
    }
}

public enum PlayerAnimatorFrag
{
    IsJumping,
    IsWalking,
    IsFalling,
    IsIdle,
}

