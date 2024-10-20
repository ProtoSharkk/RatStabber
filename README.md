# RatStabber

### Alright here's the vision

- Player moves around, camera follows player
- Enemies are rat bots
    - All have melee attacks
    - Some can throw guns
    - Some can actually fire guns (they are slower)
    - Fast fuckers
    - Minecraft creeper rats (explode)
    - 
- You are defending the real rat
    - The rat is the one that canonically gives you a powerup at the end of each wave.
- You attack with a sword
    - Damage scales with speed
    - 
- Faithful to the original game, you get a new powerup every wave
    - More health
    - More base damage
    - More speed
    - Wider attack range
    - Farther attack range
    - Lower attack cooldown 



## Implementations Needed:

### Player/Game:
- [x] Player that moves
    - [x] Camera follows player
- [x] Health
- [x] Enemy takes health when touches
- [ ] Enemy health bar
- [ ] Sword that points to mouse cursor
- [ ] Sword swings when click
- [ ] Sword damages enemies in swing area
- [ ] Wave spawns enemies
- [ ] Detect when wave ends
- [ ] Activate new waves after powerup has been chosen by player

### Enemy:
- [x] All Enemies have simple pathfinding towards the player
- [ ] When enemy touches player - remove health (scaled with x amount of rounds)
- [ ] When object summoned / thrown by enemy, remove health (smaller scaling)



### In-Game UI:
- [ ] Player health on bottom left
- [ ] Round / Wave on bottom left (?)
- [ ] Maybe show enemy remaining count? (We can make a hard mode that removes UI except health)
- [ ] Upon round end, pop-up menu for selecting powerup


### UI / AUDIO:
- [ ] Menu Screen
- [ ] Pause Screen
    - [ ] Option for returning to main menu / resume
- [ ] Menu Music
- [ ] Level Music
- [ ] A section where the player can view unlocked lore by completing more of the game

      

## LORE:
After successfully defeating the Paul bots, the rat improved upon the design to create the rat bots. He could finally get revenge on Paul for the destruction of his kind. However, the Paul Bots mangaged to regain consciousness inside of the new and improved Rat Bots, in-turn making the ratbots turn against the rat, taking his weapons and his last hopes of defeating Paul as well. You (Teo) have arrived to protect the rat and help him figure out a way to stop the now evil rat bots and put and end to this war once and for all.





## A sick idea:
### After every ten rounds, there will be a portal that brings the player to a challenge stage, where the enemies are very difficult (could be like 20 rounds harder variants) and upon completion the player gets a super power or sometning very rewarding (and more lore unlocks)
