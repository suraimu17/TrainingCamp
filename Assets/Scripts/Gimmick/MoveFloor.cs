using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFloor : MonoBehaviour
{
     [SerializeField] private float AmountOfMovementInXDirection;    //xŽ²•ûŒü‚ÌˆÚ“®—Ê
     [SerializeField] private float AmountOfMovementInYDirection;    //yŽ²•ûŒü‚ÌˆÚ“®—Ê
     [SerializeField] private float xSpeed;
     [SerializeField] private float ySpeed;

    private Vector2 currentPos;
    private void Start()
    {
        currentPos = transform.localPosition;
    }
    private void Update()
    {
        float xValue = 0;
        float yValue = 0;
        if (AmountOfMovementInXDirection > 0)
        {
            xValue = Mathf.PingPong(Time.time * xSpeed, AmountOfMovementInXDirection);
        }
        else if (AmountOfMovementInXDirection < 0)
        {
            xValue = -Mathf.PingPong(Time.time * xSpeed, AmountOfMovementInXDirection);
        }

        if (AmountOfMovementInYDirection > 0)
        {
            yValue = Mathf.PingPong(Time.time * ySpeed, AmountOfMovementInYDirection);
        }
        else if (AmountOfMovementInYDirection < 0)
        {
            yValue = Mathf.PingPong(Time.time * ySpeed, AmountOfMovementInYDirection);
        }
        transform.localPosition = new Vector3(currentPos.x+xValue, currentPos.y+yValue, 0);
    }
}
