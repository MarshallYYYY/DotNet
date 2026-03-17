-- 测试数据：插入400万条数据
DECLARE @i INT = 1;
WHILE @i <= 4000000
BEGIN
    INSERT INTO Users (UserName, Password)
    VALUES ('User' + CAST(@i AS NVARCHAR(10)), 'Pwd' + CAST(@i AS NVARCHAR(10)));
    SET @i = @i + 1;
END

SET STATISTICS TIME ON;
-- 无索引时查询（慢）
SELECT * FROM Users WHERE UserName = 'User50000';
--SET STATISTICS TIME OFF;

-- 创建索引
CREATE INDEX IX_Users_UserName ON Users(UserName);
-- 有索引时查询（快）
SELECT * FROM Users WHERE UserName = 'User50000';

--移除索引
--DROP INDEX IX_Users_UserName ON Users
ALTER INDEX IX_Users_UserName ON Users DISABLE;
ALTER INDEX IX_Users_UserName ON Users REBUILD;
