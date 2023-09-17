using System;
using Tags;
using TanidaPlayers;
using UnityEngine;
using System.Collections;

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
    public bool LeftWall = false;
    public bool RightWall = false;
    private Vector2 playerpos;

    private bool isDamage = false;
    public SpriteRenderer sp;

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
        sp = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(hp == 0)
        {
            gameObject.SetActive(false);
        }
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

        if (isDamage)
        {
            float level = Mathf.Abs(Mathf.Sin(Time.time * 10));
            sp.color = new Color(1f, 1f, 1f, level);
        }

    }
    public void MoveAnimation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.localScale =
                new Vector3(Mathf.Abs(transform.localScale.x) * -1, transform.localScale.y, transform.localScale.z);
            //Debug.Log($"Push A");
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.localScale =
                new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            //Debug.Log($"Push D");
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
        Vector2 groundpos = collision.GetContact(0).point;
        if (collision.gameObject.layer == 7 && transform.position.y - groundpos.y - 0.65 > 0)
        {
            isJump = true;
            isJumping = false;
            BeforeJump = false;
        }
        else if(transform.position.x > groundpos.x)
        {
            LeftWall = true;
            Debug.Log("left");
            RightWall = false;
            Debug.Log("noright");
            playerpos = transform.position;
        }
        else
        {
            RightWall = true;
            Debug.Log("right");
            LeftWall = false;
            Debug.Log("noleft");
            playerpos = transform.position;
        }
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            isJump = false;
            isJumping = true;
        }
        
        if(RightWall && transform.position.x != playerpos.x)
        {
            RightWall = false;
            Debug.Log("noright");
        }
        if (LeftWall && transform.position.x != playerpos.x)
        {
            LeftWall = false;
            Debug.Log("noleft");
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
        isDamage = true;
    }

    public IEnumerator OnDamage()
    {
        yield return new WaitForSeconds(2);
        isDamage = false;
        sp.color = new Color(1f, 1f, 1f, 1f);
    }

    public void IncreasePossibleDoubleJumpCount(int value = 1)
    {
        possibleDoubleJumpCount += value;
        Debug.Log("item");
    }
    
    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (isDamage)
        {
            return;
        }
        if (collider2D.gameObject.CompareTag(GameTags.Enemy.ToString()))
        {
            Damage(1);
            Debug.Log("damage");
            StartCoroutine(OnDamage());
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

