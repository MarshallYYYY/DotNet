--建库
CREATE DATABASE LearnDb
ON 
(
    NAME = LearnDb_Data,
    FILENAME = 'S:\SQLServer\LearnDb.mdf'
);

USE LearnDb;

------一、准备示例表（用户表）------
CREATE TABLE Users
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    UserName NVARCHAR(50) NOT NULL,
    Password NVARCHAR(50) NOT NULL,
    CreateTime DATETIME NOT NULL DEFAULT GETDATE()
);
--插入一点测试数据：
INSERT INTO Users (UserName, Password)
VALUES 
('admin', '123456'),
('test', 'abcdef');

------二、创建一个最简单的存储过程（无参数）------
--示例：查询所有用户
CREATE PROCEDURE usp_GetAllUsers
AS
BEGIN
    SELECT Id, UserName, CreateTime
    FROM Users;
END

--调用方式 ①
EXEC usp_GetAllUsers;
--调用方式②
EXECUTE usp_GetAllUsers;

------三、带输入参数的存储过程（最常见）------
--示例：根据用户名查询用户
CREATE PROCEDURE usp_GetUserByUserName
    @UserName NVARCHAR(50)
AS
BEGIN
    SELECT Id, UserName, CreateTime
    FROM Users
    WHERE UserName = @UserName;
END

--调用方式 ①
EXEC usp_GetUserByUserName 'admin';
--调用方式②
-- 推荐写法（可读性更好）
EXEC usp_GetUserByUserName 
    @UserName = 'admin';

------四、带输出参数的存储过程------
--示例：判断用户是否存在
CREATE PROCEDURE usp_CheckUserExists
    @UserName NVARCHAR(50),
    @Exists BIT OUTPUT
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Users WHERE UserName = @UserName)
        SET @Exists = 1;
    ELSE
        SET @Exists = 0;
END
--调用方式
DECLARE @Result BIT;

EXEC usp_CheckUserExists 
    @UserName = 'admin',
    @Exists = @Result OUTPUT;

SELECT @Result AS UserExists;

------五、用于新增数据的存储过程（Insert）------
--示例：新增用户并返回新用户 Id
CREATE PROCEDURE usp_CreateUser
    @UserName NVARCHAR(50),
    @Password NVARCHAR(50),
    @NewUserId INT OUTPUT
AS
BEGIN
    INSERT INTO Users (UserName, Password)
    VALUES (@UserName, @Password);

    SET @NewUserId = SCOPE_IDENTITY();
END
--调用方式
DECLARE @UserId INT;

EXEC usp_CreateUser
    @UserName = 'newuser',
    @Password = '123456',
    @NewUserId = @UserId OUTPUT;

SELECT @UserId AS NewUserId;

------六、带事务和异常处理的存储过程（进阶）------
--示例：注册用户（防止重复）
CREATE PROCEDURE usp_RegisterUser
    @UserName NVARCHAR(50),
    @Password NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRAN;

        IF EXISTS (SELECT 1 FROM Users WHERE UserName = @UserName)
        BEGIN
            RAISERROR('用户名已存在', 16, 1);
            ROLLBACK TRAN;
            RETURN;
        END

        INSERT INTO Users (UserName, Password)
        VALUES (@UserName, @Password);

        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRAN;

        THROW; -- 抛出原始异常
    END CATCH
END
