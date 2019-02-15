# Unity to Raspberry Pi Communication

This repository establishes communication between the Raspberry Pi (in Python) and the Unity game engine (in C#) using network sockets.
It can be used for future projects which integrate VR/AR and real world systems.

Raspberry Pi - Server.
First modify the IP address to the address of the Pi. Then, run ServerSocket.py. You should see "Waiting for a connection" on console.

Unity - Client.
Create a new gameobject in Unity and attach a C# script to it. Make sure the name of the script and the name of the class is the same. In this case, Client Socket.
Copy and paste ClientSocket.cs code into the script, and change host address to the IP address of the Raspberry Pi.
Run the game using play button.
