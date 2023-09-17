using System;
using UniRx;
using UnityEngine;

namespace GameFlow
{
    public class GoalController : MonoBehaviour
    {
        private Subject<Unit> onTrigerEnterSubject = new Subject<Unit>();
        public IObservable<Unit> OnTriggerEnterObservable => onTrigerEnterSubject;
        public Vector3 GoalPosition => transform.position;
        
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