
-- Switch to the system (aka master) database
USE master;
GO

-- Delete the DemoDB Database (IF EXISTS)
IF EXISTS(select * from sys.databases where name='FitnessDB')
DROP DATABASE FitnessDB;
GO

-- Create a new DemoDB Database
CREATE DATABASE FitnessDB;
GO

-- Switch to the DemoDB Database
USE FitnessDB
GO

BEGIN TRANSACTION;

CREATE TABLE users
(
	id			int			identity(10000,1),
	username	varchar(50)	not null,
	password	varchar(50)	not null,
	salt		varchar(50)	not null,
	role		varchar(50)	default('user'),

	constraint pk_users primary key (id)
);


COMMIT TRANSACTION;