from __future__ import print_function #allows print functions to work as they do in python 3 for consistency (prevents paranthesis printing to the console)
import socket
import sys
#from blinkled import blinkled

backlog = 1
size = 1024
s = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
s.bind(('192.168.1.109', 12345)) #bind creates one unique address which is built up from both the ip address and port number.
s.listen(1)
#blinkled()


while True:
    print ('Waiting for a connection')
    connection, client_address = s.accept()
    print ('Connection from', client_address)
    data = connection.recv(1024)
    print ('Received "%s"' % data) #This works and receives UTF8 encoded data
    connection.sendall(b'This is the server')
    print ('Sent acknowledgement to client')

try: #this block of code isn't working for some reason. The client is being accepted but it's not printing 'Connection  from'. Maybe because no data is being received.
    print ('Connection from', client_address)
    while True:
        data = connection.recv(16)
        print ('Received "%s"' % data)
        if data:
            print ('sending data back to the client')
            connection.sendall(data)
        else:
            print ('no more data from', client_address)
            break
            
finally:
    print("closing socket")
    cient.close()
    s.close()
