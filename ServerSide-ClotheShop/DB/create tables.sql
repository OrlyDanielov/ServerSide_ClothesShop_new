
--create tables
create table Clothe
(
--identity(1,1)
number int primary key, 
details nvarchar(30) not null,
cosumer_price float check(cosumer_price > 0)not null,
cost_price float check(cost_price > 0) not null,
amount_in_stock int check(amount_in_stock >0)not null,
is_active bit not null,
category nvarchar(30) not null check (category = 'short shirts' OR category ='long shirts' OR category = 'jackets' OR category = 'dresses' OR category = 'skirts'),
img_url nvarchar(100) not null
)

create table Client
(
id int primary key,
name nvarchar(50) not null,
password nvarchar(30) not null,
is_admin bit
)


create table Purchase
(
client_id int foreign key references Client(id) not null,
clothe_number int foreign key references Clothe(number) not null,
purchase_date  datetime default(getdate()) not null,
amount int not null,
purchase_id int identity(1,1) primary key
)
