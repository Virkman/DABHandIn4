--
-- Create Table    : 'Type'   
-- TypeId          :  
-- TypeNavn        :  
--
CREATE TABLE Type (
    TypeId         BIGINT IDENTITY(1,1) NOT NULL,
    TypeNavn       VARCHAR NOT NULL,
CONSTRAINT pk_Type PRIMARY KEY CLUSTERED (TypeId))