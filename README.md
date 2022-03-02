                                                         ** Game of chance**
This project use to calculate the points of player based on the requested points if the player win. Player need to create an account and then he can make a Bet request.
                                                              **Summary** 
I am following service oriented approach and defining the seperate layer for models, repositories and services. I also written some integrations and unit test cases using XUnit

                                                          **_Instructions_**

Clone the repository.

open visual studio 2202 as administrator.

**Note:** Using .NET 6 for this project. I have created the migration based on SQL server. So you need to define the connection string in appsettings.json file accordingly. 
I am also using MS identity for user authentication and authorization

Build the solution and then run it!

Swagger integrated so you can view the endpoint.

You need to create an account by giving the email, username and password (Should follow the password policy.{Min-8characters, one capital, one special, one number})

Then you will need to log-in and get the JWT token after successfull login

Now you can hit the authorized Bet endpoint. You can use Postman to hit the authorized endpoint. 

If your bet is successful then you will get the points back by multiples by 9.

In case of fail you will lost the point and will hit the minimum account balance.

You can also run the integration and unit tests to verify the endpoints.

#Happy_Coding. :)
