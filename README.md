# ToDoList
# Usage
git clone https://github.com/abdennour20/ToDoListBack.git
Replace DESKTOP-4U7CQE2\\SQLEXPRESS with your local machine name. Navigate to the 'ToDoList.API' project directory and open 'appsettings.json'. Update the Default connection 
"Default": "Server=(your_local_machine); Database=TODOLIST; Trusted_Connection=True; TrustServerCertificate=True;"
dotnet ef migrations add migration_name
dotnet ef database update 
dotnet run 


  
  

