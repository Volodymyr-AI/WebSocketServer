# WebSocketServer
# Description
This project is an implementation of a simple WebSocket server built with .NET Core, designed to run on Linux Debian. The server accepts WebSocket connections and uses MessagePack for message serialization.

# Requirements
.NET Core 8
Linux Debian (can be run on a virtual machine via VMware Workstation)
MessagePack for .NET
Setup and Run
Ensure that you have .NET Core SDK and necessary dependencies installed on your Linux Debian system before running the server.

After starting, the server will listen on port 5000 and handle incoming WebSocket connections.

Usage
To test the server, you can use any WebSocket client configured to connect to ws://ip_address:5000. Upon a successful connection, the server will send a "Hello World" message and close the connection.
