
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
	user_name		varchar(200)	not null
	
	

	constraint pk_profile primary key (profile_id),
	

);

INSERT INTO users VALUES ('Admin', 'jUE98uhvS5tdIlxRsmz1W7/Qaqo=', '9CWPUTvXqQ4=', 'Admin') 

COMMIT TRANSACTION;

--ALTER TABLE profiles ADD FOREIGN KEY (id) REFERENCES users(id)
--ALTER TABLE profiles
--ADD CONSTRAINT FK_profiles_id
--FOREIGN KEY(profiles_id)
--REFERENCES users (users_id);

--begin transaction
--INSERT INTO users VALUES ('chaz', '123', '654', 'user');
--INSERT INTO profiles VALUES ('1990-07-26', 185, 285, 74, 'picture.jpg', 10003);

--rollback
