using System.Collections.Generic;
using RogueLikeCardGame.Data;
using RogueLikeCardGame.Shared;

namespace RogueLikeCardGame.Runtime
{
    public class EnemyRuntime
    {
        public EnemyData Data { get; }
        public int Health { get; private set; }
        public int Aggression { get; private set; }

        private readonly Dictionary<StatusEffectType, int> statusDurations = new();

        public EnemyRuntime(EnemyData data)
        {
            Data = data;
            Health = data.maxHp;
            Aggression = data.startingAggression;
        }

        public void ModifyHealth(int amount) => Health = ClampMin(Health + amount);
        public void ModifyAggression(int amount) => Aggression = ClampMin(Aggression + amount);

        public void ApplyStatus(StatusEffectType effect, int duration)
        {
            if (effect == StatusEffectType.None || duration <= 0) return;
            statusDurations.TryGetValue(effect, out int current);
            statusDurations[effect] = current + duration;
        }

        public bool ConsumeStatus(StatusEffectType effect)
        {
            if (!statusDurations.TryGetValue(effect, out int current) || current <= 0) return false;
            statusDurations[effect] = current - 1;
            return true;
        }

        public float GetDamageMultiplierAgainstEnemy()
        {
            float vulnerableBonus = ConsumeStatus(StatusEffectType.Vulnerable) ? 0.25f : 0f;
            return 1f + (Aggression * Data.aggressionVulnerabilityScaling) + vulnerableBonus;
        }

        public float GetOutgoingDamageMultiplier()
        {
            float aggressionFactor = 1f + (Aggression * Data.aggressionDamageScaling);
            if (ConsumeStatus(StatusEffectType.Weak)) aggressionFactor *= 0.75f;
            return aggressionFactor;
        }

        public bool ShouldSkipTurnFromStun() => ConsumeStatus(StatusEffectType.Stun);
        public bool ShouldMissTurnFromBlind() => ConsumeStatus(StatusEffectType.Blind);

        private static int ClampMin(int value) => value < 0 ? 0 : value;
    }
}
