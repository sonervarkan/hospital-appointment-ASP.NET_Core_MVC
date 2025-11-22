# Hospital MVC Management System

The **Hospital MVC Management System** is a web-based application built using ASP.NET Core MVC and Entity Framework Core.  
It allows administrators to manage **Departments**, **Doctors**, **Patients**, **Times**, and **Appointments** in a structured way.

---

## Features

- Add, list, and manage **Departments**
- Add, list, and manage **Doctors**
- Add, list, and manage **Patients**
- Add, list, and manage **Available Times**
- Create dynamic appointments with:
  - Department-based doctor filtering  
  - Real-time available time filtering  
  - Automatic patient creation  
- View full appointment details with relations:
  - Patient  
  - Doctor  
  - Department  
  - Date & Time  

---

## Technologies Used

- **ASP.NET Core MVC**
- **Entity Framework Core**
- **SQL Server**
- **Bootstrap 5**
- **jQuery & AJAX**
- **Razor Views**
- **C#**

---

## Project Structure

```
Hospital-MVC/
├── Controllers/
│   ├── AppointmentsController.cs
│   ├── DepartmentsController.cs
│   ├── DoctorsController.cs
│   ├── HomeController.cs
│   ├── PatientsController.cs
│   └── TimesController.cs
│
├── Data/
│   └── ApplicationDbContext.cs
│
├── Models/
│   ├── Entities/
│   │   ├── Departments.cs
│   │   ├── Doctors.cs
│   │   ├── Patients.cs
│   │   ├── Times.cs
│   │   └── Appointments.cs
│   ├── AppointmentsViewModel.cs
│   └── DoctorsViewModel.cs
│
├── Views/
│   ├── Appointments/
│   │   ├── add_appointment.cshtml
│   │   └── list_appointment.cshtml
│   ├── Departments/
│   │   ├── add_department.cshtml
│   │   └── list_department.cshtml
│   ├── Doctors/
│   │   ├── add_doctor.cshtml
│   │   └── list_doctor.cshtml
│   ├── Patients/
│   │   ├── add_patient.cshtml
│   │   └── list_patient.cshtml
│   ├── Times/
│   │   ├── add_time.cshtml
│   │   └── list_time.cshtml
│   ├── Shared/
│   │   └── _Layout.cshtml
│   ├── Home/
│   │   ├── Index.cshtml
│   │   └── Privacy.cshtml
│   └── _ViewImports.cshtml
│
├── wwwroot/
│   ├── css/
│   │   └── navbar.css
│   ├── js/
│   │   └── site.js
│   ├── lib/
│   └── favicon.ico
│
├── Program.cs
├── appsettings.json
└── README.md
```

---

## Installation & Setup

1. Clone the repository:

   git clone https://github.com/yourusername/hospital-mvc.git


2. Open the project in **Visual Studio** or **VS Code**.

3. Configure your SQL Server connection string inside:

   appsettings.json → "DefaultConnection"


4. Apply migrations (if necessary):

   dotnet ef database update


5. Run the application:

   dotnet run


6. Open the browser:

   https://localhost:5001


---

## How Appointments Work

When creating an appointment:

1. User selects a **department**  
2. Doctors belonging to that department load dynamically via AJAX  
3. User selects a **doctor**  
4. User selects a **date**  
5. System fetches available times:  
   - Excludes times already booked  
6. A new **patient** is created automatically from form inputs  
7. The appointment is saved in the database

---


## Contributing

1. Fork the repository  
2. Create a new feature branch:  

   git checkout -b feature/your-feature

3. Commit your changes:  

   git commit -m "Add new feature"

4. Push the branch:  

   git push origin feature/your-feature

5. Create a pull request

---

## License

This project currently has **no license**.  
You may add one if you plan to publish or distribute the application.
