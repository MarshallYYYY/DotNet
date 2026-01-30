using System;
using System.Data;
using System.Data.SqlClient;

/* 需要先使用SQLServer文件夹中的 存储过程 PROCEDURE.sql 文件中的sql命令，
 * 创建 Users 表、添加测试数据、创建存储过程。
 */

namespace ADOdotNETDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GetUsersByDataTableDetailed();
            GetUsersByDataTableBrief();
            GetUsersByDataReader();

            GetUserById(1);
            string userName = "ABC";
            InsertUser(userName, "123456");
            GetUsersByDataTableBrief();
            UpdateUser(userName, "123123");
            GetUsersByDataTableBrief();
            DeleteUser(userName);
            GetUsersByDataTableBrief();
            GetUsersCount();

            UseProcedure();
            //UseTransaction("admin", "111222");
            UseTransaction("newName", "111222");
            GetUsersByDataTableBrief();
        }
        //private const string connStr = "Server=localhost\\MSSQLSERVER01;Database=LearnDb;Trusted_Connection=true;";
        private const string connStr = "Data Source=.\\MSSQLSERVER01;Database=LearnDb;UID=SSMS21;PWD=YYYXUEBING";

        private static void GetUsersByDataTableDetailed()
        {
            SqlConnection conn = new SqlConnection
            {
                ConnectionString = connStr,
            };

            SqlCommand cmd = conn.CreateCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM Users";
            SqlDataAdapter adapter = new SqlDataAdapter
            {
                SelectCommand = cmd
            };

            // 多表的情况下使用这个方案
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            DataTable table = ds.Tables[0];

            for (int i = 0; i < table.Rows.Count; i++)
            {
                for (int j = 0; j < table.Columns.Count; j++)
                {
                    Console.Write($"{table.Rows[i][j]}\t");
                }
                Console.WriteLine();
            }

            conn.Dispose();
            Console.WriteLine("--------------------");
        }
        private static void GetUsersByDataTableBrief()
        {
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();

            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Users", conn);

            DataTable table = new DataTable();
            adapter.Fill(table);

            for (int i = 0; i < table.Rows.Count; i++)
            {
                for (int j = 0; j < table.Columns.Count; j++)
                {
                    Console.Write($"{table.Rows[i][j]}\t");
                }
                Console.WriteLine();
            }

            conn.Dispose();
            Console.WriteLine("--------------------");
        }
        private static void GetUsersByDataReader()
        {
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            string sql = "SELECT * FROM Users";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"{reader.GetInt32(0)}\t{reader.GetString(1)}\t{reader.GetString(2)}\t{reader.GetDateTime(3)}");
            }
            // 在 ADO.NET 中，如果不使用 using，
            // 必须在 finally 中按 Reader → Command → Connection 的顺序释放资源，否则在异常情况下会导致连接池资源泄漏。

            // 在 ADO.NET 中，Close() 和 Dispose() 在功能上等价，Close() 内部会调用 Dispose()。
            // 但从.NET 的资源管理规范和代码一致性角度，推荐统一使用 Dispose()，尤其是在手动释放资源或 using 语句中。
            reader.Close();
            cmd.Dispose();
            conn.Dispose();
            Console.WriteLine("--------------------");
        }
        private static void GetUserById(int id)
        {
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            string sql = "SELECT Id, UserName FROM Users WHERE Id = @Id";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Id", id);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Console.WriteLine($"{reader.GetInt32(0)}, {reader.GetString(1)}");
            }
            reader.Close();
            conn.Close();
            Console.WriteLine("--------------------");
        }
        private static void InsertUser(string userName, string password)
        {
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            string sql = "INSERT INTO Users(UserName,Password) VALUES(@u,@p)";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@u", userName);
            cmd.Parameters.AddWithValue("@p", password);
            int rows = cmd.ExecuteNonQuery();
            Console.WriteLine($"成功插入 {rows} 条数据");
            conn.Close();
        }
        private static void UpdateUser(string userName, string password)
        {
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            string sql = "UPDATE Users SET Password = @p WHERE UserName = @u";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@u", userName);
            cmd.Parameters.AddWithValue("@p", password);
            int rows = cmd.ExecuteNonQuery();
            Console.WriteLine($"成功修改 {rows} 条数据");
            conn.Close();
        }
        private static void DeleteUser(string userName)
        {
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            string sql = "DELETE FROM Users WHERE UserName = @u";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@u", userName);
            int rows = cmd.ExecuteNonQuery();
            Console.WriteLine($"成功删除 {rows} 条数据");
            conn.Close();
        }
        private static void GetUsersCount()
        {
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            string sql = "SELECT COUNT(*) FROM Users";
            SqlCommand cmd = new SqlCommand(sql, conn);
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            Console.WriteLine($"Users表共有 {count} 条数据");
            conn.Close();
        }
        private static void UseProcedure()
        {
            Console.WriteLine("--------------------");
            Console.WriteLine("存储过程 usp_GetUserByUserName");
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            SqlCommand cmd = new SqlCommand("usp_GetUserByUserName", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.Add("@UserName", SqlDbType.NVarChar, 50).Value = "admin";

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"{reader.GetInt32(0)}\t{reader.GetString(1)}\t{reader.GetDateTime(2)}\t");
            }
            reader.Close();
            cmd.Dispose();
            conn.Close();
            Console.WriteLine("--------------------");
        }
        private static void UseTransaction(string userName, string password)
        {
            Console.WriteLine("--------------------");
            Console.WriteLine("事务");
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                // ① 开启事务
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    // ② 第一个 Command：检查用户名是否存在
                    using (SqlCommand checkCmd = new SqlCommand(
                        "SELECT COUNT(*) FROM Users WHERE UserName = @UserName",
                        conn))
                    {
                        checkCmd.Transaction = tran; // ★ 绑定事务
                        checkCmd.Parameters.Add("@UserName", SqlDbType.NVarChar, 50).Value = userName;

                        int count = (int)checkCmd.ExecuteScalar();
                        if (count > 0)
                        {
                            throw new Exception("用户名已存在");
                        }
                    }

                    // ③ 第二个 Command：插入用户
                    using (SqlCommand insertCmd = new SqlCommand(
                        "INSERT INTO Users(UserName, Password) VALUES(@UserName, @Password)",
                        conn))
                    {
                        insertCmd.Transaction = tran; // ★ 同一个事务
                        insertCmd.Parameters.Add("@UserName", SqlDbType.NVarChar, 50).Value = userName;
                        insertCmd.Parameters.Add("@Password", SqlDbType.NVarChar, 50).Value = password;

                        insertCmd.ExecuteNonQuery();
                    }

                    // ④ 提交事务
                    tran.Commit();
                    Console.WriteLine($"新增用户 {userName} 成功！");
                }
                catch
                {
                    // ⑤ 回滚事务
                    tran.Rollback();
                    //throw;
                    Console.WriteLine($"用户名 {userName} 已存在！");
                }
            }

            Console.WriteLine("--------------------");
        }
    }
}
