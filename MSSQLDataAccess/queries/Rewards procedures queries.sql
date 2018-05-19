use Rewards
go

create procedure getAllPersons
as
	select p.id, p.first_name, p.last_name, p.birth_date, p.age from Person p
go
