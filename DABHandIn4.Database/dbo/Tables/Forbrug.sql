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