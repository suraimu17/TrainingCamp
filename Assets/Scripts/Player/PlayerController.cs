using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    private bool isJump = false;
    public PlayerMove playermove;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        playermove = GetComponent<PlayerMove>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isJump)
        {
            rb.AddForce(new Vector2(0, 1000));
            Debug.Log("jump");
        }
        playermove.Move(rb);
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
}
