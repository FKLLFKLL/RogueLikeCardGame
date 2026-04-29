using RogueLikeCardGame.Data;
using RogueLikeCardGame.Shared;

namespace RogueLikeCardGame.Runtime
{
    public class EnemyRuntime
    {
        public EnemyData Data { get; }
        public int Health { get; private set; }
        public int Emotion { get; private set; }
        public int Awareness { get; private set; }
        public EnemyCombatState CombatState { get; private set; }

        public EnemyRuntime(EnemyData data)
        {
            Data = data;
            Health = data.maxHealth;
            Emotion = data.startingEmotion;
            Awareness = data.startingAwareness;
            CombatState = data.startingCombatState;
        }

        public void ModifyGauge(EnemyGaugeType gaugeType, int amount)
        {
            switch (gaugeType)
            {
                case EnemyGaugeType.Health:
                    Health = ClampMin(Health + amount);
                    break;
                case EnemyGaugeType.Emotion:
                    Emotion = ClampMin(Emotion + amount);
                    break;
                case EnemyGaugeType.Awareness:
                    Awareness = ClampMin(Awareness + amount);
                    break;
            }
        }

        public void SetAggressive()
        {
            CombatState = EnemyCombatState.Aggressive;
        }

        private static int ClampMin(int value) => value < 0 ? 0 : value;
    }
}
