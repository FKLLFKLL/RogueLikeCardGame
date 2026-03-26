# Ash Road (Unity Prototype Scaffold)

Ash Road is a story-first, single-player roguelike deckbuilder prototype scaffold.

## Setup
1. Open this folder in Unity 2022.3+ (2D template recommended).
2. Let Unity generate project files and package cache.
3. Open `Assets/Scenes/Boot.unity` as the startup scene.

## Architecture Summary
- **ScriptableObjects** hold static content (`CardData`, `EventData`, `EnemyData`, etc.).
- **Runtime managers** hold mutable run/session state (`RunManager`, `CombatManager`, `StoryProgressManager`).
- **SceneFlowController** orchestrates scene transitions.
- **Personality / Clue systems** are persistent meta-progression pillars.

## Core Loop
Main Menu -> Map Node -> (Event/Combat/Camp/etc.) -> Rewards/Progress -> Next Node -> Boss/Failure -> Meta Hub -> New Run.

## Prototype Rules Included
- 3 AP at turn start
- 5-card starting hand
- Food consumed when traversing map nodes
- Branching map node progression
- Event choice requirement checks (resources, clues, personality)
- Combat goals: DefeatAll / SurviveTurns / Escape
- Soft-failure returns to MetaHub with persistent clue/story progress retained

## Next Steps
- Wire ScriptableObject assets in Unity Inspector
- Build dedicated UI prefabs for Map/Event/Combat screens
- Expand event and encounter content libraries
- Add save-slot support and content validation tooling
