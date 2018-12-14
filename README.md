# Hair Salon, 12_14_18

#### This website is an application that simulates a hair salon.

#### By Cristian Lucero

## Description
This program will put the user in the shoes of a hair salon employee. They will be able to add stylists as a category, and within that category of stylist, clients will be added to a specific stylist. When a stylist is clicked on the user will have access to seeing stylist details and all clients belonging to them. This version of the webapp will include full CRUD functionality. (Create, Read, Update, Delete). Users will now be able to update(edit) certain aspects of stylists and will also be able to delete stylists and clients.

## Specs
#### Behavior: The program will ask the user to enter a stylist's name.
* Example Input: "Styist1"
* Example Output: Here are the list of all the stylists in your salon: Stylist1
#### Behavior: The program allows user to see stylist details.
* Example Input: Here are Stylist1's details. 
* Example output: List of Stylist1's clients. (possibly put in reviews about Stylist1 if time?) 
#### Behavior: Program gives option to add clients to Stylist1's client list.
* Example Input: "Client1"
* Example output: Client1 is now on Stylist1's client list. 


## Setup/Installation Requirements to run program
* Clone repository $ git clone repo name
* Switch into the solution directory: $ cd HairSalon.Solution
* To edit, open in text editor
* To run program, navigate to HairSalon directory, run $ dotnet restore in terminal. 
* Start webpage by using $ dotnet run in terminal and following localhost:5000 link.

## Re-create my database and test database
In MySQL:
* CREATE DATABASE cristian_lucero;
* USE cristian_lucero;
* CREATE TABLE stylists (id serial PRIMARY KEY, name VARCHAR(255))
* CREATE TABLE clients(id serial PRIMARY KEY, name VARCHAR(255, int stylist_id)
## Replicate steps for test database.
In MySQL:
* CREATE DATABASE cristian_lucero_test;
* USE cristian_lucero_test;
* CREATE TABLE stylists (id serial PRIMARY KEY, name VARCHAR(255))
* CREATE TABLE clients(id serial PRIMARY KEY, name VARCHAR(255, int stylist_id)




## Known Bugs
N/A


## Support and contact details

For any quesitons contact me at: cristianjlucero32@gmail.com

## Technologies Used

* Misrosoft Testing Package
* C#
* .NET
* MySQL (database)
* Visual Studio Code (text editor)




### License

Copyright (c) 2018 Cristian Lucero

This website is licensed under the MIT license.