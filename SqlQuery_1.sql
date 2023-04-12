create procedure addUser
   @chatId int
   AS
   INSERT INTO Users(Id,ChatId) Values(1,@chatId)
   GO