using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    public void Move(Rigidbody2D rb)
    {
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(7f, rb.velocity.y);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-7f, rb.velocity.y);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
