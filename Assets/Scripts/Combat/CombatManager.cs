using System.Collections.Generic;
using UnityEngine;
using AshRoad.Data;
using AshRoad.Shared;

namespace AshRoad.Combat
{
    public class CombatManager : MonoBehaviour
    {
        public DeckManager Deck { get; } = new();
        public HandManager Hand { get; } = new();
        public int CurrentAP { get; private set; }
        public int TurnNumber { get; private set; }
        public CombatGoalType GoalType { get; private set; }
        public int SurviveTargetTurns { get; private set; }
        public bool EscapeTriggered { get; private set; }
        public List<EnemyRuntime> Enemies = new();

        public void StartEncounter(EncounterData encounter, List<CardData> deck)
        {
            GoalType = encounter.goalType;
            SurviveTargetTurns = encounter.surviveTurnTarget;
            Deck.Initialize(deck);
            Hand.Hand.Clear();
            Enemies.Clear();
            foreach (var e in encounter.enemies) Enemies.Add(new EnemyRuntime(e));
            TurnNumber = 0;
            BeginTurn();
        }

        public void BeginTurn()
        {
            TurnNumber++;
            CurrentAP = 3;
            Hand.DrawToFull(Deck);
            foreach (var enemy in Enemies) enemy.Act(TurnNumber);
        }

        public bool TryPlayCard(CardData card)
        {
            if (!Hand.Hand.Contains(card) || card.apCost > CurrentAP) return false;
            CurrentAP -= card.apCost;
            Hand.Hand.Remove(card);
            if (card.exhaust) Deck.Exhaust(card); else Deck.Discard(card);
            if (card.tags.Contains(CardTag.Escape)) EscapeTriggered = true;
            return true;
        }

        public bool IsVictory()
        {
            return GoalType switch
            {
                CombatGoalType.DefeatAll => Enemies.TrueForAll(e => e.CurrentHp <= 0),
                CombatGoalType.SurviveTurns => TurnNumber >= SurviveTargetTurns,
                CombatGoalType.Escape => EscapeTriggered,
                _ => false
            };
        }
    }

    public class EnemyRuntime
    {
        private readonly EnemyData data;
        public int CurrentHp;
        public EnemyRuntime(EnemyData d){data=d; CurrentHp=d.maxHp;}
        public int Act(int turn) => data.alternatesBehavior && turn % 2 == 0 ? data.defendAmount : data.attackDamage;
    }
}
