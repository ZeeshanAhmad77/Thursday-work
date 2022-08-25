USE master
DROP DATABASE IF EXISTS penaultyCalculator_4060;
CREATE DATABASE penaultyCalculator_4060;
USE penaultyCalculator_4060

--Create Tables In databse
--Create Country Table

CREATE TABLE country(
    [country_id] [int] IDENTITY(1,1) PRIMARY KEY,
    [name] [varchar](20) unique  NOT NULL,
    [currency] [varchar](20) NOT NULL,
	[special_tax] decimal NOT NULL,
	[due_date_charges] decimal NOT NULL
  
);
--Create Public Holidays Table
CREATE TABLE PublicHolidays(
    [holiday_id] [int] IDENTITY(1,1) PRIMARY KEY,
    [holiday_date] [date] NOT NULL,
    [holiday_name] [varchar](100) NOT NULL,
	[country_Id] int foreign key REFERENCES country(country_Id)
);
--Create Weekends table
CREATE TABLE weekendDays(
    [Pk_id] [int] IDENTITY(1,1) PRIMARY KEY,
    [name_of_day] varchar(20) NOT NULL,
	country_Id int foreign key references Country(Country_Id)
);
--Create Store Procedure Used in the Program

--Create spGetCountry store Procedure
DROP PROCEDURE IF EXISTS spGetCountry
GO
create PROCEDURE spGetCountry
AS
BEGIN
    select country_id,[name] from country
END
GO

--Create spGetCountrybyId store Procedure

DROP PROCEDURE IF EXISTS spGetCountrybyId
GO
create PROCEDURE spGetCountrybyId @country_id int
AS
BEGIN
    SELECT * FROM country WHERE country_id = @country_id
END
GO


--Create spGetHolidaysbyId store Procedure

DROP PROCEDURE IF EXISTS spGetHolidaysbyId
GO
create PROCEDURE  spGetHolidaysbyId @country_id int
AS
BEGIN
    select holiday_date  from PublicHolidays WHERE country_id = @country_id
END
GO

--Create spGetWeekedDaysById store Procedure

DROP PROCEDURE IF EXISTS spGetWeekedDaysById
GO
create PROCEDURE spGetWeekedDaysById  @country_id int
AS
BEGIN
    select name_of_day from weekendDays WHERE country_id = @country_id
END
GO

--Insert Values in the Database

--Insert values in country table
INSERT INTO country( [name],[currency],[special_tax],[due_date_charges])
VALUES ('pakistan','PKR','0.00','50.00'),('UAE','AED','8.00','50.00');


--Insert Values in holiday Table
-- public holidays of Pakistan 
INSERT INTO PublicHolidays( [holiday_name] ,[holiday_date],[country_Id])
VALUES ('New Year Day','2022-01-01','1');
INSERT INTO PublicHolidays( [holiday_name] ,[holiday_date],[country_Id])
VALUES ('Kashmir Day','2022-02-05','1');
INSERT INTO PublicHolidays( [holiday_name] ,[holiday_date],[country_Id])
VALUES ('Shab e-Meraj','2022-03-01','1');
INSERT INTO PublicHolidays( [holiday_name] ,[holiday_date],[country_Id])
VALUES ('Shab e-Barat','2022-03-18','1');
INSERT INTO PublicHolidays( [holiday_name] ,[holiday_date],[country_Id])
VALUES ('Pakistan Day','2022-03-23','1');
INSERT INTO PublicHolidays( [holiday_name] ,[holiday_date],[country_Id])
VALUES ('Labour Day','2022-05-01','1');
INSERT INTO PublicHolidays( [holiday_name] ,[holiday_date],[country_Id])
VALUES ('Eid-ul-Fitr Holiday','2022-05-02','1');
INSERT INTO PublicHolidays( [holiday_name] ,[holiday_date],[country_Id])
VALUES ('Eid-ul-Fitr Holiday','2022-05-03','1');
INSERT INTO PublicHolidays( [holiday_name] ,[holiday_date],[country_Id])
VALUES ('Eid-ul-Fitr Holiday','2022-05-04','1');
INSERT INTO PublicHolidays( [holiday_name] ,[holiday_date],[country_Id])
VALUES ('Eid-ul-Fitr Holiday','2022-05-05','1');
INSERT INTO PublicHolidays( [holiday_name] ,[holiday_date],[country_Id])
VALUES ('Eid al-Adha','2022-07-08','1');
INSERT INTO PublicHolidays( [holiday_name] ,[holiday_date],[country_Id])
VALUES ('Eid al-Adha','2022-07-09','1');
INSERT INTO PublicHolidays( [holiday_name] ,[holiday_date],[country_Id])
VALUES ('Eid al-Adha','2022-07-10','1');
INSERT INTO PublicHolidays( [holiday_name] ,[holiday_date],[country_Id])
VALUES ('Eid al-Adha','2022-07-11','1');
INSERT INTO PublicHolidays( [holiday_name] ,[holiday_date],[country_Id])
VALUES ('Eid al-Adha','2022-07-12','1');
INSERT INTO PublicHolidays( [holiday_name] ,[holiday_date],[country_Id])
VALUES ('Ashura Holidays','2022-08-08','1');
INSERT INTO PublicHolidays( [holiday_name] ,[holiday_date],[country_Id])
VALUES ('Ashura Holidays','2022-08-09','1');
INSERT INTO PublicHolidays( [holiday_name] ,[holiday_date],[country_Id])
VALUES ('Independace day','2022-08-14','1');
INSERT INTO PublicHolidays( [holiday_name] ,[holiday_date],[country_Id])
VALUES ('Defence Day','2022-09-06','1');
INSERT INTO PublicHolidays( [holiday_name] ,[holiday_date],[country_Id])
VALUES ('Chehlum','2022-09-17','1');
INSERT INTO PublicHolidays( [holiday_name] ,[holiday_date],[country_Id])
VALUES ('Eid Milad un-Nabi','2022-10-09','1');
INSERT INTO PublicHolidays( [holiday_name] ,[holiday_date],[country_Id])
VALUES ('Iqbal Day','2022-11-09','1');
INSERT INTO PublicHolidays( [holiday_name] ,[holiday_date],[country_Id])
VALUES ('Quaid-e-Azam Day','2022-12-25','1');
INSERT INTO PublicHolidays( [holiday_name] ,[holiday_date],[country_Id])
VALUES ('Eve of new Year','2022-12-31','1');

