# README #

This is a Web API developed using .NET Core 3.1, which supports the following,

1. Endpoint: Create an applicant - Route: "/api/applicants", Verb: POST

2. Endpoint: Get an applicant by id - /api/applicants/{id}, Verb: GET

3. Endpoint: Update a given applicant - /api/applicants/{id}, Verb: PUT

4. Endpoint: Delete an applicant by id - /api/applicants/{id}, Verb: DELETE

### Highlights

* Clean Architecture  
* Clean Code 
* Swagger UI
* Serilog Logging
* Global Exception Filter

### How to run the application

1. Clone/download the source code
2. Open command prompt
* CD to src\Hahn.ApplicationProcess.May2020.Web
* dotnet restore
* dotnet build
* dotnet run 
3. Browse https://localhost:5001/ to access Swagger UI

### Furthur Improvements (These can be added if required)
* Add Authentication
* Unit tests
* Integration Tests

### Assumptions
* All properties of the Applicant except 'Hired' & 'Id' are mandotory to be set in relavant requests. (Since the requirement doesn't specify it clearly)



