using System;
using Tags;
using TanidaPlayers;
using UnityEngine;

public class PlayerController : MonoBehaviour,IPlayer
{
    public Rigidbody2D rigidbody;
    private bool isJump = false;
    public PlayerMove playermove;
    private int hp = 3;
    private const int MaxHp = 5;
    private const int MinHp = 0;
    private int possibleDoubleJumpCount = 0; //ダブルジャンプ可能な回数

    
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
        }
        playermove.Move(rigidbody);
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            isJump = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            isJump = false;
        }
    }

    public void Jump()
    {
        rigidbody.AddForce(new Vector2(0, 1000));
        Debug.Log("jump");

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
    }
    
    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.CompareTag(GameTags.Enemy.ToString()))
        {
            Damage(1);
        }
    }

}
