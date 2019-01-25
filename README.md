# Code Challenge
Code Challenge: creating a RESTful service consuming SpaceX's API. 

This code challenge was completed using ASP.Net Core 2.1 and exposes the data from SpaceX's Launch Data API. 
The main goal of the challenge was to create a RESTful API that would expose the data from SpaceX's API.
However, the program would have to be designed in a way so that, if the data source were to be changed to a database, then the application would still function the same without much, if any, refactoring. I believe that I have completed this challenge accordingly. Assuming that the database provided shares the same context of my application, the only necessary changes would be inputting the connection string and removing a few comment tags. This is possible using Dependency Injection and a bit of abstraction. 

## Necessary Changes

1. Input connection string:

![appsettings](https://user-images.githubusercontent.com/22749214/51726986-8fd28100-202f-11e9-9499-7cf6f28922f8.PNG)


2. Remove comments tag to allow the DbContext to be injected:

![di](https://user-images.githubusercontent.com/22749214/51727047-cb6d4b00-202f-11e9-9cff-9683b916c501.PNG)

3. Remove comment tag to inject into the API's constructor:

![parameter](https://user-images.githubusercontent.com/22749214/51727097-f788cc00-202f-11e9-9903-f13af7f46e6f.PNG)

4. Remove the comment tag to set the class variable:

![setting](https://user-images.githubusercontent.com/22749214/51727108-0cfdf600-2030-11e9-8148-84ade64c6971.PNG)

After these small changes, the solution will continue to function as if no changes were made. 
