
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
	user_id		int			identity(10000,1),
	username	varchar(50)	not null,
	password	varchar(50)	not null,
	salt		varchar(50)	not null,
	role		varchar(50)	default('user'),

	constraint pk_user primary key (user_id)
);
CREATE TABLE profiles
(
	profile_id		int				identity(10000,1),
	birth_date		date			not null,
	current_weight	int				not null,
	goal_weight		int				not	null,
	height			int				not null,
	profile_picture	varchar(200)	not null,
	user_name		varchar(200)	not null unique,
	
	

	constraint pk_profile primary key (profile_id),
	

);
CREATE TABLE meals
(
	meal_id				int				identity(1000,1),
	fdc_id				int				not null,
	food_name			varchar(200)	not null,
	consumption_date	datetime		not null,
	servings			float			not null,
	meal_type			varchar(50)		not null,
	food_calories		int				not null,
	total_calories		int				not null,
	user_name			varchar(200)	not null

	constraint pk_meal_id primary key (meal_id),

);

INSERT INTO users VALUES ('Admin', 'jUE98uhvS5tdIlxRsmz1W7/Qaqo=', '9CWPUTvXqQ4=', 'Admin') 

COMMIT TRANSACTION;

--ALTER TABLE profiles ADD FOREIGN KEY (id) REFERENCES users(id)
--ALTER TABLE profiles
--ADD CONSTRAINT FK_profiles_id
--FOREIGN KEY(profiles_id)
--REFERENCES users (users_id);

begin transaction
ALTER TABLE profiles DROP COLUMN display_name

rollback
