# Charity Online Auction Web Application

This project is a web application developed for facilitating charity online auctions. The platform aims to provide a seamless and user-friendly experience for both organizers and participants of charity events.

## Features
* __Auction Management__: Users can create, edit, and delete auctions, specifying details such as item descriptions, starting bids, and auction durations.
* __Bidding System__: Participants can place bids on items they're interested in, with real-time updates on current highest bids.
* __Lot Visibility___: Active lots are displayed for users to browse and participate in auctions.
* __Bid History__: Users can view the bidding history of each item to track the progression of bids over time.
* __User Authentication__: Secure user authentication ensures that only authorized individuals can create auctions, place bids, and manage their account.

## Getting Started
To run the application locally, follow these steps:

* Clone this repository to your local machine.
* Navigate to the project directory.
* Using .NET CLI update database with the next command:
```
dotnet ef database update
```
* To run our project also use .NET CLI:
```
dotnet run
```
## Visual Overview

### Main page:
![alt text](/WebAuction/Images/main_page.png)

### Auction Details:
![alt text](/WebAuction/Images/bet_page.jpg)

### Auction Creation: 
![alt text](/WebAuction/Images/create-1.png)
![alt text](/WebAuction/Images/create-2.png)

### Authorisation:
![alt text](/WebAuction/Images/authorisation.png)

### Technologies Used
- __Frontend__: Figma, HTML, CSS, JavaScript
- __Backend__:  ASP.NET, Entity Framework, SQL Server

__Database schema__:
![alt text](/WebAuction/Images/db-schema.png)



## Development credits

This application was developed collaboratively by a team of four members, each contributing their expertise to different aspects of the project, as a part of creating a test task for a hakaton event.

**Anastasiia Munteanu** and **Saveliy Korniyko** designed the user interface using Figma, creating wireframes and mockups for the application, and implemented HTML and CSS for the initial design of the website. **Saveliy** joined **Fedir Sklyar** to work on frontend/backend integration, connecting frontend components with backend functionality, assisting in designing and implementing API endpoints for data retrieval and manipulation. **Dmytro Holiaka** implemented the backend logic and database functionality, ensured data consistency and security by implementing proper validation and authentication measures, developed interactive components and worked closely with the team to integrate frontend components correctlly.

Throughout the development process, all team members collaborated closely, providing feedback, reviewing code, and addressing any issues or challenges that arose. This collaborative effort ensured the successful completion of the charity online auction web application.

