
# Crud App
Application is all about creating, reading, updating, and deleting the user. the first user runs the application and shows the user on the top of the page in the table below the table there is a button when the button is pressed the user shows the form to input the user data. After completing the form user need to submit the data and finally, the data show in the above table. 


## Documentation

# Solution 
In this section, I explain the solution of the project.
Firstly, the User opens the application on the browser where the user shows the table at the top and below the table, there is a Adduser button when the button is pressed there is a form shown below the button. The form is used to get the user information from the user. The user fills in the user data and submits then it shows in the above table. There is also an Edit and delete button in the table. The edit button is used to edit the user data and the delete button is used to delete the user data from the table.

All the above data are stored in the database. We can get and post the data in the database so that our data can access at any time. This application is a single-page application all the actors perform on single page.

# methods in controller

The Index methods in the controller get all the users to form the database. These methods call IUserSrevices which return UserDto Data. IUserSrevices Implements UserServices which Implements logic to get the user data from the database and return the data to the Index methods. Index methods last return the data to the view.


The Create method is used to create and edit the user. It takes UserDto type data from the front end. It checks whether the model is valid or not if the model is valid then it calls the CreateUser in IUserSrevices which Implements UserServices otherwise it returns the view with the user value that is come from UserServices class. CreateUser first checks if the id is greater than 0 then it edits the user data otherwise it creates new user in the database. 

The EditUser method is used to get the data to the form when the edit button is pressed. It take the int Id as a  parameter. This method also call GetUserById from UserServices class. This method return UserDto types which are get from the database. Finally, EditUser return to the view with the userDto type data and show data in the page. 


The DeleteUser is used to delete the user data. It takes int Id as a parameter. This method first checks the id is not equal to null. If it is true then it calls DeleteById methods from IUserSrevices which Implements by UserServices. DeleteById first searches there is an id that is passed by the controller class. If it finds it is not null then DeleteById methods remove the data from the database and redirect to the index page. 





 

## Authors

- [@Shyam Sundar Nepal](https://github.com/shyamnepal/Coding-test)


## 🚀 About Me
I'm a backend developer enthusiastic to learn new technology and work with group of people and share idea and knowledge. I am Interested in C# programming language. 
## Tech Stack

**Client:** cshtml, CSS, JavaScript 

**Server:** ASP.NET core MVC
## Run Locally

Clone the project

```bash
  git clone git@github.com:shyamnepal/CrudApp.git
```

Go to the project directory

```bash
  cd cd CrudApp/CrudeApp/
```

Install dependencies

```bash
  dotnet run
```



