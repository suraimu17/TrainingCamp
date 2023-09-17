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

        private Vector3 beforeFramePosition;
        private Vector2 currentEnemyPos;

        private Animator enemyAnimator;


        private void Start()
        {
            beforeFramePosition = transform.localPosition;
            currentEnemyPos = transform.localPosition;
            enemyAnimator = GetComponent<Animator>();
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
            
            if (transform.localPosition.x - beforeFramePosition.x >= 0)
            {
                transform.localScale =
                    new Vector3(Math.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else
            {
                transform.localScale =
                    new Vector3(Math.Abs(transform.localScale.x)*-1, transform.localScale.y, transform.localScale.z);
            }
            
            beforeFramePosition = transform.localPosition;
            transform.localPosition = new Vector3(currentEnemyPos.x+xValue, currentEnemyPos.y+yValue, 0);
            
        }
    }
}