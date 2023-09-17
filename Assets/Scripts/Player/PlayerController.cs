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
    public int possibleDoubleJumpCount = 0; //ダブルジャンプ可能な回数
    private bool BeforeJump = false;
    public bool LeftWall = false;
    public bool RightWall = false;
    private Vector2 playerpos;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        playermove = GetComponent<PlayerMove>();
        rigidbody = GetComponent<Rigidbody2D>();
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
        playermove.Move(rigidbody);
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 groundpos = collision.GetContact(0).point;
        if (collision.gameObject.layer == 7 && transform.position.y - groundpos.y - 0.65 > 0)
        {
            isJump = true;
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
