using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public void Move(Rigidbody2D rigidbody)
    {
        if (Input.GetKey(KeyCode.D))
        {
            rigidbody.velocity = new Vector2(7f, rigidbody.velocity.y);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rigidbody.velocity = new Vector2(-7f, rigidbody.velocity.y);
        }
    }
}
