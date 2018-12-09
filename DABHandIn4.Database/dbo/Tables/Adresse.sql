--
-- Create Table    : 'Adresse'   
-- AdresseId       :  
-- Vejnavn         :  
-- Husnummer       :  
-- Postnummer      :  
-- Bynavn          :  
-- SmartEnhedId    :  (references SmartEnhed.SmartEnhedId)
--
CREATE TABLE Adresse (
    AdresseId      BIGINT IDENTITY(1,1) NOT NULL,
    Vejnavn        VARCHAR NOT NULL,
    Husnummer      CHAR NOT NULL,
    Postnummer     CHAR NOT NULL,
    Bynavn         VARCHAR NOT NULL,
    SmartEnhedId   BIGINT NOT NULL,
CONSTRAINT pk_Adresse PRIMARY KEY CLUSTERED (AdresseId),
CONSTRAINT fk_Adresse FOREIGN KEY (SmartEnhedId)
    REFERENCES SmartEnhed (SmartEnhedId)
    ON DELETE NO ACTION
    ON UPDATE CASCADE)