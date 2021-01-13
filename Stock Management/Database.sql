
create database stock


create table companies
(
companyId int identity(1,1) primary key,
companyName varchar(100) not null
)

create table categories
(
categoryId int identity(1,1) primary key,
categoryName varchar(50) not null
)

create table items
(
itemId int identity(1,1) primary key,
itemName varchar(50) not null,
reorderLevel int not null,
availableQuantity int,
companyId int foreign key references companies(companyId),
categoryId int foreign key references categories(categoryId)
)

create table stockIn
(
stockInId int identity(1,1),
itemId int foreign key references items(itemId),
date date,
stockInQuantity int not null
)

create table stockOut
(
itemId int foreign key references items(itemId),
date date,
stockOutQuantity int not null,
stockOutType varchar (10)
)
