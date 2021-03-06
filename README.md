# Unity to Raspberry Pi Communication

This repository establishes communication between the Raspberry Pi (in Python) and the Unity game engine (in C#) using network sockets.
It can be used for future projects which integrate VR/AR and real world systems.

Raspberry Pi - Server.
Open ServerSocket.py, and modify the IP address to the address of the Pi. Build and run. You should see "Waiting for a connection" on console.

Unity - Client.
Create a new gameobject in Unity and attach a C# script to it. Make sure the name of the script and the name of the class is the same. In this case, "Client Socket".
Copy and paste ClientSocket.cs code into the script, and change host address to the IP address of the Raspberry Pi (ensure this is done in the object field itself, not directly in script - see image "Client Socket Address.png"
Run the game using play button. On the server console, you should see "Connection from ('client IP address', client port). Received "This is the client""
