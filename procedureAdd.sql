create procedure addUser
   @chatId int
   AS
   INSERT INTO Users(Id,ChatID) Values(2,@chatId)