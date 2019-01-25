# Code Challenge
Code Challenge: creating a RESTful service consuming SpaceX's API. 

This code challenge was completed using ASP.Net Core 2.1 and exposes the data from SpaceX's Launch Data API. 
The main goal of the challenge was to create a RESTful API that would expose the data from SpaceX's API.
However, the program would have to be designed in a way so that, if the data source were to be changed to a database, then the application would still function the same without much, if any, refactoring. I believe that I have completed this challenge accordingly. Assuming that the database provided shares the same context of my application, the only necessary changes would be inputting the connection string and removing a few comment tags. This is possible using Dependency Injection and a bit of abstraction. 

## Necessary Changes

1. Input connection string:

2. Remove comment tag to allow the DbContext to be injected:

3. Remove comment tag to inject into the API's constructor:

4. Remove the comment tag to set the class variable:

After these small changes, the solution will continue to function as if no changes were made. 
