# _Perfect Hair Forever_

#### _Perfect Hair Forever | July 13, 2018_

#### By _**Nikki Boyd**_

## Description

This app was built for Perfect Hair Forever's employees to help manage all clients and stylists. It allows employees to:
- Add and update contact details for their clients
- Review a list of all clients for each stylist
- Batch remove remove all employees and clients
- Delete or update details for individual employees and clients

## Specifications

- Employees can view a list of all stylists.
- Employees can select a stylist, see their details (name), and view all of their individual clients.
- Employees can add new stylists to the system as they are hired.
- Employees can add new clients and assign them to a specific stylists via a dropdown selection. They may enter the client's name, phone, and email.
- Employees can delete all stylists from the database.

## Setup/Installation Requirements

* _1. Clone the master branch of "hair-salon" from this repository: (https://github.com/nikkiboyd/hair-salon)_
* _2. Ensure .NET Core 1.1 is installed on your machine._
* _3. Ensure Mono is installed on your machine._
* _4. If not running from Visual Studio, please run the command "dotnet restore" in Terminal to refresh packages._
*_5. Tests are located in the file "WordCounter.Tests". All tests for both controllers and models are currently in passing state.
*_6. Terminal instructions for recreating database:
      > CREATE DATABASE nikki_boyd;
      > USE nikki_boyd;
      > CREATE TABLE stylists (id serial PRIMARY KEY, name VARCHAR(255));
      > CREATE TABLE clients (stylist_id int(11), name VARCHAR(255), phone VARCHAR(255), email VARCHAR(255));

## Known Bugs

_Delete and update features are not yet implemented, despite the buttons being present. This fix will be implemented over the weekend._

## Support and contact details

_Please reach out to Nikki Boyd at boyd.nikki@icloud.com if you experience difficulty running this page._

## Technologies Used

_This console app was made with C#, HTML, CSS, and Bootstrap._

### License

*This software is licensed under the MIT license.*

Copyright (c) 2018 **_Nikki Boyd_**
