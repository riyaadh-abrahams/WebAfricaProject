# Web Africa Coding Assessment

This project management application is built using [aspnetboilerplate](https://aspnetboilerplate.com). The reason for this is that is has a good achitecture by default. It uses multiple layers on the back end, as well as a good React Architecture on the front end.

## Live Demo
You can view the application [here](https://codeworks-web.web.app). The back end is hosted on Azure, and the front end is hosted on firebase hosting. You can view the [swagger API](webafrica-project.azurewebsites.net) as well.

## Installation

Clone the repository

```bash
git clone https://github.com/riyaadh-abrahams/WebAfricaProject
```
## Running the back-end
- Open up the Asp .Net Core solution. 
- Set the Startup Project to be `WebAfricaProject.Web.Host`
- Set the connection string to an empty database. This is set in `WebAfricaProject.Web.Host/appsettings.json`
- In the package manager console, set `WebAfricaProject.EntityFrameworkCore` as the Default project
- Enter `update-database` to run the migrations.
- Start the server

The seed data will automatically be added to the database. 

## Running the React app

```
cd reactjs
npm install
npm start
```

## Running The Console App
The Console App is a repurpose of the Migrator App that comes with aspnetboilerplate. It has access to all the repositories through inversion of control system, so no need to access the DB directly

- Open up the Asp .Net Core solution. 
- Set the Startup Project to be `WebAfricaProject.ConsoleApp`
- Set the connection string to an empty database. This should be set in `WebAfricaProject.ConsoleApp/appsettings.json`.
- Run the App.

Warning. There is not much error checking in the console app.

## Cool Features
- Custom Seed Data scripts.
- Full CRUD for Employees, Jobs and Projects
- Mobx State Management
- Fancy Datepickers.
- Dynamic Job Dropdown when adding Employees.

## Assumptions & Issues
- The Skills Table was not mentioned, so there is no Front end features using it. There was enough many-to-many tables to deal with
- The provided user table stored raw passwords, so it was tossed. The ABP User table is now used, and passwords are hashed. The 2 users that were given added by default. 
- The database was rebuilt using code-first approach. This was to ensure better integration with entity framework core.
