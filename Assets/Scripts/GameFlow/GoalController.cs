using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameFlow
{
    public class GoalController : MonoBehaviour
    {
        private Subject<Unit> onTrigerEnterSubject = new Subject<Unit>();
        public IObservable<Unit> OnTriggerEnterObservable => onTrigerEnterSubject;
        public Vector3 GoalPosition => transform.position;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                var activeSceneName = SceneManager.GetActiveScene().name;
                SceneManager.LoadScene(activeSceneName);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.TryGetComponent<PlayerController>(out _))
            {
                onTrigerEnterSubject.OnNext(new Unit());
            }
        }

        private void OnDestroy()
        {
            onTrigerEnterSubject.Dispose();
        }
    }
}