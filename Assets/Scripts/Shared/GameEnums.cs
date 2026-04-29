namespace RogueLikeCardGame.Shared
{
    public enum EnemyCombatState
    {
        Neutral = 0,
        Aggressive = 1
    }

    public enum EnemyGaugeType
    {
        Health = 0,
        Aggression = 1,
        Emotion = 2,
        Awareness = 3
    }

    public enum StatusEffectType
    {
        None = 0,
        Blind = 1,
        Weak = 2,
        Stun = 3,
        Vulnerable = 4,
        Frail = 5
    }

    public enum CardPersonalityAffinity
    {
        None = 0,
        Nerve = 1,
        Heart = 2,
        Wits = 3
    }

    public enum CardIntent
    {
        Attack = 0,
        Defend = 1,
        Negotiate = 2,
        Stealth = 3,
        Utility = 4
    }

    public enum ReunionTone
    {
        Balanced = 0,
        NerveDominant = 1,
        HeartDominant = 2,
        WitsDominant = 3
    }
}
