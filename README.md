# RainbowInTheDark

Global Game Jam
Design doc - idea 3 -chosen
"Rainbows in the Dark" v0.1
Theme: what do we do now?

Release is available at https://github.com/zaphod-utcs/RainbowInTheDark/releases/tag/Final

Table of contents:

1) General Information

2) Game information

2A) Game Idea
2B) Game Narrative
2C) Game Mechanics
2D) Character

3) Tools

4) Gameplay

4A) Menu - to - level 1
4B) Load screen/Level Transition
4C) Movement
4D) Commands
4E) Environments
4F) Pulse Waves & Particles 
4G) Wormholes/Finish
4H) Exhaustion Meter
4I) End of the Level

5) Team Members








1) General Information
Resources: 
http://gamedev.utexas.edu/news/global-game-jam-2015/resources/

Our page's page:
http://globalgamejam.org/2015/games/rainbows-dark

Platform:
PC

System:
Unity

Image format:
.PNG





















2) Game Information

2A) Game idea:
Using sounds and particles to reveal obstacles within an environment and find the wormhole to complete the given level. 

2B) Game narrative:
You are a Narwhal in Space!! Your mission, is to get home! Your space bar sends out a pulse of particles. As the pulse travels, it begins to dissipate after a second or two. The player moves around and uses pulses to find wormholes that may take you home.

Get home lil' Narwhal!

2C) Game mechanics:
Particle pulses that interact with objects in a given space
Directional movement with space bar keys
Black space environment with collision 
Sound cues communicate to player successes, failures, or clues to the puzzle 
Spacebar inputs send pulses out from the player's avatar 
Later levels will include mazes for the user to navigate through as opposed to a room with objects in them
Timer in upper corner of the screen to help player gauge speed
Exhaustion Meter that can run out if player moves too much without making it to the goal. Should the meter deplete, the level restarts
The Exhaustion Meter will also be penalized if the user runs into an invisible wall

2D) Character
The player avatar is a Narwhal that changes the color of her horn. When she shoots out pulses, bubbles are sent out. 

The animation is 3 different pictures tied by several key frames. 

When a pulse is fired, the sprite changes to the Narwhal with a rainbow horn and glowing red eyes. 







3) Tools
Github repo
Unity
Adobe Photoshop
Adobe Illustrator
Google drive, docs, sheets, hangout
Audacity
Linux
Windows
OSX

Tools of the game:
Light responses, Auditory responses, ASWD/arrow key player controller, physics engine
























4) Gameplay

4A) Menu - to - level 1

When the game is launched, the player is greeted by a small loading screen.

Once the loading screen finishes, the main menu appears showing the Title, “Rainbows in the Dark”, the player’s avatar in the center of the screen, and two option buttons below her. 

Pressing the "Start" button brings the player to level 1.

Pressing the "Control" button will bring the player to another page illustrating the player controls and "ping" bar. There will be a "Back" button that brings the user to the title page.


4B) Load screen/Level Transition

When the player completes a level, there will be a small win animation. After the animation finishes, the screen will bring the player to the next level very quickly. 

There are no loading screens. 


4C) Movement

The player is given a set start point in every level. Players can either use A,W,S, and D or opt to use the Up, Down, Left, and Right arrows located on the keyboard. 


4D) Commands

Users have one command to assist them in their puzzle: The Space Bar. The Space Bar will send out a pulse of particles from the player’s location in a circular wave. 



4E) Environment and Dark Matter Walls

Each level presented will be themed after deep space environments. The game has players navigating through a box with walls that cannot be seen or passed through. 

Early levels will contain few or no obstructions. Later levels will contain various configurations of squares, triangles, circles for the players to have to be conscious of. 

Future levels will feature mazes for the user to traverse. These maps may also include teleporting wormholes that take you to other rooms. 

When a wall is struck with a particle, a sound is tied to the particular shape being hit. Squares will make certain noises while ovales will have a different, distinct noise. (To be added in a future build)

Particles hitting certain walls will also change in color. (To be added in a future build)

4F) Pulse Waves and Particles

When using the space bar, a wave of particles is released from the player's location. The particles will interact with the environment in different ways. 

If fired with no obstructions, the particles will fade away after a set of time.

Should a particle collide with a wall, the particles will bounce back until they expire.

Should a particle come close to a Wormhole of any kind, the particles will gravitate to the center of the anomaly, change color, and expire. 

This game features bubbles for their particles!

4G) Wormholes

Wormholes will be placed in key locations on each map. When plays send a pulse near the wormhole, the particles that enter its location will be pulled into the center coupled with a distinct sound. This will let the player know to travel to that location. 

In early levels, getting to a wormhole completes the level. 

In later levels, some wormholes provide attribute changes to the player's pulses. They can also warp the player to another location. 

In some levels there will exist Decoy Wormholes and Reverse Wormholes.

Decoy Wormholes give off the behavior of a normal Wormhole but do not interact with the player. This harms the player’s exhaustion levels and forces the player to remember that Wormhole as the tackle the level again.

Reverse Wormholes do not interact with the player but do interact with the particles. The bubbles will turn red and slowly reflect off the invisible object.


4H) Exhaustion Meter

To provide a challenge to the user, players have a certain number of "steps" they can make in a certain level before being reset to the beginning of the level. 

Current steps allowed for level one is 100. We will be going through the levels, by hand, and setting proper exhaustion rates.

4I) End of the Level

When the player enters the appropriate wormhole,the Narwhal will change animations to congratulate the player. The screen will fade out and load the next level. 
 




















5) Team Members
Zach Koch ezekeal@gmail.com	- Programmer 

Arthur Peters	amp@singingwizard.org	- Programmer/ Designer / Sound

Jason Brown	jbnetaccounts@gmail.com - Programmer/ Designer
 
Alyssa Peters	alyssa.r.peters@gmail.com - Programmer/ Illustrator / Designer

Michael Blackard oreinai4@gmail.com - Producer/ Designer 








