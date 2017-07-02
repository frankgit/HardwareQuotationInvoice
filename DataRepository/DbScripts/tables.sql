create table ComputerCategory(
	Id INTEGER PRIMARY KEY   AUTOINCREMENT, 
	Name text not null,
	OrderPriorityId int not null
);

Create table HardwareType(
	Id INTEGER PRIMARY KEY   AUTOINCREMENT, 
	CategoryId int not null,
	Name text not null,
	ConfigType int not null,
	OrderPriorityId int not null,
	FOREIGN KEY(CategoryId) REFERENCES ComputerCategory(id)
);

Create table Hardware(
	Id INTEGER PRIMARY KEY   AUTOINCREMENT, 
	HardwareTypeId int not null,
	Name text not null,
	Price REAL not null,
	OrderPriorityId int not null,
	FOREIGN KEY(HardwareTypeId) REFERENCES HardwareType(id)
);