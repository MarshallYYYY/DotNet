USE LearnDb;

--案例一：基础视图（隐藏敏感字段）
-- 隐藏 Password 字段，只展示安全信息
CREATE VIEW vw_UserPublicInfo
AS
SELECT 
    Id,
    UserName,
    CreateTime,
    -- 可以添加一些派生字段
    '******' AS MaskedPassword,  -- 显示掩码，不暴露真实密码
    CASE 
        WHEN DATEDIFF(DAY, CreateTime, GETDATE()) < 7 
            THEN '新用户'
            ELSE '老用户'
    END AS UserStatus
FROM Users;

SELECT TOP 10 * FROM vw_UserPublicInfo;
-- 结果：Id, UserName, CreateTime, MaskedPassword, UserStatus