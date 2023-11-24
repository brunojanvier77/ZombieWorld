#  ZombieWorld : Base-Building / Simulation Game Tutorial made with Unity
![Preview Thumbnail](https://raw.githubusercontent.com/Fy-/FyWorld/master/preview.png)

[About](#about)  
[Contribute](#contribute)  
[Story](#story)  
[Copyright & Licensing](#copyright--licensing)  
[Links & Playlist](#links--playlist)  
[Inspiration](#inspiration)  
[Contact](#contact)


## About
ZombieWorld is a top down simulation game in a zombie world.  
It’s a war / base-building / simulation open source game made with Unity. 
 
## Contribute
FyWorld which this project is forked from gave a solid ground to build upon.
We already have:
  * World generation with perlin noise and regions using layered tile grids
    * high performance rendering - no gameobjects - all the meshes are pooled in memory and drawn directly
    * every tile have properties to create interesting world (fertility, path cost, etc.)
    * same for characters which are skinnable and possible to animate
    * stackable inventory
  * AI - agents and behaviour tree and path finding
  * UI - basic UI system to be developed


There are many ways to contribute to the project:
  * Test play it and report issues or improvement ideas
  * Help improve audio
  * Help improve graphics and animations
  * Help improve the story or the events taking place
  * Code interesting worlds: 
    * generate a post-apocalypse city from code
    * generate a more interesting nature from code
  * Code interesting behaviours:
    * the project uses now a behavior tree with a task system. It can go a long way and be much richer and interesting.
    * the agents have simple needs and this can be further developed.
  * Code weapon systems and tech tree:
    * improve combat, logistic and tech in the game
  * Code vehicle and traffic systems:
    * vehicles for combat or for carrying things effectively for production and combat
  * Support Animations and particle systems
  * Code UI:
    * there is a lot be done here but we have basic windows and buttons
    * we have no start screen, no game over screen etc.
  * Code controllers:
    * there is a lot be done here but we have basic windows and buttons
  * Code core stuffs:
    * improve A* path finding implementation
    * improve loading/saving game state
    * optimize

## Story
The game will be about keeping your humans alive by giving them food and ammos and weapons to fight the hordes of zombies that are going to constantly go after them
and avoid total extinction. Expect a fast pace shooter-like experience but you have to deal with logistics and prepare for a war of 20 minutes . 
The hordes of zombies will grow larger and larger as time goes.

 
## Copyright & Licensing

The base project code is copyrighted by Florian "Fy-" Gasquez and is covered by multiple licenses.  
All program code (i.e. C#) is licensed under GPL v3.0 unless otherwise specified.  Please see the "LICENSE" file for more information.  
All non-code assets (e.g. art, sound, txt, story, XML, JSON) is licensed under CC BY-NC-SA 3.0 (Attribution-NonCommercial-ShareAlike 3.0 Unported) unless otherwise specified.

## Links & Playlist
 * Youtube Playlist: https://www.youtube.com/watch?v=ckDSPMe1Yf4&list=PL3zJehMxBSE_MWK954EZy0Ygy1p6sWg3i 

## Inspiration
This game is inspired by Rimworld, Dwarf Fortress, Prison Architect and my favorite game The 4th coming but also by Quill18 ProjectPorcupine (https://github.com/OrderOfThePorcupine/ProjectPorcupine).

## Contact 

