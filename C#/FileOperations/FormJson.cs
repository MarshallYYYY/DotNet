using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Windows.Forms;

namespace FileOperations
{
    public partial class FormJson : Form
    {
        public FormJson()
        {
            InitializeComponent();
        }

        private readonly string path = Path.Combine(@"C:\Users\YYYXB\Desktop\", "Test.json");
        #region 创建、写入Json
        private void BtnWriteJson_Click(object sender, EventArgs e)
        {
            // 键
            string key = "算法参数";
            // 值内容
            JObject data = new JObject
            {
                ["Width"] = 123,
                ["Height"] = 456,
                ["Area"] = 100
            };
            // 保存到指定json文件中
            WriteJson(path, key, data);
        }

        private void BtnWriteJsonTwo_Click(object sender, EventArgs e)
        {
            WriteJson(path, "AAA", null, "abcd");
        }
        private void WriteJson(string path, string key, JObject data = null, string content = null)
        {
            // 如果文件不存在，则创建
            if (File.Exists(path) is false)
            {
                JObject jsonObject;
                if (content is null)
                {
                    jsonObject = new JObject
                    {
                        [key] = data
                    };
                }
                else
                {
                    jsonObject = new JObject
                    {
                        [key] = content
                    };
                }

                string json = JsonConvert.SerializeObject(jsonObject);
                File.WriteAllText(path, json);
            }
        }
        #endregion

        #region 追加Json内容
        private void BtnAppendJson_Click(object sender, EventArgs e)
        {
            // 键
            string key = "第二个key";
            // 值内容
            JObject data = new JObject
            {
                ["AAA"] = "aaa",
                ["BBB"] = "bbb",
                ["CCC"] = "ccc"
            };
            AppendJson(path, key, data);
        }
        private void AppendJson(string path, string key, JObject data)
        {
            if (!File.Exists(path))
            {
                MessageBox.Show("目标json文件不存在！");
                return;
            }
            string json = "";
            using (StreamReader reader = new StreamReader(path))
            {
                json = reader.ReadToEnd();
            }
            // 字符串转JObject
            JObject jsonObject = JObject.Parse(json);
            // 添加键值
            //jsonObject.Add(key, data);
            jsonObject[key] = data;
            // 序列化
            string appendJson = JsonConvert.SerializeObject(jsonObject);
            // 保存json
            File.WriteAllText(path, appendJson);
        }
        #endregion

        #region 读取Json
        private void BtnReadJson_Click(object sender, EventArgs e)
        {
            JObject jsonObject = ReadJson(path);
            if (jsonObject is null)
                return;
            MessageBox.Show(jsonObject.ToString());

            JObject firstKey = (JObject)jsonObject["算法参数"];
            MessageBox.Show(firstKey.ToString());

            string height = (string)firstKey["Height"];
            MessageBox.Show(height.ToString());
        }

        private void BtnReadJsonTwo_Click(object sender, EventArgs e)
        {
            JObject jsonObject = ReadJson(path);
            if (jsonObject is null)
                return;
            MessageBox.Show(jsonObject.ToString());

            string height = (string)jsonObject["AAA"];
            MessageBox.Show(height);
        }
        private JObject ReadJson(string path)
        {
            if (!File.Exists(path))
            {
                MessageBox.Show("目标json文件不存在！");
                return null;
            }

            string json;
            using (StreamReader reader = new StreamReader(path))
            {
                json = reader.ReadToEnd();
            }
            return JObject.Parse(json);
        }
        #endregion

        #region 修改（移除）Json中的属性
        private void BtnRemoveProperty_Click(object sender, EventArgs e)
        {
            RemoveJsonProperty(path, "算法参数");
        }
        private void RemoveJsonProperty(string path, string key)
        {
            if (!File.Exists(path))
            {
                MessageBox.Show("目标json文件不存在！");
                return;
            }
            string json = "";
            using (StreamReader reader = new StreamReader(path))
            {
                json = reader.ReadToEnd();
            }
            JObject jsonObject = JObject.Parse(json);
            // 和 AppendJson() 只有这一处不同
            jsonObject.Remove(key);
            string result = JsonConvert.SerializeObject(jsonObject);
            File.WriteAllText(path, result);
        }
        #endregion
    }
}
