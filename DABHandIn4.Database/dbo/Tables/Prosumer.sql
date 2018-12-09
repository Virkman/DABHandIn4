--
-- Create Table    : 'Prosumer'   
-- ProsumerId      :  
-- SmartEnhedId    :  
--
CREATE TABLE Prosumer (
    ProsumerId     BIGINT IDENTITY(1,1) NOT NULL,
    SmartEnhedId   BIGINT NOT NULL,
CONSTRAINT pk_Prosumer PRIMARY KEY CLUSTERED (ProsumerId))