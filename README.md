# RogueLikeCardGame Prototype Update

## New Direction: Open Exploration Run

The project direction is now a **2D open exploration roguelike run** instead of a branching Slay-the-Spire-style node path.

### Core loop
- Explore a 2D map in real time.
- Enemies move around the world map.
- Buildings (houses/ruins/shops/camps/story sites) trigger events.
- Collect cards, food, clues, and resources while traveling.
- Reach the boundary of the map.
- Boundary triggers the final boss encounter (missing best friend reveal placeholder).
- Fight the boss using the cards collected during the run.

### Combat model update
- Combat now tracks **2 enemy gauges**: **HP + Aggression**.
- Awareness/escape-by-awareness logic has been removed from the runtime combat path.
- Aggression modifies both enemy outgoing damage and vulnerability to incoming damage.
- Wits-oriented cards apply status effects (initial support: Blind, Weak, Stun, Vulnerable).
- AP remains 3, hand draw target remains 5, max hand size remains 10.

### System scaffolding added
- Open map manager + player map controller.
- Enemy map walker/patrol scaffold.
- Building interaction scaffold (event/merchant/camp/story).
- Boundary trigger + final boss encounter placeholder with TODO reveal hook.
- Reunion personality outcome remains, based on deck affinity counts (Nerve/Heart/Wits).
