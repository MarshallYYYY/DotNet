USE LearnDb;
-- 创建用户操作日志表
CREATE TABLE UserLogs
(
    LogId INT IDENTITY(1,1) PRIMARY KEY,
    UserId INT,
    UserName NVARCHAR(50),
    ActionType NVARCHAR(20),      -- INSERT/UPDATE/DELETE
    OldPassword NVARCHAR(50),      -- 更新前的密码（如果是更新）
    NewPassword NVARCHAR(50),      -- 更新后的密码（如果是更新）
    OperationTime DATETIME DEFAULT GETDATE(),
    OperatorIP NVARCHAR(50) DEFAULT '127.0.0.1'  -- 模拟操作IP
);


--案例一：AFTER - INSERT 触发器（记录新增用户）
CREATE TRIGGER trg_Users_Insert
ON Users
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;
    
    INSERT INTO UserLogs (UserId, UserName, ActionType, NewPassword)
    SELECT 
        Id, 
        UserName, 
        'INSERT', 
        Password
    FROM inserted;
    
    PRINT '【触发器】新用户添加操作已记录';
END;

INSERT INTO Users (UserName, Password) VALUES ('wangwu', '111111');
-- 会自动在 UserLogs 表中插入一条记录

--案例二：INSTEAD OF - DELETE 触发器（防止误删或记录删除）
CREATE TRIGGER trg_Users_Delete
ON Users
INSTEAD OF DELETE  -- 使用 INSTEAD OF，可以阻止删除或做软删除
AS
BEGIN
    SET NOCOUNT ON;
    
    -- 方式1：记录删除日志但不允许真正删除
    INSERT INTO UserLogs (UserId, UserName, ActionType)
    SELECT Id, UserName, 'DELETE_ATTEMPTED'
    FROM deleted;
    
    PRINT '【触发器】删除操作被记录，但未执行实际删除';
    
    -- 如果确实想删除，可以取消下面注释：
    -- DELETE FROM Users WHERE Id IN (SELECT Id FROM deleted);
    
    -- 方式2：软删除（如果表有 IsDeleted 字段）
    -- UPDATE Users 
    -- SET IsDeleted = 1 
    -- WHERE Id IN (SELECT Id FROM deleted);
END;

DELETE FROM Users WHERE UserName = 'wangwu';
-- 不会真正删除，只在日志表记录