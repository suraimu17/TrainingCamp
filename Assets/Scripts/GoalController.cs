using Tags;
using UnityEngine;

namespace DefaultNamespace
{
    public class GoalController : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag(GameTags.Player.ToString()))
            {
                Debug.Log("Goal!!");
            }
        }
    }
}