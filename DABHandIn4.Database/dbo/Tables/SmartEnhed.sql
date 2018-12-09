--
-- Create Table    : 'SmartEnhed'   
-- SmartEnhedId    :  
-- ProsumerId      :  
-- SmartMeterId    :  (references SmartMeter.SmartMeterId)
-- TypeId          :  (references Type.TypeId)
--
CREATE TABLE SmartEnhed (
    SmartEnhedId   BIGINT IDENTITY(1,1) NOT NULL,
    ProsumerId     BIGINT NOT NULL,
    SmartMeterId   BIGINT NOT NULL,
    TypeId         BIGINT NOT NULL,
CONSTRAINT pk_SmartEnhed PRIMARY KEY CLUSTERED (SmartEnhedId),
CONSTRAINT fk_SmartEnhed FOREIGN KEY (SmartMeterId)
    REFERENCES SmartMeter (SmartMeterId)
    ON DELETE NO ACTION
    ON UPDATE CASCADE,
CONSTRAINT fk_SmartEnhed2 FOREIGN KEY (TypeId)
    REFERENCES Type (TypeId)
    ON DELETE NO ACTION
    ON UPDATE CASCADE)