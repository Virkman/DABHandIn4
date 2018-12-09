--
-- Create Table    : 'SmartMeter'   
-- SmartMeterId    :  
--
CREATE TABLE SmartMeter (
    SmartMeterId   BIGINT IDENTITY(1,1) NOT NULL,
CONSTRAINT pk_SmartMeter PRIMARY KEY CLUSTERED (SmartMeterId))