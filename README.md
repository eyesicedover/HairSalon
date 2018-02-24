# Hair Salon
#### C Sharp and ASP.Net web app for determining the number of times a word appears in a block of text, 2-23-18  

#### _By Stephanie Faber_  

## Description
_This is a project designed to take a user input of a stylist and a user input of clients for specific stylists. _  

## Specifications

1. User enters localhost:5000 to browser and it takes them to the Index.
* Example input: User enters localhost:5000 to browser
* Example output: Index is displayed with a form to take their word and text block

2. On Index, a list of stylists appears. There is a link to add more stylists. Clicking on the link takes the user to a form to add a stylist.
* Example input: Click on Add Stylist
* Example output: Goes to CreateForm

3. Form takes a name input for the stylist. There is a button to Add Stylist and a link to Go Back. Clicking on Add Stylist redirects to Index.
* Example input: User fills out stylist and submits it
* Example output: A new stylist is added to the stylist list in the database, the Index appears with the new stylist listed

4. On Index, user clicks on a stylist. It takes them to a list of clients for that stylist. On the page there is a link to Add Client and a link to Go Back.
* Example input: User click on stylist "Alex"
* Example output: A page of Alex's clients appears

5. On stylist detail page the user clicks to Add Client. The page is directed to a Form to add a client.
* Example input: Click on Add Client
* Example output: The form to Add a Client appears

6. User inputs a name for the client and submits. The client is saved for that specific stylist.
* Example input: Add Client "Josh" for stylist "Alex"
* Example output: Josh is saved to client list in database with and id matching Alex.


## Setup/Installation Requirements

* _Clone Repository_

* _Download and install .NET Core 1.1 SDK_

* _Download and install .NET runtime_

* _Download and install Mono for your platform_

* _Download and install MAMP for your platform_

* _Open MAMP and use the default ports_

* _In Mono command prompt, type >mysql -uroot -proot_

* _In mysql shell type >CREATE DATABASE hair_salon_

* _In mysql shell type >USE hair_salon_

* _In mysql shell type >CREATE TABLE stylists (id serial PRIMARY KEY, name VARCHAR(255));_

* _In mysql shell type >CREATE TABLE clients (id serial PRIMARY KEY, name VARCHAR(255), stylistId INT(11));_

* _In mysql shell type >QUIT_

* _In Mono command prompt, navigate to this project's folder_

* _In Mono command prompt, enter >dotnet restore_

* _In Mono command prompt, enter >dotnet build_

* _If there are no errors: In Mono command prompt, enter >dotnet run_

* _If there is an error, please contact me via email and describe your issue_

* _When the command prompt runs the build, enter localhost:5000 to your web browser. This should take you to the index page._

Github Repository Link (https://github.com/eyesicedover/HairSalon)

## Support and contact details

_Please email me directly at eyesicedover@gmail.com_

## Technologies Used

* HTML
* ASP.NET
* Razor
* .NET Core
* .NET SDK
* MAMP
* mysql

### License

*MIT License*

Copyright (c) 2018 **_Stephanie Faber_**

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
