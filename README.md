# RabbitMQ

This project uses RabbitMQ for Service A to communicate with Service B, it sends a message and the Message Bus handles the
message and sends it off to Service B.

It is a C# console project.

It was built using visual studio 2017 to be more specific.

In order to be able to run this project you need to have Erlang (21.3) installed and RabbitMQ-Server (v.3.7.14),

No configuration needs to be done as the application will automatically detected the RabbitMQ-Server and use it to run on localhost.

In the repo 2 folders have been Zipped as I was unable to commit from my machine and so I ended up having to manually upload my folders.
These folders are the 'Greetings.Test' and 'Packages'. Project can be downloaded and those two folders can be unzipped.

To run the project you need to open it using visual studio and set multiple projects as start up projects (Greeting.Producer and Greeting.Consumer).

Project is fully functional.
