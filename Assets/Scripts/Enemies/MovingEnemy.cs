using System;
using UnityEngine;

namespace Enemies
{
    public class MovingEnemy : MonoBehaviour
    {
        [SerializeField] private float AmountOfMovementInXDirection;    //x軸方向の移動量
        [SerializeField] private float AmountOfMovementInYDirection;    //y軸方向の移動量
        [SerializeField] private float xSpeed;
        [SerializeField] private float ySpeed;

        private Vector2 currentEnemyPos;
        private void Start()
        {
            currentEnemyPos = transform.localPosition;
        }
        private void Update()
        {
            float xValue = 0;
            float yValue = 0;
            if (AmountOfMovementInXDirection != 0)
            {
                xValue = Mathf.PingPong(Time.time * xSpeed, AmountOfMovementInXDirection);
            }

            if (AmountOfMovementInYDirection != 0)
            {
                yValue = Mathf.PingPong(Time.time * ySpeed, AmountOfMovementInYDirection);
            }
            currentEnemyPos = transform.localPosition;
            currentEnemyPos = transform.localPosition;
            transform.localPosition = new Vector3(currentEnemyPos.x+xValue, currentEnemyPos.y+yValue, 0);
            
        }
    }
}