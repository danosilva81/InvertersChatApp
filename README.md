# Investors Chat App	
This is a web application to access a Chat Rooms. Users can register and logged in to chat with other logged users and also asks of stock values through the same chat

It was did it as a test exercise by [Software Engineer Daniel Silva Jiménez](https://www.linkedin.com/in/daniel-silva-jim%C3%A9nez-12871653)

## Main Functions

* Allow users to register.
* Allow registered users to log in and talk with other users in a chatroom.
* Allow registered users to select a chat room.
* Allow users to post messages as commands into the chatroom with the following format /stock=stock_code. In this case a bot will query for this quoute value in https://stooq.com/ 
and will put the result value in the corresopnding chat room.
* Have the chat messages ordered by their timestamps and show only the last 50 messages (this value can be changed in the controller). 

## How to Run it

To run the application is needed an "Update-Database" in the "Package Manager Console" to create the database with tables to be able to have register and log in process 
with the .NET Identity mechanism.

## Disclaimer

I did not use a message broker like RabbitMQ, because I think it is not necessary to have the app working properly, at least in the way I did it.


## Unit Testing

In the InvertersChatApp.Tests project you can find unit tests for some of the main functions.

