
create database BIO;
use  bio;


CREATE TABLE BioData (
    ID CHAR(36) PRIMARY KEY DEFAULT (UUID()),
    FullName VARCHAR(50) NOT NULL,
    Age INT NOT NULL,
    Address TEXT,
    Email VARCHAR(100) UNIQUE NOT NULL,
    Password VARCHAR(255) NOT NULL,
    Salt VARCHAR(255) NOT NULL,
    Role ENUM('Admin', 'User') NOT NULL DEFAULT 'User'
);

show tables;

delimiter //
create procedure addUser(in p_name  varchar(50),in p_age  int,in p_address  text,in p_email  varchar(100),in p_password  varchar(255))
begin
insert into Biodata(FullName,Age,Address,Email,Password,Salt) values (p_name, p_age, p_address, p_email, p_password);
end //
delimiter ;


