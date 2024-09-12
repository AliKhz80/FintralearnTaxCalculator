# FintralearnTaxCalculator

FINTRALEARN TEST PROJECT
Tax Calculator

JULY 19, 2024
ALI KHANZADEH

Technical information about project:

In this project,a hexagonal architecture has been used for the design of the project structure, which consists of four layers named Domain, Infrastructure, Application, and Web. The domain layer has no connection to any of the other layers and is completely separate. However, the application layer is connected to the domain layer, and the infrastructure layer is connected to both the domain and application layers and the web layer is connected to both the application and infrastructure layers, and also used CQRS ,Repository pattern,minimal Api and Fluentvalidation.

The reason for using hexagonal architecture is because the logic layer of the project is separate from all other layers, it can easily be changed or modified without affecting other parts of the system. This modular approach allows for greater flexibility and scalability in development and maintenance.
In this project, Microsoft SQL Server has been used for the database structure, which includes four tables named Plate, VehicleTax, and Vehicle. The Code First approach has been utilized for designing the database and tables in this project.

Business logic issues:
I used static datetimes in VehicleTaxCalculatorCommandHandler class for calculate tax in 2013.
I understand that it is not correct to use static date times, but I was told in the Assignment file that it is okay to use old date times.











