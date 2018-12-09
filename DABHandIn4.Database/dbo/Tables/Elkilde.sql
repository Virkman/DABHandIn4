--
-- Create Table    : 'Elkilde'   
-- ElkildeId       :  
-- Type            :  
--
CREATE TABLE Elkilde (
    ElkildeId      BIGINT IDENTITY(1,1) NOT NULL,
    Type           VARCHAR NOT NULL,
CONSTRAINT pk_Elkilde PRIMARY KEY CLUSTERED (ElkildeId))