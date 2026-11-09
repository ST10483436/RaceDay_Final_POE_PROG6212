# RaceDay
#What I Did in Part 3

In Part 2, I built a standalone Web API to handle the database. In Part 3, I built a complete MVC Web Application (RaceDay) that consumes that API, making it a full-stack application. I also added Azure Blob Storage integration for image uploads, wrote 21 unit tests, and containerized the MVC app using Docker.

#The Architecture (Why there are 3 Projects)

To follow the rubric strictly ("The MVC project must not contain any direct database access"), I split the solution into three projects:

1. RaceDay (MVC): The front-end. It only talks to the API using HttpClient. It handles sessions for user logins.
2. RaceDayMvc.Api (API): The back-end. It handles all ADO.NET database connections, SQL queries, and image uploads.
3. RaceDay.Tests: The unit testing project for the API models.

#Database Changes from Part 1 & 2

To support Part 3, I made two updates to my Part 1 SQL Script:

1. Added CategoryId to the EventEnrolments table so participants can enrol in specific categories.
2. Added an ImageUrl column to the Events table so Organisers can upload event banners.
   (These changes are explained in the RaceDay.Api.sql file).
   
#User Roles & Features

· Organiser: Can log in, create events (and upload banner images), add categories to events, view enrolments, and record results.
· Participant: Can register, log in, browse events, and enrol in events by selecting a category.

#How to Run the Project

1. Open SSMS and run the SQL script to create the RACEDAY database on (localdb)\api_guide.
2. Open RaceDay.sln in Visual Studio 2022.
3. Set Multiple startup projects (set both RaceDay and RaceDayMvc.Api to Start).
4. Press F5. Swagger opens for the API, and the MVC website opens in your browser.
5. Use the MVC website to Register a new Organiser, then create your first event

# CI/CD Pipeline

I have configured GitHub Actions to automatically build the entire solution (MVC, API, and Tests) and run the unit tests on every push to the master branch.

- *Workflow file:* Located in .github/workflows/dotnet.yml
- *Status:* 🟢 Green Build (All tests passing)

### How to check the CI/CD:
1. Go to the *Actions* tab at the top of this GitHub repository.
2. You will see a green checkmark ✅ next to the latest commit.
3. Click on the latest run and look under "build-and-test" to see that all 21 tests passed successfully.

