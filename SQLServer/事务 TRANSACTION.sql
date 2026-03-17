-- 案例一
BEGIN TRANSACTION;  -- 开始事务
 
-- 执行一系列SQL语句
UPDATE Users SET Password = '987654' WHERE UserName = 'Mike';
 
-- 检查是否有错误
IF @@ERROR <> 0
    BEGIN
        ROLLBACK TRANSACTION;  -- 回滚事务
        PRINT 'Transaction rolled back due to error';
    END
ELSE
    BEGIN
        COMMIT TRANSACTION;  -- 提交事务
        PRINT 'Transaction committed successfully';
    END


-- 案例二：对应 DotNet - C# - Database - ADOdotNETDemo - UseTransaction(string userName, string password)
-- 开启事务
BEGIN TRANSACTION;

BEGIN TRY
    -- 声明变量（假设这些是从 C# 传入的参数）
    DECLARE @UserName NVARCHAR(50) = 'Mike';  -- 示例用户名
    DECLARE @Password NVARCHAR(50) = '123456'; -- 示例密码    
    -- 1. 检查用户名是否存在
    DECLARE @Count INT;    
    SELECT @Count = COUNT(*) FROM Users WHERE UserName = @UserName;    
    IF @Count > 0
        BEGIN
            -- 用户名已存在，抛出错误
            RAISERROR('用户名已存在', 16, 1);
        END    
    -- 2. 插入新用户
    INSERT INTO Users (UserName, Password) VALUES (@UserName, @Password);    
    -- 3. 提交事务
    COMMIT TRANSACTION;
    PRINT '新增用户 ' + @UserName + ' 成功！';
END TRY

BEGIN CATCH
    -- 4. 发生错误，回滚事务
    IF @@TRANCOUNT > 0
        ROLLBACK TRANSACTION;
    
    -- 5. 输出错误信息
    PRINT '用户名 ' + @UserName + ' 已存在！';
    
    -- 或者输出详细错误（可选）
    -- SELECT 
    --     ERROR_NUMBER() AS ErrorNumber,
    --     ERROR_MESSAGE() AS ErrorMessage;
END CATCH;