# RogueLikeCardGame Prototype Update

## What changed

This repo now includes a lightweight Unity-friendly vertical slice for the updated 3-path combat design:

- **3 enemy gauges** (Health / Emotion / Awareness) and **enemy combat state** (Neutral / Aggressive).
- **Card personality-through-cards** metadata (Nerve / Heart / Wits) with intent + multi-gauge effects.
- **Event reward card grants** wired through card ID resolution.
- **Reunion outcome evaluator** based on collected/final card affinities.
- **Story progress fix** where true-ending clue-group evaluation is computed from all discovered groups.
- **Prototype starter content scaffolding** with the requested sample cards.

## Notes

- The implementation is intentionally prototype-level and manager-driven.
- Debug logs are used for visibility instead of polished UI.
- TODO comments mark deferred narrative/UI integration points.

## Next steps

1. Hook these scripts into existing scene objects and UI.
2. Replace prototype content scaffolding with real ScriptableObject assets.
3. Expand enemy turn AI and encounter-level victory condition configuration.
4. Implement full reunion dialogue branching using `ReunionEvaluationResult`.
