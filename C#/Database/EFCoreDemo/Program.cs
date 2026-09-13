using Microsoft.EntityFrameworkCore;

namespace EFCoreDemo
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //for (int i = 1; i <= 20; i++)
            //    await Fun添加($"第 {i} 条数据");

            while (true)
            {
                Console.WriteLine("请选择要执行的示例：");
                Console.WriteLine("1 - 添加一条新的内容数据");
                Console.WriteLine("2 - 显示数据库中的全部内容数据");
                Console.WriteLine("3 - 按每页5条分页显示内容数据");
                Console.WriteLine("4 - 查询编号小于8的内容数据");
                Console.WriteLine("5 - 修改编号为1的内容数据");
                Console.WriteLine("6 - 删除编号为2的内容数据");
                Console.WriteLine("0 - 退出");
                Console.Write("请输入选项(0-6)：");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("输入无效，请输入数字。");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Console.WriteLine(">>> 执行：添加一条新的内容数据");
                        Console.Write("请输入要添加的内容：");
                        string? content = Console.ReadLine();
                        await Fun添加(content ?? "");
                        break;
                    case 2:
                        Console.WriteLine(">>> 执行：显示数据库中的全部内容数据");
                        await ShowAll();
                        break;
                    case 3:
                        Console.WriteLine(">>> 执行：按每页5条分页显示内容数据");
                        await Fun分页显示();
                        break;
                    case 4:
                        Console.WriteLine(">>> 执行：查询编号小于8的内容数据");
                        await Fun条件查询();
                        break;
                    case 5:
                        Console.WriteLine(">>> 执行：修改编号为1的内容数据");
                        await Fun修改();
                        break;
                    case 6:
                        Console.WriteLine(">>> 执行：删除编号为2的内容数据");
                        await Fun删除();
                        break;
                    case 0:
                        Console.WriteLine("已退出。");
                        return;
                    default:
                        Console.WriteLine("输入无效，请输入 0-6 之间的数字。");
                        break;
                }

                Console.WriteLine("\n按任意键返回菜单...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        static async Task Fun添加(string content)
        {
            using AppDbContext appDbContext = new();
            appDbContext.Add(new EFCoreItem
            {
                Content = content
            });
            await appDbContext.SaveChangesAsync();
        }
        static async Task ShowAll()
        {
            using AppDbContext db = new();
            List<EFCoreItem> datas = await db.EFCoreItems.ToListAsync();
            datas.ForEach(
                data =>
                Console.WriteLine($"{data.Id} {data.Content}"));
        }
        static async Task Fun分页显示()
        {
            List<EFCoreItem> datas = new();
            using AppDbContext db = new();

            for (int i = 0; i < 20/5; i++)
            {
                datas = await db.EFCoreItems.Skip(i * 5).Take(5).ToListAsync();
                datas.ForEach(
                    data =>
                    Console.WriteLine($"{data.Id} {data.Content}"));
                Console.WriteLine("---------");
            }
        }
        static async Task Fun条件查询()
        {
            List<EFCoreItem> datas = new();
            using AppDbContext db = new();

            datas = await db.EFCoreItems.Where(item => item.Id < 8).ToListAsync();
            datas.ForEach(
                data =>
                Console.WriteLine($"{data.Id} {data.Content}"));
        }

        static async Task Fun修改()
        {
            using AppDbContext db = new();
            EFCoreItem? data = await db.EFCoreItems.FindAsync(1);
            if (data is not null)
                data.Content = "修改后的数据";
            await db.SaveChangesAsync();
        }
        static async Task Fun删除()
        {
            using AppDbContext db = new();
            EFCoreItem? data = await db.EFCoreItems.FindAsync(2);
            if (data is not null)
                db.Remove(data);
            await db.SaveChangesAsync();
        }
    }
}
