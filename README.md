# SqlCommandExecutor
It is a .NET Framework 4.7.2 console basaed application to execute SQL commands, stored procedures, and batch queries dynamically with logging support.

---
<br />



## 📖 Overview  
The SqlCommandExecutor is a command-line tool for executing SQL queries, stored procedures, and batch commands. It provides a secure way to interact with databases using parameterized queries, supports logging, and allows multiple SQL commands in a single execution.

---
<br />



## 🚀 Features  
✅ Execute SQL Queries – Run SELECT, INSERT, UPDATE, DELETE queries. <br />
✅ Stored Procedure Execution – Call stored procedures with parameters. <br />
✅ Batch Query Execution – Execute multiple queries in one go. <br />
✅ Logging Mechanism – Store execution logs in a file. <br />
✅ Safe SQL Execution – Prevent SQL injection with parameterized queries. <br />

---
<br />



## 📌 Practical Use Cases
SqlCommandExecutor enhances reporting, data processing, security, and auditing in enterprise applications.

---
<br />



## 🛠 Tech stack
- C#
- MS SQL Server (T-SQL)
- ADO.NET

---
<br />



## 🛠 Prerequisites
- Visual Studio 2019 or later
- .NET Framework v4.7.2
- SQL Server (Local or Remote)
- A configured database

---
<br />



## Project structure
```
│── SqlCommandExecutor\
    │── bin\
    │── obj\
    │── Properties\
    │── App.config
    │── Program.cs
    │── SqlCommandExecutor.cs
    │── LogManager.cs
    │── SqlCommandExecutor.csproj
    │── SqlCommandExecutor.sln
    
│── script.sql
│── Readme.md
```

---
<br />



## 📥 Installation
1️⃣ Clone the repository.
  ```
  git clone https://github.com/yourusername/SqlCommandExecutor.git
  cd SqlCommandExecutor
  ```
2️⃣ Launch Visual Studio and open SqlCommandExecutor.sln. <br />
3️⃣ Modify the app.config file to set up your database connection. <br />
4️⃣ Build the application. <br />

---
<br />



## 💡 Future Enhancements
🔹 Web API Integration - Allows external applications to send SQL requests via HTTP endpoints. <br />
🔹 Implement user authentication and role-based access for query execution. <br />
🔹 Modify the application to execute long-running SQL operations asynchronously using async/await. <br />
🔹 Implement query result caching using Redis or MemoryCache for performance optimization. <br />

---
<br />



## 🤝 Contribution
Want to improve this project? Follow these steps:

1️⃣ Fork the repository. <br />
2️⃣ Create a new feature branch (git checkout -b feature-name). <br />
3️⃣ Commit your changes (git commit -m "Added new feature"). <br />
4️⃣ Push to the branch (git push origin feature-name). <br />
5️⃣ Create a pull request 

---
<br />
<br />




















