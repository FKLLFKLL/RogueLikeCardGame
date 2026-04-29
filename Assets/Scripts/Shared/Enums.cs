namespace AshRoad.Shared
{
    public enum CardType { Attack, Skill, Trick, Tool, Consumable }
    public enum CardTag { Damage, Block, Draw, Utility, Negotiation, Escape }
    public enum CardRarity { Common, Uncommon, Rare }
    public enum NodeType { Combat, Event, Scavenge, Merchant, Camp, Story, Elite, Boss }
    public enum EncounterType { Standard, Elite, Boss }
    public enum ResourceType { Food, Scrap, Ammo, Bandage }
    public enum PersonalityType { Nerve, Heart, Wits }
    public enum CombatGoalType { DefeatAll, SurviveTurns, Escape, Negotiate, Protect, Steal }
    public enum StatusEffectType { None, Weak, Guard, Vulnerable }
    public enum StoryFlagType { ClueFound, SceneUnlocked, TrueEndingEligible }
}
