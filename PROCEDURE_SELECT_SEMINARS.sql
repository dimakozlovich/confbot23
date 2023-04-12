CREATE PROCEDURE select_seminars
@day INT
AS
SELECT * FROM Seminars
WHERE day = 1;
