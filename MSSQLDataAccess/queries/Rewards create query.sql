use Rewards
go

CREATE TABLE [Person] (
	id int NOT NULL,
	first_name varchar(50) NOT NULL,
	last_name varchar(50) NOT NULL,
	birth_date date NOT NULL,
	age int NOT NULL,
  CONSTRAINT [PK_PERSON] PRIMARY KEY CLUSTERED
  (
  [id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Address] (
	id int NOT NULL,
	city varchar(50) NOT NULL,
	street varchar(50) NOT NULL,
	house_number varchar(50) NOT NULL,
  CONSTRAINT [PK_ADDRESS] PRIMARY KEY CLUSTERED
  (
  [id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Medal] (
	id int NOT NULL,
	name varchar(50) NOT NULL,
	material int NOT NULL,
  CONSTRAINT [PK_MEDAL] PRIMARY KEY CLUSTERED
  (
  [id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Material] (
	id int NOT NULL,
	name varchar(50) NOT NULL,
  CONSTRAINT [PK_MATERIAL] PRIMARY KEY CLUSTERED
  (
  [id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [PersonMedal] (
	person int NOT NULL,
	medal int NOT NULL,
  CONSTRAINT [PK_PERSONMEDAL] PRIMARY KEY CLUSTERED
  (
  [person] ASC, [medal] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [PersonAddress] (
	person int NOT NULL,
	address int NOT NULL,
  CONSTRAINT [PK_PERSONADDRESS] PRIMARY KEY CLUSTERED
  (
  [person] ASC, [address] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO

ALTER TABLE [Medal] WITH CHECK ADD CONSTRAINT [Medal_fk0] FOREIGN KEY ([material]) REFERENCES [Material]([id])
ON UPDATE CASCADE
GO
ALTER TABLE [Medal] CHECK CONSTRAINT [Medal_fk0]
GO

ALTER TABLE [PersonMedal] WITH CHECK ADD CONSTRAINT [PersonMedal_fk0] FOREIGN KEY ([person]) REFERENCES [Person]([id])
ON UPDATE CASCADE
GO
ALTER TABLE [PersonMedal] CHECK CONSTRAINT [PersonMedal_fk0]
GO
ALTER TABLE [PersonMedal] WITH CHECK ADD CONSTRAINT [PersonMedal_fk1] FOREIGN KEY ([medal]) REFERENCES [Medal]([id])
ON UPDATE CASCADE
GO
ALTER TABLE [PersonMedal] CHECK CONSTRAINT [PersonMedal_fk1]
GO

ALTER TABLE [PersonAddress] WITH CHECK ADD CONSTRAINT [PersonAddress_fk0] FOREIGN KEY ([person]) REFERENCES [Person]([id])
ON UPDATE CASCADE
GO
ALTER TABLE [PersonAddress] CHECK CONSTRAINT [PersonAddress_fk0]
GO
ALTER TABLE [PersonAddress] WITH CHECK ADD CONSTRAINT [PersonAddress_fk1] FOREIGN KEY ([address]) REFERENCES [Address]([id])
ON UPDATE CASCADE
GO
ALTER TABLE [PersonAddress] CHECK CONSTRAINT [PersonAddress_fk1]
GO
