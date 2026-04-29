using System.Collections.Generic;
using UnityEngine;
using RogueLikeCardGame.Data;

namespace RogueLikeCardGame.Runtime
{
    public class RunState : MonoBehaviour
    {
        public static RunState Instance { get; private set; }

        [SerializeField] private int startingHp = 50;
        [SerializeField] private int startingFood = 3;
        [SerializeField] private List<CardData> startingDeck = new();

        public int PlayerHp { get; private set; }
        public int MaxPlayerHp { get; private set; }
        public int Food { get; private set; }
        public int Clues { get; private set; }
        public bool InFinalBossCombat { get; set; }
        public EnemyData PendingEnemy { get; private set; }
        public readonly List<CardData> Deck = new();

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);

            if (Deck.Count == 0)
            {
                MaxPlayerHp = startingHp;
                PlayerHp = startingHp;
                Food = startingFood;
                Deck.AddRange(startingDeck);
            }
        }

        public void QueueCombat(EnemyData enemyData, bool isFinalBoss)
        {
            PendingEnemy = enemyData;
            InFinalBossCombat = isFinalBoss;
        }

        public void ModifyHp(int amount)
        {
            PlayerHp = Mathf.Clamp(PlayerHp + amount, 0, MaxPlayerHp);
        }

        public void GainFood(int amount) => Food += Mathf.Max(0, amount);
        public void GainClue(int amount) => Clues += Mathf.Max(0, amount);
        public void AddCard(CardData card) { if (card != null) Deck.Add(card); }

        public void ClearPendingEnemy() => PendingEnemy = null;
    }
}
