
# Game Basic Information #

## Summary ##

Untitled Platform Game is a platformer consisting of four different levels with their own theme and distinct obstacles the player has to go through. You play as Coble from Mirai City on a quest to collect gems to connect the different worlds in Isolasia.

## Gameplay explanation ##

Avoid obstacles and collect enough gems required to open up the portal connecting to the next word. Used the arrow keys or A and D keys to move left and right. The player can jump by pressing the space bar and the jump height will increase if the space bar is held down longer. The Z key can be pressed to run faster. 

## Levels

The game is divided into four levels, each written by one of the team members. Level design was a significant component of the development process. They are roughly ordered by increasing difficulty.

### Davis

The last level is stylistically based on UC Davis using photography from Davis. The squirrels flying from trees to attack are representative of the typical Davis experience. The music would be one of the pastoral pieces by Vaughn Williams, but his works are in copyright. The level design is intended to contain unexpected elements, but without overtly deceptive design.


# Main Roles #

Your goal is to relate the work of your role and sub-role in terms of the content of the course. Please look at the role sections below for specific instructions for each role.

Below is a template for you to highlight items of your work. These provide the evidence needed for your work to be evaluated. Try to have at least 4 such descriptions. They will be assessed on the quality of the underlying system and how they are linked to course content. 

*Short Description* - Long description of your work item that includes how it is relevant to topics discussed in class. [link to evidence in your repository](https://github.com/dr-jam/ECS189L/edit/project-description/ProjectDocumentTemplate.md)

Here is an example:  
*Procedural Terrain* - The background of the game consists of procedurally-generated terrain that is produced with Perlin noise. This terrain can be modified by the game at run-time via a call to its script methods. The intent is to allow the player to modify the terrain. This system is based on the component design pattern and the procedural content generation portions of the course. [The PCG terrain generation script](https://github.com/dr-jam/CameraControlExercise/blob/513b927e87fc686fe627bf7d4ff6ff841cf34e9f/Obscura/Assets/Scripts/TerrainGenerator.cs#L6).

You should replay any **bold text** with your relevant information. Liberally use the template when necessary and appropriate.

## User Interface

As a platformer game, we wanted to make our UI simple and as least distracting as possible. 

*Main Menu* - Our initial main menu consists of three buttons: Play, Help, and Exit. When the user presses play, the first level is loaded.

*In-game UI* - The in-game UI consists of two counters, one for the number of lives the player has remaining and the number of gems the player has collected in the current level. There is a sprite next to each counter to represent what each counter indicates. 

*Text Font* - The font used in various texts in the UI is from [1001 Free Fonts](https://www.1001freefonts.com/computer-fonts.php).

## Movement/Physics

**Describe the basics of movement and physics in your game. Is it the standard physics model? What did you change or modify? Did you make your movement scripts that do not use the physics system?**
The players movement is done on the 2D plane where the player is able to move left and right on the horizontal axes and jump on the verticles axes. The player moves left and right at a fixed speed which can be increased if the Z key is pressed.

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


## Input

*2D Movement* - Use left and right arrow keys or alterantively A and D keys to move left and right.

*Jump* - The space key is used to jump. Holding the space key longer will result in the player jumping higher.

*Running* - Holding the Z key while moving will make the character move faster. Holding Z while jumping will make the character jump further.

*Interacting with Portals* - Pressing the R key near a portal will allow the player to traverse through levels if they have collected the required number of gems.

*Invinciblity* - Pressing the Control and F1 keys at the same time will enable a cheat mode to make the player become invulnerable to enemies and other obstacles.

*Skip level* - Pressing the Control and F2 keys at the same time will allow the user to skip the current level.

**Add an entry for each platform or input style your project supports.**

## Game Logic

The game is divided in Unity into one scene per level. Most of the core logic is in the `PlayerController` script attached to the `Player` object in each scene, which is configured with a variety of `[SerializeField]`s. This maintains the state needed within the level, and interfaces with UI and input. Some UI related objects are copied between scenes; a better overall architecture would probably make much heavier use of prefabs.

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

**Add a link to the full results of your gameplay tests.**

**Summarize the key findings from your gameplay tests.**

## Narrative Design

**Document how the narrative is present in the game via assets, gameplay systems, and gameplay.** 

## Press Kit and Trailer

[Game Trailer](https://www.youtube.com/watch?v=f9yEC4gjdEY)

[Press Kit](https://github.com/vpeesapa/ECS-189L-Final-Project/blob/master/Press%20Kit.pdf)

The trailer includes a couple clips from each of the levels, and tries to demonstrate the basic game dynamics, as well as some of the interesting design elements in particular levels.

The press kit includes screenshots of all the levels that are present in the game along with giving a general description of the game. Some other press kits that we took inpiration from are [Press Kit 1](https://github.com/isaboi/ECS189L_GameProject/blob/master/TheStruggle_PressKit.pdf) and [Press Kit 2](https://github.com/kyle-andrus/RIP/blob/master/PressKit/presskitty.md).


## Game Feel

**Document what you added to and how you tweaked your game to improve its game feel.**
