using System;
using Tags;
using Unity.VisualScripting;
using UnityEngine;

namespace TanidaPlayers
{
    public class TanidaPlayer : MonoBehaviour, IPlayer
    {
        private int hp = 3;
        private const int MaxHp = 5;
        private const int MinHp = 0;
        private int possibleDoubleJumpCount = 0; //ダブルジャンプ可能な回数
        private void Update()
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.position =
                    new Vector3(transform.position.x - 0.05f, transform.position.y, transform.position.z);
            }
            
            if (Input.GetKey(KeyCode.D))
            {
                transform.position =
                    new Vector3(transform.position.x + 0.05f, transform.position.y, transform.position.z);
            }
        }

        public void Jump()
        {
            
        }

        public void Heal(int value)
        {
            var tmp  = hp + value;
            hp = Math.Min(tmp, MaxHp);
            // Debug.Log($"Current HP:{hp}");
        }

        public void Damage(int value)
        {
            var tmp = hp - value;
            hp = Math.Max(tmp, MinHp);
            Debug.Log($"Current HP:{hp}");
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
}