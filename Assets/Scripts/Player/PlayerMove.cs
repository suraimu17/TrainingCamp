using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public PlayerController playercontroller;
    public void Move(Rigidbody2D rigidbody)
    {
        if (Input.GetKey(KeyCode.D) && !playercontroller.RightWall)
        {
            rigidbody.velocity = new Vector2(7f, rigidbody.velocity.y);
        }
            
        else if (Input.GetKey(KeyCode.A) && !playercontroller.LeftWall)
        {
            rigidbody.velocity = new Vector2(-7f, rigidbody.velocity.y);

        }
        else
        {
            rigidbody.velocity = new Vector2(0, rigidbody.velocity.y);
        }
    }
}
