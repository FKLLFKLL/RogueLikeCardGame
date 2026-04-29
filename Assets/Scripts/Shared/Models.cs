using System;
using System.Collections.Generic;
using AshRoad.Shared;

namespace AshRoad.Models
{
    [Serializable] public class RequirementCheck { public ResourceType resource; public int amount; public PersonalityType personality; public int minPersonality; public string requiredClueId; }
    [Serializable] public class RewardGrant { public ResourceType resource; public int amount; public string cardId; public string clueId; }
    [Serializable] public class PersonalityState { public int Nerve; public int Heart; public int Wits; public int Get(PersonalityType t)=>t==PersonalityType.Nerve?Nerve:t==PersonalityType.Heart?Heart:Wits; public void Add(PersonalityType t,int v){if(t==PersonalityType.Nerve)Nerve+=v; else if(t==PersonalityType.Heart)Heart+=v; else Wits+=v;} }
    [Serializable] public class RunResources { public int Food=10; public int Scrap=0; public int Ammo=0; public int Bandage=0; public int Get(ResourceType t)=>t==ResourceType.Food?Food:t==ResourceType.Scrap?Scrap:t==ResourceType.Ammo?Ammo:Bandage; public bool Spend(ResourceType t,int n){if(Get(t)<n) return false; Add(t,-n); return true;} public void Add(ResourceType t,int n){if(t==ResourceType.Food)Food+=n; else if(t==ResourceType.Scrap)Scrap+=n; else if(t==ResourceType.Ammo)Ammo+=n; else Bandage+=n;} }
    [Serializable] public class StoryProgressData { public HashSet<string> clues = new(); public HashSet<string> scenes = new(); public bool trueEndingEligible; }
}
