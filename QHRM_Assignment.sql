use sahildb

CREATE TABLE Products (
   id INT PRIMARY KEY IDENTITY(1,1),
   ProdName NVARCHAR(100),
   Description NVARCHAR(255),
   CreatedAt DATETIME DEFAULT GETDATE()
);

drop table Products

select  * from Products