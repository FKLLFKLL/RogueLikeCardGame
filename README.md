# RogueLikeCardGame Prototype Update

## Current vertical slice loop (playable)
- Move in `MapScene` with 2D free movement.
- Interact with buildings (touch or press `E` nearby):
  - Event: gain random card.
  - Food/scavenge: gain food.
  - Camp: restore HP.
  - Merchant: placeholder card reward.
  - Story: gain clue placeholder.
- Touch roaming enemies to enter combat.
- Combat uses current run deck and tracks player HP + enemy HP/Aggression + statuses.
- Win normal combat to return to map with persistent HP/food/clues/deck.
- Reach map boundary to trigger friend final boss combat.
- Win final boss to show placeholder ending based on Nerve/Heart/Wits deck dominance.

## Combat model (v1)
- AP per turn: **3**
- Draw per turn: **5**
- Max hand size: **10**
- Draw/discard/exhaust piles implemented.
- Statuses implemented for prototype logic:
  - **Stun**: enemy skips next action.
  - **Weak**: enemy outgoing damage reduced.
  - **Vulnerable**: enemy takes increased damage.
- Aggression affects enemy outgoing damage and enemy incoming damage multiplier.

## Notes
- Uses lightweight debug logs + placeholder text in place of full UI.
- Node-map assumptions are bypassed in this runtime path; open-map flow is now the active prototype loop.
- TODO hooks are left in code for UI, narrative reveal, balance, and authored content.
