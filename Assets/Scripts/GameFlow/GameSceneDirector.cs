using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;

namespace GameFlow
{
    public class GameSceneDirector : MonoBehaviour
    {
        [SerializeField] private float MoveToGoalAnimationSpeed = 0.01f;   //ゴールに近づくときの移動スピード
        
        [SerializeField] private GoalController goalController;
        [SerializeField] private GameObject clearTab;
        private PlayerController playerController;
        private Transform playerTransform;
        public bool IsGoal { get; private set; } = false;

        private void Start()
        {
            playerController = FindObjectOfType<PlayerController>();
            playerTransform = playerController.transform;
            clearTab.SetActive(false);
            
            goalController.OnTriggerEnterObservable
                .Take(1)
                .Subscribe(_ =>
                {
                    Debug.Log("goal");
                    IsGoal = true;
                    ClearActionAsync().Forget();
                }).AddTo(this);
        }
        
        private async UniTask ClearActionAsync()
        {
            clearTab.SetActive(true);
            var token = playerTransform.gameObject.GetCancellationTokenOnDestroy();
            await GoalAnimationAsync(token);
        }

        private async UniTask GoalAnimationAsync(CancellationToken token)
        {
            Debug.Log("Goal");
            await UniTask.WaitUntil(() =>
            {
                var direction = transform.position - playerTransform.position;
                playerTransform.position += direction.normalized * MoveToGoalAnimationSpeed;
                return Vector3.Distance(playerTransform.position, transform.position) < 0.05f;
            },cancellationToken : token);
        }
    }
}