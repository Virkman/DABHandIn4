--
-- Create Table    : 'Har'   
-- SmartEnhedId    :  (references SmartEnhed.SmartEnhedId)
-- ElkildeId       :  (references Elkilde.ElkildeId)
-- Antal           :  
--
CREATE TABLE Har (
    SmartEnhedId   BIGINT NOT NULL,
    ElkildeId      BIGINT NOT NULL,
    Antal          INT NOT NULL,
CONSTRAINT pk_Har PRIMARY KEY CLUSTERED (SmartEnhedId,ElkildeId),
CONSTRAINT fk_Har FOREIGN KEY (SmartEnhedId)
    REFERENCES SmartEnhed (SmartEnhedId)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
CONSTRAINT fk_Har2 FOREIGN KEY (ElkildeId)
    REFERENCES Elkilde (ElkildeId)
    ON DELETE CASCADE
    ON UPDATE CASCADE)