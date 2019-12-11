# Game Basic Information #

## Summary ##

**A paragraph-length pitch for your game.**

## Gameplay explanation ##

**In this section, explain how the game should be played. Treat this as a manual within a game. It is encouraged to explain the button mappings and the most optimal gameplay strategy.**




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

## Movement/Physics

**Describe the basics of movement and physics in your game. Is it the standard physics model? What did you change or modify? Did you make your movement scripts that do not use the physics system?**

## Animation and Visuals


*Character Sprite* - The player character sprite was made by [Jessica Munguia](https://jesse-m.itch.io/jungle-pack).

*Jungle* - The tiles used in the jungle map and the spikes falling down were made by [Jessica Munguia](https://jesse-m.itch.io/jungle-pack).

## Input

*2D Movement* - Use left and right arrow keys or alterantively A and D keys to move left and right.
*Jump* - The space key is used to jump. Holding the space key longer will result in the player jumping higher.
*Running* - Holding the Z key while moving will make the character move faster. Holding Z while jumping will make the character jump further.
*Interacting with Portals* - Pressing the R key near a portal will allow the player to traverse through levels if they have collected the required number of gems.
*Invinciblity* - Pressing the Control and F1 keys at the same time will enable a cheat mode to make the player become invulnerable to enemies and other obstacles.
*Skip level* - Pressing the Control and F2 keys at the same time will allow the user to skip the current level.

**Add an entry for each platform or input style your project supports.**

## Game Logic

**Document what game states and game data you managed and what design patterns you used to complete your task.**

# Sub-Roles

## Audio

**List your assets including their sources and licenses.**

**Describe the implementation of your audio system.**

**Document the sound style.** 

## Gameplay Testing

**Add a link to the full results of your gameplay tests.**

**Summarize the key findings from your gameplay tests.**

## Narrative Design

**Document how the narrative is present in the game via assets, gameplay systems, and gameplay.** 

## Press Kit and Trailer

**Include links to your presskit materials and trailer.**

**Describe how you showcased your work. How did you choose what to show in the trailer? Why did you choose your screenshots?**



## Game Feel

**Document what you added to and how you tweaked your game to improve its game feel.**
