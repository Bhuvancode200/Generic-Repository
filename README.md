# 🏰 Generic Repository Pattern in ASP.NET Core





## 📌 Project Overview

This project demonstrates a **Generic Repository Pattern** in **ASP.NET Core** using **Entity Framework Core**. It provides a structured and reusable way to interact with databases while maintaining clean architecture principles.

---

## ✨ Features

👉 Implements **CRUD operations** using a generic repository\
👉 Uses **Dependency Injection** for database access\
👉 **Follows clean architecture** best practices\
👉 Works with **ASP.NET Core Web API**\
👉 Uses **Entity Framework Core** for ORM

---

## 🛠️ Technologies Used

- **C#** (ASP.NET Core 7/8)
- **Entity Framework Core**
- **SQL Server**
- **Dependency Injection**
- **Swagger (API Documentation)**
- **RESTful API Principles**
- **Git & GitHub for Version Control**

---

## 📂 Project Structure

```
Generic-Repository/
│── Controllers/
│   ├── ProductWithGenericRepoController.cs
│
│── Data/
│   ├── MyDbContext.cs
│
│── Entity/
│   ├── Product.cs
│   ├── Order.cs
│   ├── Blog.cs
│
│── Repository/
│   ├── IRepository.cs
│   ├── Repository.cs
│
│── Migrations/
│── Program.cs
│── appsettings.json
│── README.md
```

---

## 🚀 Getting Started

### 🔹 1️⃣ Clone the Repository

```sh
git clone https://github.com/Bhuvancode200/Generic-Repository.git
cd Generic-Repository
```

### 🔹 2️⃣ Configure Database Connection

- Open `appsettings.json`
- Update the **SQL Server connection string**:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=GenericRepoDB;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```

### 🔹 3️⃣ Apply Migrations & Update Database

Run the following commands in the terminal:

```sh
dotnet ef database update
```

### 🔹 4️⃣ Run the Application

```sh
dotnet run
```

🚀 The API should now be running at **`https://localhost:5001/api/ProductWithGenericRepo`**

---

## 🗒️ API Endpoints

### 🔹 Get All Products

```http
GET /api/ProductWithGenericRepo
```

### 🔹 Get Product by ID

```http
GET /api/ProductWithGenericRepo/{id}
```

### 🔹 Add a New Product

```http
POST /api/ProductWithGenericRepo
Content-Type: application/json

{
  "productName": "Laptop",
  "price": 1200
}
```

### 🔹 Update Product

```http
PUT /api/ProductWithGenericRepo/{id}
Content-Type: application/json

{
  "productName": "Updated Laptop",
  "price": 1300
}
```

### 🔹 Delete Product

```http
DELETE /api/ProductWithGenericRepo/{id}
```

---

## 🛠️ Contributing

Contributions are welcome! If you’d like to improve this project:

1. **Fork the repository**
2. **Create a feature branch** (`git checkout -b feature-branch`)
3. **Commit your changes** (`git commit -m "Added a new feature"`)
4. **Push to GitHub** (`git push origin feature-branch`)
5. **Create a pull request**

---

## 📝 License

This project is **open-source** and available under the **MIT License**.

---

## 💌 Contact

👨‍💼 **Author:** Bhushan Kumar Yadav\
🌐 **GitHub:** [Bhuvancode200](https://github.com/Bhuvancode200)\
📧 **Email:** [kumarbhuvan718@gmail.com](mailto\:kumarbhuvan718@gmail.com)

💡 If you found this project useful, **give it a star ⭐** on GitHub!

---

