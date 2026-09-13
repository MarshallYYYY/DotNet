using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<StudentInfo> students = InitStudentsInfo();
            while (true)
            {
                ShowStudentsInfo(students);
                Console.WriteLine("请选择要执行的示例：");
                Console.WriteLine("1 - 基本查询（Where、Select、SelectMany）");
                Console.WriteLine("2 - 转换方法（ToList、ToArray、ToDictionary、ToLookup）");
                Console.WriteLine("3 - 元素操作方法（First、FirstOrDefault、Single、SingleOrDefault、Last、LastOrDefault、ElementAt、ElementAtOrDefault、DefaultIfEmpty）");
                Console.WriteLine("4 - 排序方法（OrderBy、OrderByDescending、ThenBy、ThenByDescending）");
                Console.WriteLine("5 - 聚合方法（Count、Sum、Average、Min、Max、Aggregate）");
                Console.WriteLine("6 - 集合操作方法（Distinct、Union、Intersect、Except、Concat）");
                Console.WriteLine("7 - 分组（GroupBy）");
                Console.WriteLine("8 - 连接（Join）");
                Console.WriteLine("9 - 分组连接（GroupJoin）");
                Console.WriteLine("10 - 跳过与获取指定数量的元素（Skip、Take）");
                Console.WriteLine("11 - 条件判断方法（All、Any、Contains）");
                Console.WriteLine("0 - 退出");
                Console.Write("请输入选项(0-11)：");

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
                        Console.WriteLine(">>> 执行：基本查询（Where、Select、SelectMany）");
                        Fun基本查询();
                        break;
                    case 2:
                        Console.WriteLine(">>> 执行：转换方法（ToList、ToArray、ToDictionary、ToLookup）");
                        Fun转换方法();
                        break;
                    case 3:
                        Console.WriteLine(">>> 执行：元素操作方法（First、FirstOrDefault、Single、SingleOrDefault、Last、LastOrDefault、ElementAt、ElementAtOrDefault、DefaultIfEmpty）");
                        Fun元素操作方法();
                        break;
                    case 4:
                        Console.WriteLine(">>> 执行：排序方法（OrderBy、OrderByDescending、ThenBy、ThenByDescending）");
                        Fun排序方法();
                        break;
                    case 5:
                        Console.WriteLine(">>> 执行：聚合方法（Count、Sum、Average、Min、Max、Aggregate）");
                        Fun聚合方法();
                        break;
                    case 6:
                        Console.WriteLine(">>> 执行：集合操作方法（Distinct、Union、Intersect、Except、Concat）");
                        Fun集合操作方法();
                        break;
                    case 7:
                        Console.WriteLine(">>> 执行：分组（GroupBy）");
                        Fun分组();
                        break;
                    case 8:
                        Console.WriteLine(">>> 执行：连接（Join）");
                        Fun连接();
                        break;
                    case 9:
                        Console.WriteLine(">>> 执行：分组连接（GroupJoin）");
                        Fun分组连接();
                        break;
                    case 10:
                        Console.WriteLine(">>> 执行：跳过与获取指定数量的元素（Skip、Take）");
                        Fun跳过与获取指定数量的元素();
                        break;
                    case 11:
                        Console.WriteLine(">>> 执行：条件判断方法（All、Any、Contains）");
                        Fun条件判断方法();
                        break;
                    case 0:
                        Console.WriteLine("已退出。");
                        return;
                    default:
                        Console.WriteLine("输入无效，请输入 0-11 之间的数字。");
                        break;
                }

                Console.WriteLine("\n按任意键返回菜单...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        #region 学生信息初始化和展示
        static List<StudentInfo> InitStudentsInfo()
        {
            List<StudentInfo> students = new List<StudentInfo>
            {
                new StudentInfo
                {
                    StudentID=1,
                    StudentName="张三",
                    Birthday=Convert.ToDateTime("1997-10-25"),
                    ClassID=101,
                    Courses = new List<Course>
                    {
                        new Course { CourseID = 101, CourseName = "语文" },
                        new Course { CourseID = 102, CourseName = "数学" }
                    }
                },
                new StudentInfo
                {
                    StudentID=2,
                    StudentName="赵六",
                    Birthday=Convert.ToDateTime("1999-11-25"),
                    ClassID=102,
                    Address="深圳" ,
                    Courses = new List<Course>
                    {
                        new Course { CourseID = 104, CourseName = "历史" },
                        new Course { CourseID = 103, CourseName = "地理" }
                    }
                },
                new StudentInfo
                {
                    StudentID=3,
                    StudentName="王五",
                    Birthday=Convert.ToDateTime("1999-10-25"),
                    ClassID=102,
                    Address="广州",
                    Courses = new List<Course>
                    {
                        new Course { CourseID = 101, CourseName = "语文" },
                        new Course { CourseID = 102, CourseName = "数学" }
                    }
                },
                new StudentInfo
                {
                    StudentID=4,
                    StudentName="李四",
                    Birthday=Convert.ToDateTime("1998-10-25"),
                    ClassID=101,
                    Courses = new List<Course>
                    {
                        new Course { CourseID = 101, CourseName = "语文" },
                        new Course { CourseID = 102, CourseName = "数学" }
                    }
                }
            };
            return students;
        }

        static void ShowStudentsInfo(List<StudentInfo> students)
        {
            //Console.WriteLine($"学号\t,姓名\t,生日\t,班级\t,地址\t,课程1编号，课程1名称\t,课程2编号\t,课程2名称");
            foreach (StudentInfo student in students)
            {
                Console.WriteLine(
                    $"{student.StudentID},\t{student.StudentName},\t{student.Birthday:yyyy-MM-dd},\t" +
                    $"{student.ClassID},\t{student.Address},\t" +
                    $"{student.Courses[0].CourseID},\t{student.Courses[0].CourseName},\t" +
                    $"{student.Courses[1].CourseID},\t{student.Courses[1].CourseName}");
            }
            Console.WriteLine("-------");
        }
        static void ShowStudentInfo(StudentInfo student)
        {
            Console.WriteLine(
                $"{student.StudentID},\t{student.StudentName},\t{student.Birthday:yyyy-MM-dd},\t" +
                $"{student.ClassID},\t{student.Address},\t" +
                $"{student.Courses[0].CourseID},\t{student.Courses[0].CourseName},\t" +
                $"{student.Courses[1].CourseID},\t{student.Courses[1].CourseName}");
            Console.WriteLine("-------");
        }
        #endregion

        static void Fun基本查询()
        {
            List<StudentInfo> students = InitStudentsInfo();

            Console.WriteLine("ClassID为101的学生姓名：");
            var students1 = students.Where(s => s.ClassID == 101);
            Console.WriteLine($"数量 = {students1.Count()}");
            foreach (var student in students1)
                Console.WriteLine(student.StudentName);
            Console.WriteLine("-------");

            Console.WriteLine("所有学生的姓名：");
            var studentsName = students.Select(s => s.StudentName);
            Console.WriteLine($"数量 = {studentsName.Count()}");
            foreach (string name in studentsName)
                Console.WriteLine(name);
            Console.WriteLine("-------");

            Console.WriteLine("所有学生的课程名称：");
            // 使用SelectMany展平所有学生的课程列表，因为 Courses 含有多个数据成员，所以使用 SelectMany()。
            //var allCourses = students.SelectMany(stu => stu.Courses).ToList();
            var allCourses = students.SelectMany(student => student.Courses);
            Console.WriteLine($"数量 = {allCourses.Count()}");

            // 输出所有课程的名称
            foreach (Course course in allCourses)
                Console.Write(course.CourseName + " ");
        }
        static void Fun转换方法()
        {
            List<StudentInfo> students = InitStudentsInfo();

            var studentList = students.ToList();
            Console.WriteLine(studentList.GetType());
            Console.WriteLine("-------");

            var studentArray = students.ToArray();
            Console.WriteLine(studentArray.GetType());
            Console.WriteLine("-------");

            var studentDictionary = students.ToDictionary(s => s.StudentID, s => s.StudentName);
            Console.WriteLine(studentDictionary.GetType());
            Console.WriteLine("-------");

            var classes = students.ToLookup(s => s.ClassID, s => s.StudentName);
            Console.WriteLine(classes.GetType());
            Console.WriteLine(classes.Count());
            foreach (var classItem in classes)
            {
                Console.WriteLine($"ClassID = {classItem.Key}");
                Console.Write("学生姓名：");
                foreach (string stuName in classItem)
                    Console.Write(stuName + " ");
                Console.WriteLine();
            }
        }
        static void Fun元素操作方法()
        {
            List<StudentInfo> students = InitStudentsInfo();

            Console.WriteLine("第一个学生");
            var firstStudent = students.First();
            ShowStudentInfo(firstStudent);

            Console.WriteLine("第一个成年人");
            // 生日 <= 18年前的今天  →  已满 18 岁
            var firstAdult = students.FirstOrDefault(s => s.Birthday <= DateTime.Now.AddYears(-18));
            ShowStudentInfo(firstAdult);

            Console.WriteLine("102班的第一个学生");
            var firstClass102Student = students.FirstOrDefault(s => s.ClassID == 102);
            ShowStudentInfo(firstClass102Student);

            Console.WriteLine("名字是 王五 的学生");
            var onlyWangWu = students.Single(s => s.StudentName == "王五");
            ShowStudentInfo(onlyWangWu);

            Console.WriteLine("名字是 李四 的学生");
            var liSiOrDefault = students.SingleOrDefault(s => s.StudentName == "李四");
            ShowStudentInfo(liSiOrDefault);

            Console.WriteLine("最后一个学生");
            var lastStudent = students.Last();
            ShowStudentInfo(lastStudent);

            Console.WriteLine("最后一个成年人");
            var lastAdult = students.LastOrDefault(s => s.Birthday <= DateTime.Now.AddYears(-18));
            ShowStudentInfo(lastAdult);

            Console.WriteLine("第二个元素代表的学生");
            var secondStudent = students.ElementAt(1);
            ShowStudentInfo(secondStudent);

            Console.WriteLine("第三个元素代表的学生");
            var tenthStudentOrDefault = students.ElementAtOrDefault(2);
            ShowStudentInfo(tenthStudentOrDefault);

            Console.WriteLine("默认数据");
            students.Clear();
            var nonEmptyStudents = students.DefaultIfEmpty(new StudentInfo { StudentID = 0, StudentName = "默认Student", Address = "默认" });
            Console.WriteLine(nonEmptyStudents.Count());
            StudentInfo stu = nonEmptyStudents.First();
            Console.WriteLine($"{stu.StudentID}, {stu.StudentName}, {stu.Address}");
        }
        static void Fun排序方法()
        {
            List<StudentInfo> students = InitStudentsInfo();

            Console.WriteLine("按照生日升序排序");
            var stus1 = students.OrderBy(s => s.Birthday);
            Console.WriteLine(stus1.GetType());
            ShowStudentsInfo(stus1.ToList());

            Console.WriteLine("按照班级ID降序排序");
            var stus2 = students.OrderByDescending(s => s.ClassID);
            ShowStudentsInfo(stus2.ToList());

            Console.WriteLine("先按照生日升序排序，然后按照班级ID升序排序");
            StudentInfo stu = new StudentInfo
            {
                StudentID = 5,
                StudentName = "FFF",
                Birthday = Convert.ToDateTime("1998-10-25"),
                ClassID = 102,
                Address = "淄博",
                Courses = new List<Course>
                {
                    new Course{CourseID = 102, CourseName = "数学"},
                    new Course{CourseID = 103, CourseName = "地理"},
                }
            };
            students.Add(stu);
            var stus3 = students.OrderBy(s => s.Birthday).ThenBy(s => s.ClassID);
            ShowStudentsInfo(stus3.ToList());

            Console.WriteLine("先按照生日升序排序，再按照班级ID升序排序，最后按照学生ID降序排序");
            stu = new StudentInfo
            {
                StudentID = 6,
                StudentName = "SSS",
                Birthday = Convert.ToDateTime("1998-10-25"),
                ClassID = 101,
                Address = "淄博",
                Courses = new List<Course>
                {
                    new Course{CourseID = 102, CourseName = "数学"},
                    new Course{CourseID = 103, CourseName = "地理"},
                }
            };
            students.Add(stu);
            var stus4 = students.OrderBy(s => s.Birthday).ThenBy(s => s.ClassID).ThenByDescending(s => s.StudentID);
            ShowStudentsInfo(stus4.ToList());
        }

        static void Fun聚合方法()
        {
            List<StudentInfo> students = InitStudentsInfo();

            Console.WriteLine("学生的总数量");
            int studentCount = students.Count();
            Console.WriteLine(studentCount);

            Console.WriteLine("学生的班级ID数值的和");
            int totalClassID = students.Sum(s => s.ClassID);
            Console.WriteLine(totalClassID);

            Console.WriteLine("学生的平均年龄（Average）");
            double averageAge = students.Average(s => DateTime.Now.Year - s.Birthday.Year);
            Console.WriteLine(averageAge);

            Console.WriteLine("最小的班级ID");
            int minClassID = students.Min(s => s.ClassID);
            Console.WriteLine(minClassID);

            Console.WriteLine("最大的班级ID");
            int maxClassID = students.Max(s => s.ClassID);
            Console.WriteLine(maxClassID);

            Console.WriteLine("所有学生名字字符串拼接（Aggregate）");
            string concatenatedNames = students.Aggregate(
                "",
                (acc, s) => acc == "" ? s.StudentName : acc + ", " + s.StudentName);
            Console.WriteLine(concatenatedNames);
        }
        static void Fun集合操作方法()
        {
            List<StudentInfo> students = InitStudentsInfo();

            Console.WriteLine("------- Select投影班级ID后，去重，最后逐个打印 班级ID -------");
            var uniqueClassIDs = students.Select(s => s.ClassID).Distinct();
            //int n = uniqueClassIDs.Count();
            ////Console.WriteLine(n);
            //for (int i = 0; i < n; i++)
            //    Console.WriteLine(uniqueClassIDs.ToArray()[i]);
            uniqueClassIDs.ToList().ForEach(item => Console.WriteLine(item));

            Console.WriteLine("------- Union联合 103 104 班级后，逐个打印 班级ID -------");
            var unionClassIDs = uniqueClassIDs.Union(new[] { 103, 104 });
            //foreach (int unionClassID in unionClassIDs)
            //    Console.WriteLine(unionClassID);
            unionClassIDs.ToList().ForEach(item => Console.WriteLine(item));

            Console.WriteLine("------- Intersect 对班级ID取交集，然后逐个打印 班级ID -------");
            // Intersect：返回两个集合的交集（共有的唯一元素）。
            var intersectClassIDs = uniqueClassIDs.Intersect(new[] { 101, 103 });
            foreach (int intersectClassID in intersectClassIDs)
                Console.WriteLine(intersectClassID);

            Console.WriteLine("------- Except 对班级ID取差集，然后逐个打印 班级ID -------");
            // Except：返回在第一个集合中存在但不在第二个集合中存在的元素（取集合的差集）。
            var exceptClassIDs = uniqueClassIDs.Except(new[] { 101 });
            foreach (int exceptClassID in exceptClassIDs)
                Console.WriteLine(exceptClassID);

            Console.WriteLine("------- Concat 连接 103 103 104 班级ID，然后逐个打印 班级ID -------");
            // Concat：连接两个集合，返回一个新的序列（保留所有元素，包括重复项）。
            var concatClassIDs = uniqueClassIDs.Concat(new[] { 103, 103, 104 });
            foreach (int concatClassID in concatClassIDs)
                Console.WriteLine(concatClassID);
        }
        static void Fun分组()
        {
            List<StudentInfo> students = InitStudentsInfo();

            Console.WriteLine("------- 通过班级ID进行分组，然后分别打印班级ID和班级中的学生 -------");
            var classes = students.GroupBy(s => s.ClassID);
            foreach (var classItem in classes)
            {
                Console.WriteLine($"班级ID: {classItem.Key}");
                foreach (StudentInfo stu in classItem)
                {
                    Console.WriteLine($"学生姓名: {stu.StudentName}");
                }
            }
        }
        static void Fun连接()
        {
            List<StudentInfo> students = InitStudentsInfo();

            var classes = new[]
            {
                new { ClassID = 101, ClassName = "一班" },
                new { ClassID = 102, ClassName = "二班" }
            };

            Console.WriteLine("------- Join 连接学生和班级，然后打印学生姓名和班级名称 -------");
            // 学生表 students 和班级表 classes 按 ClassID 做 Join，打印“学生姓名 - 班级名称”。
            var query = students.Join(
                classes,
                student => student.ClassID,
                classItem => classItem.ClassID,
                (student, classItem) => new
                {
                    student.StudentName,
                    classItem.ClassName
                });

            foreach (var item in query)
                Console.WriteLine($"{item.StudentName} - {item.ClassName}");
        }
        static void Fun分组连接()
        {
            List<StudentInfo> students = InitStudentsInfo();

            var classes = new[]
            {
                new { ClassID = 101, ClassName = "一班" },
                new { ClassID = 102, ClassName = "二班" }
            };

            Console.WriteLine("------- GroupJoin 分组连接班级和学生，然后按班级打印学生 -------");
            // 班级表 classes 和学生表 students 按 ClassID 做 GroupJoin，按班级打印学生姓名。
            var query = classes.GroupJoin(
                students,
                classItem => classItem.ClassID,
                student => student.ClassID,
                (classItem, classStudents) => new
                {
                    classItem.ClassName,
                    Students = classStudents
                });

            foreach (var item in query)
            {
                Console.WriteLine($"班级名称: {item.ClassName}");
                Console.Write("学生姓名: ");
                foreach (StudentInfo student in item.Students)
                    Console.Write(student.StudentName + " ");
                Console.WriteLine();
            }
        }
        static void Fun跳过与获取指定数量的元素()
        {
            List<StudentInfo> students = InitStudentsInfo();

            var skippedStudents = students.Skip(1);
            ShowStudentsInfo(skippedStudents.ToList());

            var takenStudents = students.Take(2);
            ShowStudentsInfo(takenStudents.ToList());

            Console.WriteLine("分页查询");
            // 数据分页查询（Skip + Take）
            int pageNumber = 2;
            int pageSize = 2;
            for (int i = 0; i < pageNumber; i++)
            {
                int currentPage = i + 1;
                var stus = students
                    .OrderBy(u => u.ClassID) // 必须排序
                    .Skip(i * pageSize)
                    .Take(pageSize)
                    .ToList();
                Console.WriteLine($"第{currentPage}页");
                ShowStudentsInfo(stus.ToList());
            }
        }
        static void Fun条件判断方法()
        {
            List<StudentInfo> students = InitStudentsInfo();

            bool allAdults = students.All(s => s.Birthday <= DateTime.Now.AddYears(-18));
            bool anyAdults = students.Any(s => s.Birthday <= DateTime.Now.AddYears(-18));
            bool containsWangWu = students.Contains(students.First(s => s.StudentName == "王五"));
            Console.WriteLine(allAdults + " " + anyAdults + " " + containsWangWu);

            bool allWangwu = students.All(s => s.StudentName == "王五");
            bool anyWangwu = students.Any(s => s.StudentName == "王五");
            //bool containsWangWu = students.Contains(students.First(s => s.StudentName == "王五"));
            Console.WriteLine(allWangwu + " " + anyWangwu + " " + containsWangWu);
        }
    }
    public class StudentInfo
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public DateTime Birthday { get; set; }
        public int ClassID { get; set; }
        public string Address { get; set; }
        public List<Course> Courses { get; set; } = new List<Course>();
    }

    public class Course
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }
    }
}
