# GuestBook
A basic CRUD guest book which can write, edit, and delete messages. You can also reply to these messages.

## Installation
- To run this project, make sure you change the **Server name** in `appsettings.json` <br />
`Data Source=<Server_Name>`
- Update migrations within **Package Manager Console** by <br />
`Update-Database` <br />
Or .NET Core CLI <br />
```bash
dotnet ef database update
```
- Register to use the messages
- Enjoy :)

# Design Decisions
- **N-tier architecture** to divide the application into layers, for applying SoC, easy to reuse, easy to add new features, and achieve flexibilty
- **Repository pattern** to reduce the redundancy of logics, encapsulate the complex logics, and can change the persistence framework (e.g Dapper) easily to another in the future
- **Unit of Work** to coordinate between the different repositories, and transition between them from one place.
- **Configuration Layer** to control of all strings and configurations of database, validations, etc.
- **Dapper** for fast performance, and we have simple logics.

# Todos to improve
- Improve UI components through front-end frameworkd to achive more flexibilty in back-end
- Use **Singleton pattern** to control of all initialized model objects and static large configurations
- Divide the main view to multiple partial views, so, each partial view has the own API.

# Techniques
- .NET
- Dapper
- Fluent Validation

# Demo
[GuestBook](https://youtu.be/dWo25u4x93s)
