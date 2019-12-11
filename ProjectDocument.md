# Untitled Platformer Game #

# Team Members #

1. Sahil Faruque
2. Justin Lim
3. Varun Peesapati
4. Ian Scott

# Game Basic Information #

## Summary ##

Untitled Platformer Game is a platform adventure game consisting of four different levels with their own theme and distinct obstacles the player has to go through. You play as Koble, an explorer from Mirai City, who's on a quest to collect the *Power Gems* that unlock portals connecting the different worlds of the disconnected continent of Isolasia.

***Fun Fact: 'Koble' is Norwegian for 'connect.'***

## Gameplay explanation ##

Avoid obstacles and collect enough gems required to open up the portal connecting to the next world. Used the arrow keys or A and D keys to move left and right. The player can jump by pressing the space bar and the jump height will increase if the space bar is held down longer. The Z key can be pressed to run faster. In order to clear levels, the player may also be required to use a combination of keys (such as holding Z and space to make a long jump).

## Levels ##

The game is divided into four levels, each written and designed by one of the team members. Level design was a significant component of the development process. They are roughly ordered by increasing difficulty.

### Mirai City ###

The first level of the game was designed to introduce the player to the general mechanics of the game. The various obstacles that are found along the way (blades, conveyor belts, and acid pools) are reminiscent of a city that is well-developed but at the same time, home to a lot of toxicity, both literally and figuratively. The name of the city is based on the Japanese word for 'future,' further illustrating the more 'futuristic' part of Isolasia.

### Hidden Forest ###

The second level of the game is a completely different dynamic than the first level. It is a jungle/forest like environment with more moving platforms and new obstacles(falling spikes). It shows a different primitive side of Isolasia than the previous level.

### Bayside Village ###

The third level of the game is a bit trickier compared to the previous two levels because there are many moving platforms, spikes and enemeies to dodge, and some small puzzle elements added to this level. This level is a grassy village environment that is near some sort of bay or ocean area. This level gives off a more relaxing ambience compared to that of the previous two levels.

### Davis ###

The last level is stylistically based on UC Davis using photography from Davis. The squirrels flying from trees to attack are representative of the typical Davis experience. The music would be one of the pastoral pieces by Vaughn Williams, but his works are in copyright. The level design is intended to contain unexpected elements, but without overtly deceptive design.


# Main Roles #

## User Interface

As a platformer game, we wanted to make our UI simple and as least distracting as possible. 

