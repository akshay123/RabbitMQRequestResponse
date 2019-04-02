# RabbitMQRequestResponse
A sample that shows how to run RabbitMQ / RPC style communication using .NET Core.

## Findings
It usually takes **~ 2 ms** to perform RPC async messaging between client and server. 
To see it in action. [See this video](https://github.com/akshay123/RabbitMQRequestResponse/blob/master/RMQ-RPC.mov)

## RabbitMQ Installation (on mac)
https://www.rabbitmq.com/install-homebrew.html#installation
Before installing make sure the taps are up-to-date:

    brew update

Then, install RabbitMQ server with:

    brew install rabbitmq

## Running the application 
There are two .NET core 2.2 projects in src folder both creates and uses queues on localhost.
1. Client 
2. Server 

You want to start the server before you start the client. 
