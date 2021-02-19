## API-InternshipExercise
This is an exercised proposed for practice **.NET**. 
The arquitecture is really simple, it ´s divided into 3 folders: Business Logic, Database and Controllers.

#### BusinessLogic 
Has the class with all the logic and the interface
#### Controllers
This one handles incoming HTTP requests and send response back to the caller. Inside this folder, i have included a file called DTOModels, using the DTO pattern. 
#### Database
This one has a database created in agreement to the class Workshop. I have created an Enum for the status.

##### Limitations
For time, I did not include exceptions, logs and middleware.
