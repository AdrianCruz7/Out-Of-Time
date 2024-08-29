Hi there!
This is my game, Out Of Time, a roguelike based on the concept of time being everything. It is your health, money, ammo, etc. Everything revolves around time. 
This game is made in Unity and is coded in C# and utilizes a bit of JSON for save functionality

![image](https://github.com/user-attachments/assets/8683d6ab-6173-49fe-bb18-6f4ed01e8aab)
![image](https://github.com/user-attachments/assets/8d01a997-1e69-44ee-a4d5-f9ac4d1686ce)
![image](https://github.com/user-attachments/assets/660f8c0a-825f-4a36-b3e0-11908facc438)

I've tried to make Out Of Time as modular as possible to have good scalability and maintainability by breaking up everything into multiple different scripts.
Some key features include procedural generation which can be utilized to make small or massive rooms as need be, the time mechanic which is utilized by anything requiring resources, the item system which can be incredibly flexible and used to make whatever you wish, and many more.

A couple of issues I ran into are the following:
The procedural generation. The main problem with it being it is difficult to implement boss rooms and treasure rooms with how they currently function. It will be improved to be completely random and implement some key features that had to be left out.
Balancing. The AI was a bit quick at times, the player didn't have enough damage, etc. Small things had to be fine-tuned to allow the player to have a better experience which was done over time.
Some of the movement is still a bit buggy. The dash the player can do is sometimes unresponsive and will be fixed in a later update.

To run the project, download the files in the main branch and open up the project in Unity. To start the game, open the SampleScene scene. If you wish to work on the different aspects of the game such as the procedural generation or items, open the scenes with their respective names.