--Public Holidays of UAE
INSERT INTO PublicHolidays( [holiday_name] ,[holiday_date],[country_Id])
VALUES ('New Year Day','2022-01-01','2');
INSERT INTO PublicHolidays( [holiday_name] ,[holiday_date],[country_Id])
VALUES ('New Year Day Holiday','2022-01-02','2');
INSERT INTO PublicHolidays( [holiday_name] ,[holiday_date],[country_Id])
VALUES ('Leilat al-Meiraj','2022-03-01','2');
INSERT INTO PublicHolidays( [holiday_name] ,[holiday_date],[country_Id])
VALUES ('Ramadan Start','2022-04-02','2');
INSERT INTO PublicHolidays( [holiday_name] ,[holiday_date],[country_Id])
VALUES ('Eid al-Fitr Holiday','2022-04-30','2');
INSERT INTO PublicHolidays( [holiday_name] ,[holiday_date],[country_Id])
VALUES ('Eid al-Fitr Holiday','2022-05-01','2');
INSERT INTO PublicHolidays( [holiday_name] ,[holiday_date],[country_Id])
VALUES ('Eid al-Fitr Holiday','2022-05-02','2');
INSERT INTO PublicHolidays( [holiday_name] ,[holiday_date],[country_Id])
VALUES ('Eid al-Fitr Holiday','2022-05-03','2');
INSERT INTO PublicHolidays( [holiday_name] ,[holiday_date],[country_Id])
VALUES ('Eid al-Fitr Holiday','2022-05-04','2');
INSERT INTO PublicHolidays( [holiday_name] ,[holiday_date],[country_Id])
VALUES ('Eid al-Fitr Holiday','2022-05-05','2');
INSERT INTO PublicHolidays( [holiday_name] ,[holiday_date],[country_Id])
VALUES ('Eid al-Fitr Holiday','2022-05-06','2');
INSERT INTO PublicHolidays( [holiday_name] ,[holiday_date],[country_Id])
VALUES ('Public Holiday (Death of Sheikh Khalifa )','2022-05-14','2');
INSERT INTO PublicHolidays( [holiday_name] ,[holiday_date],[country_Id])
VALUES ('Public Holiday (Death of Sheikh Khalifa )','2022-05-15','2');
INSERT INTO PublicHolidays( [holiday_name] ,[holiday_date],[country_Id])
VALUES ('Public Holiday (Death of Sheikh Khalifa )','2022-05-16','2');
INSERT INTO PublicHolidays( [holiday_name] ,[holiday_date],[country_Id])
VALUES ('Hajj season begins','2022-06-30','2');
INSERT INTO PublicHolidays( [holiday_name] ,[holiday_date],[country_Id])
VALUES ('Arafat (Hajj) Day','2022-07-08','2');
INSERT INTO PublicHolidays( [holiday_name] ,[holiday_date],[country_Id])
VALUES ('Eid al-Adha','2022-07-09','2');
INSERT INTO PublicHolidays( [holiday_name] ,[holiday_date],[country_Id])
VALUES ('Eid al-Adha','2022-07-10','2');
INSERT INTO PublicHolidays( [holiday_name] ,[holiday_date],[country_Id])
VALUES ('Eid al-Adha','2022-07-11','2');
INSERT INTO PublicHolidays( [holiday_name] ,[holiday_date],[country_Id])
VALUES ('Mouloud','2022-10-08','2');
INSERT INTO PublicHolidays( [holiday_name] ,[holiday_date],[country_Id])
VALUES ('Commemoration Day','2022-12-01','2');
INSERT INTO PublicHolidays( [holiday_name] ,[holiday_date],[country_Id])
VALUES ('National Day','2022-12-02','2');
INSERT INTO PublicHolidays( [holiday_name] ,[holiday_date],[country_Id])
VALUES ('New Year Eve','2022-12-31','2');

--Insert values in the wekend table
INSERT INTO weekendDays( [name_of_day], country_Id)
VALUES
('saturday', 2)
,('friday', 2)
INSERT INTO weekendDays( [name_of_day], country_Id)
VALUES
('saturday', 1)
,('sunday', 1)


select * from country
select * from PublicHolidays
select * from weekendDays

EXEC spGetCountry 
EXEC spGetCountrybyId @country_id = 1
EXEC spGetHolidaysbyId @country_id = 2
EXEC spGetWeekedDaysById @country_id = 1
