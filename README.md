# RatStabber

![TeoSword_clear](https://github.com/user-attachments/assets/5cc699a3-c4a2-47c5-9d7f-10f8546ad48f)

### Fight off the ratbots and save the rat cities as the hunky man Teo himself!


## LORE:
After successfully defeating the Paulbots, the rat took components of the Paulbots and improved the design to create the rat bots. He could finally get revenge on Paul for the destruction of his kind. However, the Paul Bots managed to regain consciousness inside of the new and improved Rat Bots, making the Ratbots turn against the rat, taking his weapons and his last hopes of defeating Paul. You (Teo) have arrived to protect the rat and help him figure out a way to stop the now evil rat bots and discover the dark, hidden secrets while ending this war once and for all.





























## And that's the game... I guess...

### Alright, Here's the Basic Vision:

- The Player (Teo) moves around an infinite field with the camera following the player
- Enemies are rat bots
    - All deal damage upon contact
    - Some can throw guns (movement slower)
    - Some can fire the guns (they are even slower)
    - Fast fuckers (less damage)
    - Minecraft creeper rats (explode)
      
- You are defending the real rat
    - The rat is the one that canonically gives you a power-up at the end of each wave.
- You attack with a sword
    - Damage scales with speed
      
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
- [x] Sword that points to mouse cursor
- [ ] Sword swings when click
- [x] Sword damages enemies in swing area
- [x] Wave spawns enemies
- [x] Detect when wave ends
- [x] Activate new waves after powerup has been chosen by player
- [ ] Dash ability

### Enemy:
- [x] All Enemies have simple pathfinding towards the player
- [x] When enemy touches player - remove health (scaled with x amount of rounds)
- [ ] When object summoned / thrown by enemy, remove health (smaller scaling)

### Types of Enemies:
- [x] Default Ratbot
- [ ] Fast Ratbot
    - [ ] These things are your nightmare
    - [ ] Deal minimal damage but chip health FAST 
- [ ] Shooting/Throwing Ratbot
    - [ ] Slower than your average rat
    - [ ] Throwables deal less damage 
- [ ] Big Tanky Ratbot
    - [ ] 3-5x amount of health of a normal rat? 
- [ ]  Secret Paulbot :)

### In-Game UI:
- [x] Player health on bottom left
- [ ] Round / Wave on bottom left (?)
- [ ] Maybe show enemy remaining count? (We can make a hard mode that removes UI except health)
- [ ] Upon round end, pop-up menu for selecting powerup
    - [x] Damage
    - [ ] Attack distance
    - [ ] Attack range
    - [ ] Attack cooldown
    - [x] Health
    - [x] Speed
    - [ ] Dash cooldown
    - [ ] Dash distance
     
- [ ] (Only an idea for now) Have a status bar at the bottom right to show your current stats 


### UI / AUDIO:
- [x] Menu Screen
- [ ] Pause Screen
    - [ ] Option for returning to main menu / resume
- [x] Menu Music
- [x] Level Music
- [x] A section where the player can view unlocked lore by completing more of the game
    - [ ] LORE GETS UNLOCKED EVERY 10 ROUNDS BEATEN + BOSS BEATEN






## A sick idea:
### After every ten rounds, there will be an OPTIONAL portal that brings the player to a challenging stage (could just trigger a toggle that allows for the hard stage to make things easier since it's an infinite field), where the enemies are very difficult (could be like 20 rounds harder variants) and upon completion, the player gets a super-power or something very rewarding (and more lore unlocks)



## Sorry Teo
I do no think we are going to be able to add your hot sexy bots...
