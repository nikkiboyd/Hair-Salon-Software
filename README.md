# _Snappy Snips_

#### _Snappy Snips | July 20, 2018_

#### By _**Nikki Boyd**_

## Description

This app was built for Snappy Snips employees to help manage all clients and stylists. It allows employees to:
- Add and update contact details for their clients
- Review a list of all clients for each stylist
- Batch remove remove all employees and clients
- Delete or update details for individual employees and clients
- Create and assign specialties to stylists

## Specifications

Employees can utilize the following features:
- View a list of all stylists, clients, and specialties.
- View a specific stylist's personal details, their clients, and specialties.
- Add new stylists to the system as they are hired.
- Add new clients and assign a stylist to them.
- Update a client's name, stylist, phone number, or email address.
- Delete all or just one stylist from the database.
- Delete all or just one client from the database.
- Add a specialty and view all specialties that have been added.
- Add a specialty to a stylist OR a stylist to a specialty.

## Setup Instructions

* _1. Clone the master branch of "hair-salon" from this repository: (https://github.com/nikkiboyd/hair-salon)_
* _2. Ensure .NET Core 1.1 is installed on your machine._
* _3. Ensure Mono is installed on your machine._
* _4. Run the command `dotnet restore` to refresh packages._
* _5. Tests can be found in the folder "HairSalon.Tests"._
* _6. Import the provided database files to MAMP, or perform the following in Terminal:_

      * `CREATE DATABASE nikki_boyd;`
      * `USE nikki_boyd;`
      * `CREATE TABLE stylists (id serial PRIMARY KEY, name VARCHAR(255));`
      * `CREATE TABLE clients (stylist_id int(11), name VARCHAR(255), phone VARCHAR(255), email VARCHAR(255));`

## Known Bugs

_There are no known bugs at this time._

## Support and contact details

_Please reach out to Nikki Boyd at boyd.nikki@icloud.com if you experience difficulty running this page._

## Technologies Used

_This application is built with C#, HTML, CSS, and Bootstrap._

### License

*This software is licensed under the MIT license.*

Copyright (c) 2018 **_Nikki Boyd_**
