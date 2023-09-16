using System;
using Tags;
using TanidaPlayers;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Items
{
    public class DoubleJumpItem : MonoBehaviour,IItem
    {
        [SerializeField] private int doubleJumpCount;   //アイテムを取得した際、ダブルジャンプの回数を増やす値
        
        private void Start()
        {
            this.OnTriggerEnter2DAsObservable()
                .Where(x => x.gameObject.CompareTag(GameTags.Player.ToString()))
                .Subscribe(x =>
                {
                    InfluenceThePlayer(x.gameObject.GetComponent<IPlayer>());
                    Destroy(gameObject);
                });
        }

        public void InfluenceThePlayer(IPlayer player)
        {
            player.IncreasePossibleDoubleJumpCount(doubleJumpCount);
        }
    }
}