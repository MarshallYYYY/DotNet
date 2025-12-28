using System;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace FileOperations
{
    public partial class FormXML : Form
    {
        public FormXML()
        {
            InitializeComponent();
        }
        #region XML的创建、内容追加
        private void BtnCreateXML_Click(object sender, EventArgs e)
        {
            //创建XML文档对象
            XmlDocument doc = new XmlDocument();
            //创建第一行描述信息，并且添加到doc文档中
            XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "utf-8", null);
            doc.AppendChild(dec);
            //创建根节点
            XmlElement booksElem = doc.CreateElement("Books");
            //将根节点添加到文档中
            doc.AppendChild(booksElem);

            Book book1 = new Book()
            {
                Name = "水浒传",
                Price = 10,
                MonetaryUnit = "元",
                Des = "105个男人和三个女人的故事",
            };
            Book book2 = new Book()
            {
                Name = "西游记",
                Price = 20,
                MonetaryUnit = "元",
                Des = "唐僧师徒四人西天取经的故事",
            };
            AppendData(doc, booksElem, book1);
            AppendData(doc, booksElem, book2);

            string desktopPath = @"C:\Users\YYYXB\Desktop\";
            string path = Path.Combine(desktopPath, "Books.xml");
            doc.Save(path);
            MessageBox.Show($"Books.xml 创建成功，已保存至 {path}。");
        }
        private void AppendData(XmlDocument doc, XmlElement booksElem, Book book)
        {
            //给根节点Books创建子节点
            XmlElement bookElem = doc.CreateElement(nameof(Book));
            //将book添加到根节点
            booksElem.AppendChild(bookElem);

            //给book添加三个子节点
            XmlElement nameElem = doc.CreateElement(nameof(Book.Name));
            nameElem.InnerText = book.Name;
            bookElem.AppendChild(nameElem);

            XmlElement priceElem = doc.CreateElement(nameof(Book.Price));
            priceElem.InnerText = book.Price.ToString();
            //给节点添加属性
            priceElem.SetAttribute(nameof(Book.MonetaryUnit), book.MonetaryUnit);
            bookElem.AppendChild(priceElem);

            XmlElement desElem = doc.CreateElement(nameof(book.Des));
            desElem.InnerText = book.Des;
            bookElem.AppendChild(desElem);
        }

        private void BtnAppendXML_Click(object sender, EventArgs e)
        {
            //追加XML文档
            XmlDocument doc = new XmlDocument();
            XmlElement booksElem;
            string path = Path.Combine(@"C:\Users\YYYXB\Desktop\", "Books.xml");
            //如果文件存在
            if (File.Exists(path))
            {
                //加载xml
                doc.Load(path);
                //获得文件的根节点
                booksElem = doc.DocumentElement;
            }
            //如果文件不存在
            else
            {
                //创建第一行
                XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "utf-8", null);
                doc.AppendChild(dec);
                //创建根节点
                booksElem = doc.CreateElement("Books");
                doc.AppendChild(booksElem);
            }

            Book book = new Book()
            {
                Name = "三国演义",
                Price = 15,
                MonetaryUnit = "元",
                Des = "东汉末年，魏蜀吴三国争霸的故事",
            };
            AppendData(doc, booksElem, book);
            doc.Save(path);
            MessageBox.Show($"Books.xml 已成功追加内容，并保存至 {path}。");
        }
        #endregion

        #region 读取XML
        private void BtnReadXMLByInnerText_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(@"C:\Users\YYYXB\Desktop\", "Books.xml");
            XmlDocument doc = new XmlDocument();
            //加载要读取的XML
            doc.Load(path);
            //获得根节点
            XmlElement booksElem = doc.DocumentElement;
            //获得子节点 返回节点的集合
            XmlNodeList nodeList = booksElem.ChildNodes;
            string content = string.Empty;
            //MessageBox.Show(nodeList.Count.ToString());
            
            foreach (XmlNode node in nodeList)
            {
                // 不包含 Price Node 的 Attribute
                content += node.InnerText + "\n";
            }
            MessageBox.Show(content);
        }

        private void BtnReadXMLByInnerXML_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(@"C:\Users\YYYXB\Desktop\", "Books.xml");
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlElement booksElem = doc.DocumentElement;
            XmlNodeList nodeList = booksElem.ChildNodes;
            string content = string.Empty;

            foreach (XmlNode node in nodeList)
            {
                //MessageBox.Show(node["Name"].InnerXml);
                // 获取一整个 Book Node 中XML形式的内容，包含 Price Node 的 Attribute
                content += node.InnerXml + "\n";
            }
            MessageBox.Show(content);
        }

        // 下面这两个函数的输出结果完全一致
        private void BtnReadXMLByInnerText2_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(@"C:\Users\YYYXB\Desktop\", "Books.xml");
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlElement booksElem = doc.DocumentElement;
            // SelectNodes：选择特定的几个节点
            //XmlNodeList nodeList = doc.SelectNodes("订单/购买商品/商品属性");
            XmlNodeList nodeList = booksElem.ChildNodes;
            string content = string.Empty;

            foreach (XmlNode node in nodeList)
            {
                string book =
                    node[nameof(Book.Name)].InnerText + " | " +
                    node[nameof(Book.Price)].InnerText + " " +
                    node[nameof(Book.Price)].Attributes[nameof(Book.MonetaryUnit)].InnerText + " | " +
                    node[nameof(Book.Des)].InnerText;
                content += book + "\n";
            }
            MessageBox.Show(content);
        }

        private void BtnReadXMLByInnerXML2_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(@"C:\Users\YYYXB\Desktop\", "Books.xml");
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlElement booksElem = doc.DocumentElement;
            XmlNodeList nodeList = booksElem.ChildNodes;
            string content = string.Empty;

            foreach (XmlNode node in nodeList)
            {
                string book =
                    node[nameof(Book.Name)].InnerXml + " | " +
                    node[nameof(Book.Price)].InnerXml + " " +
                    node[nameof(Book.Price)].Attributes[nameof(Book.MonetaryUnit)].InnerXml + " | " +
                    node[nameof(Book.Des)].InnerXml;
                content += book + "\n";
            }
            MessageBox.Show(content);
        }
        #endregion

        #region 删除XML的节点
        private void BtnDeleteNode_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(@"C:\Users\YYYXB\Desktop\", "Books.xml");
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlElement booksElem = doc.DocumentElement;
            XmlNodeList nodeList = booksElem.ChildNodes;
            string nodeName = nameof(Book.Des);
            foreach (XmlNode node in nodeList)
            {
                if (node[nodeName] != null)
                    node.RemoveChild(node[nodeName]);
            }
            doc.Save(path);
            MessageBox.Show($"Books.xml 已成功删除所有的 {nodeName} 节点，并保存至 {path}。");
        } 
        #endregion
    }
}