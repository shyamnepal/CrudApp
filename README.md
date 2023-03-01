
# Crud App
Application is all about creating, reading, updating, and deleting the user. the first user runs the application and shows the user on the top of the page in the table below the table there is a button when the button is pressed the user shows the form to input the user data. After completing the form user need to submit the data and finally, the data show in the above table.

I have also host this samll application on web server which link is give below:\
[Click me ](https://shyam123.bsite.net/)

## Screenshot Of Application

![crude](https://user-images.githubusercontent.com/61022806/222177513-71b9fff3-3342-4f62-a14d-c19dce97fea9.PNG)

![crude1](https://user-images.githubusercontent.com/61022806/222177524-ed85b4d1-c77b-4239-aa3c-69ac7a40287d.PNG)


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

## SQL Query

Create database 

```bash
  Create database crude;
```

Create Users Table
```bash
  CREATE TABLE Users(
Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
UserName NVARCHAR(50) NOT NULL,
CreateTime DATETIME NOT NULL,
LastActiveTime DATETIME NOT NULL DEFAULT('2000-1-1 0:0:0')
);
```

Create Orders Table 
 ```bash
CREATE TABLE Orders(
Id INT NOT NULL,
UserId INT NOT NULL,
SupplyName NVARCHAR(50) NOT NULL,
UnitCost DECIMAL(18,2) NOT NULL,
UnitPrice DECIMAL(18,2) NOT NULL,
Markup DECIMAL(18,2) NOT NULL,
Qty int NOT NULL,
TotalPrice Decimal(18,2) NOT NULL,
CreateTime DATETIME NOT NULL,
CONSTRAINT FK_UserID FOREIGN KEY (UserId) REFERENCES Users (Id)
);
```

Insert Value in Users Table 

```bash
INSERT INTO Users(UserName,CreateTime,LastActiveTime) 
VALUES ('Shyam Sundar Nepal','2023-2-22 9:46:0','2023-2-21 9:46:0');
```

Insert Value in Orders Table 

```bash
INSERT INTO Orders(Id,UserId,SupplyName,UnitCost,UnitPrice,Markup,Qty,TotalPrice,CreateTime)
VALUES (1,1,'keyboard',700.43,900.43,200.00,2,1800.86,'2023-2-22 9:45:0');
```
update the UserName from Users Table
```bash
UPDATE Users 
SET UserName='Santosh Gajurel'
WHERE Id=1;
```

Update CreateTime from Orders table 
```bash
UPDATE Orders 
SET CreateTime='2021-1-1 0:0:0'
WHERE Id=1;
```
Query qty of items that are ordered by each user
```bash
SELECT * FROM Orders o 
JOIN  Users u
on o.UserId=u.Id;
```

Update LastActiveTime of each user with the CreateTime of the last order the user has created
``` bash
UPDATE Users  
SET Users.LastActiveTime=(
SELECT  MAX(O.CreateTime) AS Max_time
FROM Orders O
JOIN Users U
ON U.Id=O.UserId
group by O.UserId);
```



