
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
