use Rewards
go

create procedure getAllPersons
as
	select p.id, p.first_name, p.last_name, p.birth_date, p.age from Person p
go

create procedure getAllMedals
as
	select medal.id, mat.name, medal.name from Medal medal
	join Material mat on medal.id = mat.id
go

create procedure getAllAddresses
as
	select a.id, a.city, a.street, a.house_number from [Address] a
go

create procedure getAllMaterials
as
	select m.id, m.name from Material m
go

create procedure addPerson 
@first_name varchar(50), 
@last_name varchar(50),
@birth_date date,
@age int,
@id int output
as
	insert into Person values(@first_name, @last_name, @birth_date, @age)
	set @id = SCOPE_IDENTITY()
go

create procedure addMedal
@name varchar(50), 
@material int,
@id int output
as
	insert into Medal values(@name, @material)
	set @id = SCOPE_IDENTITY()
go

create procedure addAddress
@city varchar(50), 
@street varchar(50),
@house_number varchar(50),
@id int output
as
	insert into Address values(@city, @street, @house_number)
	set @id = SCOPE_IDENTITY()
go

create procedure addMaterial
@name varchar(50),
@id int output
as
	insert into Material values(@name)
	set @id = SCOPE_IDENTITY()
go

create procedure addPersonAddress
@person int,
@address int
as
	insert into PersonAddress values(@person, @address)
go

create procedure addPersonMedal
@person int,
@medal int
as
	insert into PersonMedal values(@person, @medal)
go

create procedure getPersonMedals
@id int
as
	select medal.id, medal.name, mat.id, mat.name from Medal medal
	join Material mat on medal.material = mat.id
	join PersonMedal pm on pm.medal = medal.id
	join Person on pm.person = @id
go

create procedure getPersonAddresses
@id int
as
	select ad.id, ad.city, ad.street, ad.house_number from [Address] ad
	join PersonAddress pa on pa.[address] = ad.id
	join Person on pa.person = @id
go

create procedure getPersonById
@id int
as
	select p.id, p.first_name, p.last_name, p.birth_date, p.age from Person p
	where p.id = @id
go

create procedure getMedalById
@id int
as
	select m.id, m.name, mat.id, mat.name from Medal m
	join Material mat on m.id = mat.id
	where m.id = @id
go

create procedure getAddressById
@id int
as
	select ad.id, ad.city, ad.street, ad.house_number from Address ad
	where ad.id = @id
go

create procedure getMaterialById
@id int
as
	select mat.id, mat.name from Material mat
	where mat.id = @id
go

create procedure deletePersonById
@id int
as
	delete from PersonMedal where person = @id
	delete from PersonAddress where person = @id
	delete from Person where id = @id
go

create procedure deleteMedalById
@id int
as
	delete from PersonMedal where medal = @id
	delete from Medal where id = @id
go

create procedure deleteAddressById
@id int
as
	delete from PersonAddress where address = @id
	delete from Address where id = @id
go

create procedure deleteMaterialById
@id int
as
	delete from Material where id = @id
go