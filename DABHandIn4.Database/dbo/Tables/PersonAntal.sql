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