﻿--
-- Target: Microsoft SQL Server 
-- Syntax: isql /Uuser /Ppassword /Sserver -i\path\filename.sql
-- Date  : Dec 09 2018 14:41
-- Script Generated by Database Design Studio 2.21.3 
--


--
-- Select Database: 'db_name'
--
USE db_name
GO
 
IF DB_NAME() = 'db_name'
    RAISERROR('''db_name'' DATABASE CONTEXT NOW IN USE.',1,1)
ELSE
    RAISERROR('ERROR IN BATCH FILE, ''USE db_name'' FAILED!  KILLING THE SPID NOW.',22,127) WITH LOG
 
GO
EXECUTE SP_DBOPTION 'db_name' ,'TRUNC. LOG ON CHKPT.' ,'TRUE'
GO

--
-- Create Table    : 'Prosumer'   
-- ProsumerId      :  
-- SmartEnhedId    :  
--
CREATE TABLE Prosumer (
    ProsumerId     BIGINT IDENTITY(1,1) NOT NULL,
    SmartEnhedId   BIGINT NOT NULL,
CONSTRAINT pk_Prosumer PRIMARY KEY CLUSTERED (ProsumerId))
GO

--
-- Create Table    : 'PersonAntal'   
-- PersonAntalId   :  
-- AntalVoksne     :  
-- ProsumerId      :  (references Prosumer.ProsumerId)
--
CREATE TABLE PersonAntal (
    PersonAntalId  BIGINT IDENTITY(1,1) NOT NULL,
    AntalVoksne    INT NOT NULL,
    ProsumerId     BIGINT NULL,
CONSTRAINT pk_PersonAntal PRIMARY KEY CLUSTERED (PersonAntalId),
CONSTRAINT fk_PersonAntal FOREIGN KEY (ProsumerId)
    REFERENCES Prosumer (ProsumerId)
    ON UPDATE CASCADE)
GO

--
-- Create Table    : 'Forbrug'   
-- ForbrugId       :  
-- AarligkWh       :  
-- Kvartal1kWh     :  
-- Kvartal2kWh     :  
-- Kvartal3kWh     :  
-- Kvartal4kWh     :  
-- Aarstal         :  
-- ProsumerId      :  (references Prosumer.ProsumerId)
--
CREATE TABLE Forbrug (
    ForbrugId      BIGINT IDENTITY(1,1) NOT NULL,
    AarligkWh      INT NOT NULL,
    Kvartal1kWh    INT NULL,
    Kvartal2kWh    INT NULL,
    Kvartal3kWh    INT NULL,
    Kvartal4kWh    INT NULL,
    Aarstal        DATETIME NOT NULL,
    ProsumerId     BIGINT NOT NULL,
CONSTRAINT pk_Forbrug PRIMARY KEY CLUSTERED (ForbrugId),
CONSTRAINT fk_Forbrug FOREIGN KEY (ProsumerId)
    REFERENCES Prosumer (ProsumerId)
    ON DELETE NO ACTION
    ON UPDATE CASCADE)
GO

--
-- Permissions for: 'public'
--
GRANT ALL ON Prosumer TO public
GO
GRANT ALL ON PersonAntal TO public
GO
GRANT ALL ON Forbrug TO public
GO