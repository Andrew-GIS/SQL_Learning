﻿CREATE DATABASE ComputerShop

CREATE TABLE Product(
maker VARCHAR(10) NOT NULL,
model VARCHAR(50) NOT NULL PRIMARY KEY,
type VARCHAR(50) NOT NULL)

CREATE TABLE PC(
code INT NOT NULL PRIMARY KEY,
model VARCHAR(50) NOT NULL,
speed SMALLINT NOT NULL,
ram SMALLINT NOT NULL,
hd REAL NOT NULL,
cd VARCHAR(10) NOT NULL,
price MONEY)

CREATE TABLE Laptop(
code INT NOT NULL PRIMARY KEY,
model VARCHAR(50) NOT NULL,
speed SMALLINT NOT NULL,
ram SMALLINT NOT NULL,
hd REAL NOT NULL,
price MONEY,
screen TINYINT NOT NULL)

CREATE TABLE Printer(
code INT NOT NULL PRIMARY KEY,
model VARCHAR(50) NOT NULL,
color CHAR(1) NOT NULL,
type VARCHAR(10) NOT NULL,
price MONEY)