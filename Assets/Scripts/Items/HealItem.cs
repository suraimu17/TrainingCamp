using System;
using TanidaPlayers;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Tags;

namespace Items
{
    public class HealItem : MonoBehaviour, IItem
    {
        [SerializeField] private int healValue;

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
            player.Heal(healValue);
        }
    }
}