*Exposition* - The exposition of the world and the plot was done in the beginning so as to introduce the player to the premise of the game. It is displayed through a panel that is present in the 'MainMenu' and has a [PanelFadeController](https://github.com/vpeesapa/ECS-189L-Final-Project/blob/master/Assets/Scripts/PanelFadeController.cs) script attached to it which lets the panel to fade out after 20 seconds or at the press of the spacebar.

*Main Menu* - Our initial main menu consists of three buttons: Play, Help, and Exit. When the user presses play, the first level is loaded. [LoadSceneOnClick](https://github.com/vpeesapa/ECS-189L-Final-Project/blob/master/Assets/Scripts/LoadSceneOnClick.cs) is a script that allows us to load the next scene, which in our case is the next level, with the press of a button.

*HUD* - The HUD consists of two counters, one for the number of lives the player has remaining and the number of gems the player has collected in the current level. There is a sprite next to each counter to represent what each counter indicates. It also contains a 'Pause Button' that allows the player to pause the game whenever they want to. The HUD also displays the name of the level upon first playing that level. The display for the level names was inspired by several Pokemon games, which have a similar feature whenever the player enters a new city or town. The name of the level fades out after a certain amount of time and is controlled by [this](https://github.com/vpeesapa/ECS-189L-Final-Project/blob/a6b1898250899465aea09f3f3627d17f387ec472/Assets/Scripts/PlayerController.cs#L334) part of the 'PlayerController' script. There is also a number that's constantly displayed in front of the portal and which indicates the number of gems the player has yet to collect before they are able to clear the level. This number is constantly modified in the [PlayerController](https://github.com/vpeesapa/ECS-189L-Final-Project/blob/a6b1898250899465aea09f3f3627d17f387ec472/Assets/Scripts/PlayerController.cs#L55) script whenever the player connects the gem. The general idea for this is inspired from Super Mario 64 and more recently, Super Mario Odyssey, where progression is done by collecting a certain amount of 'Power Stars' or 'Power Moons.'

*Pause Menu* - There is a pause menu that's been implemented in every level, which allows the player to pause the game and take a breather. The UI for the pause menu is only displayed upon clicking the pause button from the HUD. The pause menu contains three buttons: a 'resume' button that allows the player to continue playing from where they left off, a 'restart' button that lets them restart the level from the beginning, and an 'exit' button that lets them go back to the main menu. Most of the logic for this menu is similar to the logic for the main menu and also utilizes the [LoadSceneOnClick](https://github.com/vpeesapa/ECS-189L-Final-Project/blob/master/Assets/Scripts/LoadSceneOnClick.cs) script.

*Game Over Screen* - There's also a game over screen that's been implemented in every level. It is initially hidden from the player and is only displayed when the player had lost all of their lives for that level. The menu comprises of a 'Game Over' message and two buttons: a 'restart' button that allows the player to restart the level from scratch and an 'exit' button that lets them return to the main menu. Once again, the underlying logic utilizes the [LoadSceneOnClick](https://github.com/vpeesapa/ECS-189L-Final-Project/blob/master/Assets/Scripts/LoadSceneOnClick.cs) script. The logic that keeps track of player deaths can be found in the [PlayerController](https://github.com/vpeesapa/ECS-189L-Final-Project/blob/f60a90ae1c6b0bc752050a04d5dbfab815ea6a07/Assets/Scripts/PlayerController.cs#L366) script.

*Thank You Screen* - There's a 'thank you screen,' which is displayed after the player clears the Davis level. It contains a message thanking the player for playing and beating the game as well a button that lets them return to the main menu. The button once again utilizes the [LoadSceneOnClick](https://github.com/vpeesapa/ECS-189L-Final-Project/blob/master/Assets/Scripts/LoadSceneOnClick.cs) script.

*Text Font* - The font used in various texts in the UI is from [1001 Free Fonts](https://www.1001freefonts.com/computer-fonts.php).

## Movement/Physics

Since the game is a 2D platformer, we wanted the controls for the character to be as simple as possible but still feel fluid and make the player feel like they have complete control over the character.  
  
*Horizontal Movement* - We wanted the player to have sharp control over the character so we opted to use [Input.GetAxisRaw](https://github.com/vpeesapa/ECS-189L-Final-Project/blob/74b7c59440e6e6b1f6f5a13922ce3baceec1f69a/Assets/Scripts/PlayerController.cs#L253) which returns discrete values like -1, 0, and +1 rather than Input.GetAxis which returns continuous values in the range -1 to +1.  
  
*Sprint* -  The controls for the platform take heavy inspiration from the game Super Mario Bros. so we have a normal running speed when you move the character with the arrow keys and a much faster running speed when the 'Z' key is held down while moving the arrow keys. The [moving speed of the character is modified](https://github.com/vpeesapa/ECS-189L-Final-Project/blob/74b7c59440e6e6b1f6f5a13922ce3baceec1f69a/Assets/Scripts/PlayerController.cs#L248-L251) appropriately when the 'Z' key is held down.
  
*The Jump* -  We wanted the jump to feel a bit dynamic so we made it so that the character [jumps to a certain height based on how long the space bar is held down](https://github.com/vpeesapa/ECS-189L-Final-Project/blob/74b7c59440e6e6b1f6f5a13922ce3baceec1f69a/Assets/Scripts/PlayerController.cs#L273-L301) by using timers. Upon pressing the space bar, a positive upward force is added to the player until the user lets go or the jump timer runs out. At this point, the gravity of Unity's Physics Engine takes over and pulls the player downward.

There were also other scripts that also controlled the movements for several obstacles that were present in the game.

### Scripts that were used to control game obstacles/game objects

[BladeController](https://github.com/vpeesapa/ECS-189L-Final-Project/blob/master/Assets/Scripts/BladeController.cs) - Controlled the linear and rotational motions of the blade found in Mirai City.

[CameraController](https://github.com/vpeesapa/ECS-189L-Final-Project/blob/master/Assets/Scripts/CameraController.cs) - Controlled the camera so that it moves along with the player.

[CrateController](https://github.com/vpeesapa/ECS-189L-Final-Project/blob/master/Assets/Scripts/CrateController.cs) - Didn't control the motion of the crate found in Bayside Village, but respawns it if the crate doesn't land on any platform.

[EagleController](https://github.com/vpeesapa/ECS-189L-Final-Project/blob/master/Assets/Scripts/CrateController.cs) - Controlled the movements of the eagle found in Bayside Village.

[PlatformController](https://github.com/vpeesapa/ECS-189L-Final-Project/blob/master/Assets/Scripts/PlatformController.cs) - Controlled the motion of movable platforms that are found in all levels. Could be used to either move those platforms either horizontally or vertically.

[PlayerController](https://github.com/vpeesapa/ECS-189L-Final-Project/blob/0831705b91455d1c2b220b9fb5c280fc31689297/Assets/Scripts/PlayerController.cs#L349) - Has the implementation for controlling the player's motion when they're standing on the conveyor belt in Mirai City.

[Shooter](https://github.com/vpeesapa/ECS-189L-Final-Project/blob/master/Assets/Scripts/Shooter.cs) - Controlled the delay with which the squirrels found in Davis would be launched from the tree.

[SlimeController](https://github.com/vpeesapa/ECS-189L-Final-Project/blob/master/Assets/Scripts/SlimeController.cs) - Controls the movements of the slimes found in Bayside Village.

[SpikeController](https://github.com/vpeesapa/ECS-189L-Final-Project/blob/master/Assets/Scripts/SpikeController.cs) - Controls the movements and positions of the continuously falling spikes found in Hidden Forest.

[SquirrelController](https://github.com/vpeesapa/ECS-189L-Final-Project/blob/master/Assets/Scripts/SquirrelController.cs) - Constantly updates the sprites of the squirrels if they're in motion.

## Animation and Visuals

*Portal* - The portal sprite was made by [Elthen](https://elthen.itch.io/2d-pixel-art-portal-sprites).

*Character Sprite* - The player character sprite was made by [Jessica Munguia](https://jesse-m.itch.io/jungle-pack).

*Jungle* - The tiles used in the jungle map, the background and the falling spikes were made by [Jessica Munguia](https://jesse-m.itch.io/jungle-pack).

*Village Level* - The moving platforms and the tiles were made by ANSIMUZ from the [Unity Asset Store](https://assetstore.unity.com/packages/2d/characters/sunny-land-103349).

*Village Background Props* - The trees and the other background props used in the Village level were made by ANSIMUZ from the [Unity Asset Store](https://assetstore.unity.com/packages/2d/characters/tiny-rpg-forest-114685).

*Slime Enemies* - The slimes in the Village level were made using a slime sprite made by NYKNCK from the [Unity Asset Store](https://assetstore.unity.com/packages/2d/characters/slime-character-157405).

*City Level* - The background for the City level was from [OpenGameArt](https://opengameart.org/content/backgrounds-for-2d-platformers). The platform and other assets were from [GameArt2d](https://www.gameart2d.com/free-sci-fi-platformer-tileset.html).

*Conveyor Belt* - The conveyor belt used in the City level was from OpenGameArt by [Chromaeleon](https://opengameart.org/content/conveyor-belts-spritesheet-anims).

*Davis Level* - The two backgrounds, squirrel, water tower, and needle are all photos taken by Ian.

*Gustav Holst's music* - [Venus](https://en.wikipedia.org/wiki/File:Holst-_venus.ogg), used in the Davis level, and [Mercury](https://en.wikipedia.org/wiki/File:Holst_The_Planets_Mercury.ogg), used by the trailer, are public domain performed by the U.S. Air Force Band, downloaded from Wikipedia.

The visuals for our game has a simplistic retro feel. Our platformer game is meant to be played in a speedrun style so we wanted to keep our visuals and animations as simple as possible while mantaining the immersiveness of our game. To make each level feel dynamic we used different types of visuals for each level. The city level has a sci-fi feeling with obstacles such as an acid pool, saw blade and a conveyor belt. The jungle level and city level uses tilemaps with tiles that fit the theme of the level. The davis level uses pictures taken in Davis as sprites.

Koble's animation is controlled by the Unity editors Animator component. Kobe goes through three animation states throughout the game: idle, run, and mid air. The sprites for the different animation states were all provided by [Jessica Munguia](https://jesse-m.itch.io/jungle-pack).



## Input

Our game supports keyboard and mouse inputs. Mouse is used to navigate the UI and the menus while the keyboard is used to move the player. The [PlayerController Script](https://github.com/vpeesapa/ECS-189L-Final-Project/blob/74b7c59440e6e6b1f6f5a13922ce3baceec1f69a/Assets/Scripts/PlayerController.cs#L273) controls the player's movement.

*2D Movement* - Use left and right arrow keys or alterantively A and D keys to move left and right. [Script](https://github.com/vpeesapa/ECS-189L-Final-Project/blob/e9e920f251e2e24b06d651c82eec04ee1721fe61/Assets/Scripts/PlayerController.cs#L253)

*Jump* - The space key is used to jump. Holding the space key longer will result in the player jumping higher. [Script](https://github.com/vpeesapa/ECS-189L-Final-Project/blob/e9e920f251e2e24b06d651c82eec04ee1721fe61/Assets/Scripts/PlayerController.cs#L273)

*Running* - Holding the Z key while moving will make the character move faster. Holding Z while jumping will make the character jump further. [Script](https://github.com/vpeesapa/ECS-189L-Final-Project/blob/e9e920f251e2e24b06d651c82eec04ee1721fe61/Assets/Scripts/PlayerController.cs#L248)

As the game may be slightly challenging, we added cheat commands to test the game and try out different parts of the game.

*Skip level* - Pressing the Control and F1 keys at the same time will allow the user to skip the current level. [Script](https://github.com/vpeesapa/ECS-189L-Final-Project/blob/e9e920f251e2e24b06d651c82eec04ee1721fe61/Assets/Scripts/PlayerController.cs#L313)

*Invinciblity* - Pressing the Control and F2 keys at the same time will enable a cheat mode to make the player become invulnerable to enemies and other obstacles. [Script](https://github.com/vpeesapa/ECS-189L-Final-Project/blob/e9e920f251e2e24b06d651c82eec04ee1721fe61/Assets/Scripts/PlayerController.cs#L318)

## Game Logic

The game is divided in Unity into one scene per level. Most of the core logic is in the `PlayerController` script attached to the `Player` object in each scene, which is configured with a variety of `[SerializeField]`s. This maintains the state needed within the level, and interfaces with UI and input. Some UI related objects are copied between scenes; a better overall architecture would probably make much heavier use of prefabs.

The game is divided in Unity into one scene per level. Most of the core logic is in the `PlayerController` script attached to the `Player` object in each scene, which is configured with a variety of `[SerializeField]`s. This maintains the state needed within the level, and interfaces with UI and input. Some UI related objects are copied between scenes; a better overall architecture would probably make much heavier use of prefabs.

There are two variable `IsGrounded` and `IsJumping` in the `PlayerController` script to control the jump of the player. The `IsGrounded` variable checks if the player is on the ground or a platform so that the player can not jump more than once in the air. The `IsJumping` variable is used to check if the player is in the air so that the proper animation is used. If the player is in the air, the player should not be in the running animation.

`PlayerController` script also holds the variables `GemsCollected` and `LivesRemaining`. These variables are used to display the proper counters on the UI of the game. The `GemsCollected` variable is also used to check if the player has the correct number of gems to pass through a portal. The `LivesRemaning` variable will make the user restart the level if the value reaches 0.

The `PlayerController` script also checks for interactions with the environment. For instance, if the player is on a conveyor belt, the player is slowly moved in the same direction the conveyor belt is moving. The script also checks if the player has collided with a gem and collects the gem. Collision with enemies and other obstacles such as spikes are also checked and the player goes back to the start of the level with one less life. If the player collides with a portal with the required number of gems, the player is automatically transported to the next level.

# Sub-Roles

## Audio

**List your assets including their sources and licenses.**

*Jungle* - The background soundtrack in the Jungle level is from [Ludum Dare](http://ludumdare.com/compo/ludum-dare-32/).

*Village* - The background soundtrack in the Village level is from the Unity Asset Store by [Zero Rare](https://assetstore.unity.com/packages/audio/sound-fx/sound-fx-retro-pack-121743).

*City* - The background soundtrack in the City level is from [Sound Image](https://soundimage.org/city-urban/).

*Jump* - The jump soundtrack effect is from a free sound effect pack from the Unity Asset Store by [Zero Rare](https://assetstore.unity.com/packages/audio/sound-fx/sound-fx-retro-pack-121743).

An audio source component is attached to the Player object at each level to play the corresponding background sound and the jump sound when the player jumps. In the main menu, an audio source component is attached to the Canvas to play the main menu sound.

We chose to use an 8-bit style soundtrack for our levels similar to our visual style. Each level has a different soundtrack to reflect the theme of each level. The City level has a chill sci-fi music to fit the dark city-scape background and the sci-fi sprites used for this level. For the Jungle level, we chose a more high-paced adventurous sound. The village level has a beach in the background so the soundtrack is a peaceful piano music. Similarly, the Davis level has peaceful flute music playing in the background for the farm-like atmosphere of the city of Davis.

## Gameplay Testing

**Please use your UC Davis e-mail address to access the following link.**

[Link to results of gameplay testing](https://docs.google.com/spreadsheets/d/1W2F9wkQy_VTyHWFTHw35HolKg1pSE9ViAUyBER8Ghak/edit?usp=sharing)

### Summary of key findings

The general consensus of our gameplay testers was that the gameplay was a bit on the challenging side. While this didn't hinder them from enjoying the game, there were a few that questioned if the higher difficulty curve would stop more casual gamers from playing the game. At the same time, there were a few that mentioned that hit-boxes (or collision boxes) were being activated even if the player was not touching any hazards. Most people were also suggesting if we could include some power-ups such as extra lives that can help the player. Aside from that, a majority of them were happy with the visuals, including the UI elements, and the level progression of the game.

## Narrative Design

The core narrative of the game is that the player controls Koble to explore the isolated worlds of Isolasia, which was once a thriving continent, but due to a cataclysmic natural disaster in the past, is left on the brink of destruction and the only way that the player can proceed is by collecting enough *Power Gems* to unlock the portal to the next world. The exposition done at the beginning of the game allows the player to get a general idea of what Isolasia is like.

We also had each level design be as unique and distinct as possible to further illustrate that these worlds have been isolated for a long period of time, allowing the player to further interpret the story behind the design of each level in their own ways.

## Press Kit and Trailer

[Game Trailer](https://www.youtube.com/watch?v=f9yEC4gjdEY)

[Press Kit](https://github.com/vpeesapa/ECS-189L-Final-Project/blob/master/Press%20Kit.pdf)

The trailer includes a couple clips from each of the levels, and tries to demonstrate the basic game dynamics, as well as some of the interesting design elements in particular levels.

The press kit includes screenshots of all the levels that are present as well as giving a general description of the game. Some other press kits that we took inspiration from are [Press Kit 1](https://github.com/isaboi/ECS189L_GameProject/blob/master/TheStruggle_PressKit.pdf) and [Press Kit 2](https://github.com/kyle-andrus/RIP/blob/master/PressKit/presskitty.md).


## Game Feel
Various subtle things were added to make the gameplay experience better for the user.

*Level Progression* -  We wanted the continuity of the levels to flow well based on difficulty so that the player can be eased on in the first 1 or 2 levels and then try out more difficult levels once they got the hang of the controls and its dynamics. The levels are essentially ordered from easiest to hardest. 

*Narrative*  - We wanted to make our game as immersive as possible by displaying the narrative of the game as soon as the game starts.

*Hitbox*  - The hitbox of obstacles were adjusted so that the player doesn't die when the player visually does not collide with obstacles.

*Pause Menu*  - We added a pause menu to allow the user to pause the game whenever they want.

*Jump* -  Jumping is the core mechanic of the game so a lot of time was spent trying to adjust this. We wanted a jump that makes it look like that the player moves somewhat slower upward on the jump rather on downward on the jump making it look like that the player is floating at the maximum height of his jump for a split second. Along with this, a subtle [squeeze effect](https://github.com/vpeesapa/ECS-189L-Final-Project/blob/74b7c59440e6e6b1f6f5a13922ce3baceec1f69a/Assets/Scripts/PlayerController.cs#L178-L202) commonly implemented in several games, especially 2d platformers, is used to make the character feel a bit more bouncy and gives the jump mechanic a little more "juice."

