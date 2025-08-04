# 📝 Assignment Planner

A single-page web application built with **Blazor** to help students manage their assignments efficiently, track progress, and maintain visibility over their semester workload.

---

## 🚀 Features

* **User Authentication**
  Register and log in securely with individual user accounts.

* **Dashboard Overview**
  An intuitive calendar interface acts as the central hub for task management, enhanced with:

  * Modals for task creation and editing
  * Quick daily overview of assignments
  * Sidebar navigation with:

    * Upcoming & completed tasks
    * Subject-based breakdown with percentage tracking
    * Account information and settings

* **Task Management**

  * Create, edit, or delete tasks by clicking on calendar days
  * Filter and search tasks by subject, assignment name, or due date
  * Assign tasks a percentage value to track subject progress

* **Subject Tracking**

  * View all tasks grouped by subject
  * Monitor completion percentage for each subject

* **Responsive & Interactive UI**

  * Built as a single-page app with modals and reusable components
  * Minimal page reloads for a seamless experience

---

## 🛠️ Technologies Used

### Frontend & Framework:

* [Blazor WebAssembly](https://dotnet.microsoft.com/en-us/apps/aspnet/web-apps/blazor) (.NET 8)
* HTML/CSS for prototyping

### Backend & Data:

* **Entity Framework Core** 8.0.10

  * `Microsoft.EntityFrameworkCore.SqlServer`
  * `Microsoft.EntityFrameworkCore.Sqlite`
  * `Microsoft.EntityFrameworkCore.Tools`
  * `Microsoft.EntityFrameworkCore.Design`

### UI Structure:

* Component-based layout with modals for task and account management
* Sidebar navigation with dynamically loaded content

---

## 🧱 Development Approach

### Planning & Design

* Began with **data modelling** to define core entities and relationships
* Created an **ERD** to guide database integration and ensure scalability

### UI Prototyping

* Initially built with basic HTML/CSS to quickly iterate layout ideas
* Transitioned into Blazor components for modularity and code reuse

### Implementation

* Developed the application using Blazor’s component-based architecture
* Connected UI with backend using Entity Framework and SQLite
* Implemented form validation, error handling, and dynamic UI updates

### Iteration

* Refined codebase through modularization and refactoring
* Added support for user account management (update/delete)
* Ensured responsiveness and ease of use through testing and feedback

---

## 📂 Folder Structure (Optional)

```
Assignment_2/
├── Client/                  # Blazor WebAssembly frontend
├── Server/                  # Backend logic and EF Core setup
├── Shared/                  # Shared models and DTOs
├── Migrations/              # EF Core migration history
├── Data/Database/           # SQLite or SQL Server DB
├── wwwroot/                 # Static assets
└── .vs/, bin/, obj/         # Ignored build and IDE folders
```

---

## 📌 Why Blazor?

Originally considered **Windows Forms**, but Blazor was selected due to:

* Modern, web-first capabilities
* Component-based architecture
* Cross-platform support
* Seamless integration of C# in frontend and backend logic

---

## 🧪 Future Improvements

* Notification/reminder system for upcoming tasks
* Subject analytics dashboard
* Dark mode / theming options
* Drag-and-drop task scheduling

---

## 📸 UI Preview (If you're including screenshots)

> *(Insert images or links to screenshots here showing the dashboard, calendar modal, sidebar, etc.)*

---

## 🧾 License

This project was built for educational purposes as part of **Assessment Task 2** and is not currently licensed for commercial use.

---

Let me know if you want to include **setup instructions**, **screenshots**, or a **demo link** — I can update the README accordingly.
