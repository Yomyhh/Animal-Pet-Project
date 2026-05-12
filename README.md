# 🐾 Pet Adoption System

A simple and clean ASP.NET Core MVC application for managing pet adoption processes.

The system allows users to browse pets available for adoption and provides authenticated users with the ability to manage pet records through basic CRUD operations.

---

## 📖 Overview

This project was built using **ASP.NET Core MVC** following the **3-Tier Architecture** approach to separate responsibilities between:

- Presentation Layer
- Business Logic Layer
- Data Access Layer

The application also implements **Authentication & Authorization** using ASP.NET Core Identity.

---

# ✨ Features

## 🐶 Pet Management
- View all pets
- View pet details
- Add new pets
- Edit pet information
- Delete pets

## 🔐 Authentication
- User Registration
- User Login
- User Logout
- Authorization using Identity

## 🎨 UI
- Responsive design
- Simple and user-friendly interface
- Bootstrap styling

---

# 🏗️ Project Architecture

## 1️⃣ Presentation Layer (PL)
Responsible for:
- MVC Controllers
- Views
- Razor Pages
- User Interface

---

## 2️⃣ Business Logic Layer (BL)
Responsible for:
- Business Logic
- DTOs
- Interfaces
- Services

---

## 3️⃣ Data Access Layer (DAL)
Responsible for:
- Database Access
- Repositories
- Entity Framework Core
- Models
- DbContext

---

# 🛠️ Technologies Used

| Technology | Purpose |
|---|---|
| ASP.NET Core MVC | Web Application Framework |
| Entity Framework Core | ORM |
| SQL Server | Database |
| ASP.NET Core Identity | Authentication & Authorization |
| Bootstrap | Front-End Styling |
| C# | Programming Language |

---

# 📂 Solution Structure

```plaintext
PetAdoption/
│
├── PetAdoption.PL      --> Presentation Layer
├── PetAdoption.BL      --> Business Logic Layer
├── PetAdoption.DAL     --> Data Access Layer
