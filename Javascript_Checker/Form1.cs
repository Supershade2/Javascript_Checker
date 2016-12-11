using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
namespace Javascript_Checker
{
    public partial class Form1 : Form
    {
        string c_path = System.IO.Directory.GetCurrentDirectory();
        string FileName = "";
        string DirName = "";
        string user_selected_file;
        string File_Key;
        string rich_template;

        //string rtb_contents;
        //bool isDone;
        Timer wait = new Timer();
        //delegate void setCursor(Cursor cursor);
        public Form1()
        {
            InitializeComponent();
            rich_template = richTextBox1.Rtf;
            var Thread = new System.Threading.Thread(update_Status);
            Thread.Start();
            /*Form f1 = new Form();
            f1.Text = "Running PreForm Window";
            System.Windows.Forms.Label label1 = new Label();
            string dir = "Current Directory Program is running from\n"+System.IO.Directory.GetCurrentDirectory()+"\n";
            string files = "";
            Label label2 = new Label();
            var FileExists = System.IO.Directory.EnumerateFiles(c_path);
            foreach (string i in FileExists)
            {
                files += i;
            }
            Font font = new Font("Papyrus", 14, FontStyle.Regular);
            Size size = TextRenderer.MeasureText(dir, font);
            Size size2 = TextRenderer.MeasureText(files, font);
            label1.Size = size;
            //label2.Size = size2;
            f1.Width = label1.Width;
            f1.Controls.Add(label1);
            //f1.Controls.Add(label2);
            label1.Text = dir;
            //label2.Text = files;
            f1.ShowDialog();*/
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (user_selected_file != null)
                {
                    string[] unbuilt_File_Key = user_selected_file.Split('.');
                    bool match = false;
                    string pattern = @"(.)php$";
                    Match m1 = Regex.Match(user_selected_file, pattern);
                    match = m1.Success;
                    File_Key = match == true ? m1.ToString() : ".html";
                    if (File_Key == ".html")
                    {
                        System.IO.File.WriteAllText(c_path + @"\web.html", richTextBox1.Text);
                    }
                    else if (File_Key == ".php")
                    {
                        System.IO.File.WriteAllText(c_path + @"\web.php", richTextBox1.Text);
                    }
                    else
                    {
                        MessageBox.Show("Key Generation Failed");
                    }
                    MessageBox.Show("Completed Transfer of " + FileName);
                }
                if (File_Key != null)
                {
                    /*foreach (Match m in Regex.Matches(user_selected_file, pattern))
                    {
                        File_Key = m.ToString();
                    }*/
                    /*foreach (string i in unbuilt_File_Key)
                    {
                        switch (i)
                        {
                            case "php":
                                File_Key += i;
                            break;
                            case "html":
                                File_Key += i;
                            break;
                        }
                    }*/
                    if (File_Key == ".html")
                    {
                        System.IO.File.WriteAllText(c_path + @"\web.html", richTextBox1.Text);
                        MessageBox.Show((System.IO.File.GetLastWriteTime(c_path + @"\web.html")).Date == System.DateTime.Today ? "Write to web.html succesful on " + System.DateTime.Today : "Write might have failed");
                    }
                    else if (File_Key == ".php")
                    {
                        System.IO.File.WriteAllText(c_path + @"\web.php", richTextBox1.Text);
                        MessageBox.Show((System.IO.File.GetLastWriteTime(c_path + @"\web.php")).Date == System.DateTime.Today ? "Write to web.php succesful on " + System.DateTime.Today : "Write might have failed");
                    }
                    else
                    {
                        MessageBox.Show("Key Generation Failed");
                    }
                }
                else
                {
                    Form form2 = new Form();
                    RadioButton php = new RadioButton();
                    RadioButton html = new RadioButton();
                    Label label1 = new System.Windows.Forms.Label();
                    html.AutoSize = true;
                    html.Location = new System.Drawing.Point(162, 29);
                    html.Name = "html";
                    html.Text = ".html";
                    html.Size = new System.Drawing.Size(47, 17);
                    html.UseVisualStyleBackColor = true;
                    html.CheckedChanged += new EventHandler(html_CheckedChanged);
                    php.Location = new System.Drawing.Point(15, 29);
                    php.Size = new System.Drawing.Size(46, 17);
                    php.Name = "php";
                    php.Text = ".php";
                    php.UseVisualStyleBackColor = true;
                    php.CheckedChanged += new System.EventHandler(this.php_CheckedChanged);
                    label1.AutoSize = true;
                    label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)(0));
                    label1.Location = new System.Drawing.Point(12, 9);
                    label1.Name = "label1";
                    label1.Size = new System.Drawing.Size(197, 17);
                    label1.TabIndex = 2;
                    label1.Text = "Select the web document type";
                    form2.Size = new System.Drawing.Size(315, 110);
                    form2.Controls.Add(label1);
                    form2.Controls.Add(php);
                    form2.Controls.Add(html);
                    form2.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
                    form2.Name = "Form2";
                    form2.Text = "DocumentType";
                    form2.ShowDialog();
                    if (File_Key == ".html")
                    {
                        System.IO.File.WriteAllText(c_path + @"\web.html", richTextBox1.Text);
                        MessageBox.Show((System.IO.File.GetLastWriteTime(c_path + @"\web.html")).Date == System.DateTime.Today ? "Write to web.html succesful on " + System.DateTime.Today : "Write might have failed");
                    }
                    else if (File_Key == ".php")
                    {
                        System.IO.File.WriteAllText(c_path + @"\web.php", richTextBox1.Text);
                        MessageBox.Show((System.IO.File.GetLastWriteTime(c_path + @"\web.php")) == System.DateTime.Today ? "Write to web.php succesful on " + System.DateTime.Today : "Write might have failed" + "\n" + (System.IO.File.GetLastWriteTime(c_path + @"\web.php")));
                    }
                    else
                    {
                        MessageBox.Show("Key Generation Failed");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("Error: could not write to File\n {0}", ex));
                System.IO.File.Create(System.IO.Path.Combine(c_path, @"\web.html)"));
            }
            finally
            {

            }
            /*string patch = System.IO.Directory.GetCurrentDirectory();
            String path = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
            String dir = System.IO.Path.GetDirectoryName(path);
            string load = "ms-appdata:///local/intro/welcome.html";
            string appDir = System.IO.Path.GetDirectoryName(
    Assembly.GetExecutingAssembly().GetName().CodeBase);
            webBrowser1.Url = new Uri(System.IO.Path.Combine(appDir, @"web.html"));*/
            //string file_location = "File:///" + patch;
            try
            {
                if (File_Key == ".html")
                {
                    webBrowser1.Navigate(c_path + @"\web.html");
                }
                else if (File_Key == ".php")
                {
                    webBrowser1.Navigate(c_path + @"\web.php");
                }
            }
            
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("Something went wrong,\n {0}", ex));
                throw;
            }
            finally
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Html Files (*.html)|*.html|PHP files (*.php)|*.php";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    FileName = openFileDialog1.FileName;
                    DirName = System.IO.Path.GetDirectoryName(FileName);
                    user_selected_file = FileName.Substring(DirName.Length + 1);
                    richTextBox1.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                    /*var files = System.IO.Directory.EnumerateFileSystemEntries(DirName);
                    string filecontents = richTextBox1.Text;
                    string[] config_key = (System.IO.File.ReadAllText(c_path+@"\Config.txt")).Split('=');
                    string[] config_values = config_key[1].Split(',');
                    string[] patterns = { @".html$", @".php$",@"" };*/
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                    throw;
                }
            }
        }
        public void html_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked;
                isChecked = (sender.ToString()).Contains("True");
                File_Key = isChecked == true ? ".html" : ".php";
                GC.Collect(GC.GetGeneration(isChecked),GCCollectionMode.Forced);
        }
        public void php_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked;
                isChecked = (sender.ToString()).Contains("True");
                File_Key = isChecked == true ? ".php":".html";
                GC.Collect(GC.GetGeneration(isChecked), GCCollectionMode.Forced);
        }
        private void Template_Reload_Click(object sender, EventArgs e)
        {
            //string template = "<!DOCTYPE html>\n" + "< html lang = "+"en"+" >\n"+"< head >\n< meta charset"+" = "+"UTF-8"+" >"+"\n< title > Title </ title >\n</ head >\n< body >\n"+"< script language = "+"javascript"+" type ="+"text/javascript"+">\n\n</ script >\n</ body >\n</ html >";
            /*string dir = System.IO.Path.Combine(c_path, @"\Html\Template.html");
            string fullpath = c_path + dir;
            long size = new System.IO.FileInfo(fullpath).Length;
            if (System.IO.File.Exists(fullpath) == true && size > 0)
            {
                richTextBox1.LoadFile(fullpath, RichTextBoxStreamType.PlainText);
            }
            else
            {
                string Dir_To_Create = System.IO.Path.Combine(c_path,@"\Html");
                string fulldir = c_path + Dir_To_Create;
                if (System.IO.Directory.Exists(fulldir) == true)
                {
                    System.IO.DirectoryInfo di = System.IO.Directory.CreateDirectory(fulldir);
                    System.IO.File.Create(fullpath);
                    MessageBox.Show(""+di);
                    System.IO.Directory.SetCreationTimeUtc(fulldir, DateTime.Now);
                } 
                System.IO.File.WriteAllText(fullpath, template);
                richTextBox1.LoadFile(fullpath, RichTextBoxStreamType.PlainText);
            }*/
            richTextBox1.Rtf = rich_template;
        }

       private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text != "" && richTextBox1.SelectedRtf != "") 
            { 
            Clipboard.SetText(richTextBox1.SelectedText);
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectedText != "")
            { 
            richTextBox1.SelectedText = Clipboard.GetText();
            }
            else if (Clipboard.ContainsText() == true)
            {
                richTextBox1.Text += Clipboard.GetText();
            }
			Clipboard.Clear();
        }

        private void about_this_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Simple html/php code tester\n"+"This Program will take code you type into the textbox on the left and will run it on the webview to the right\n"+"this program is useful for building and testing webcode\n");
            saveFileDialog1.Filter = "Html Files (*.html)|*.html|PHP files (*.php)|*.php";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    FileName = saveFileDialog1.FileName;
                    DirName = System.IO.Path.GetDirectoryName(FileName);
                    richTextBox1.SaveFile(FileName, RichTextBoxStreamType.PlainText);
                }
                catch (Exception ex)
                {
                    /*string message="Test";
                    int length = message.Length;
                    IntPtr stPtr = System.Runtime.InteropServices.Marshal.StringToHGlobalAnsi(message);
                    IntPtr dptr = System.Runtime.InteropServices.Marshal.AllocHGlobal(length + 1);*/
                    //Message.Create();
                    MessageBox.Show(""+ex);
                }
                finally
                {

                }
            }
        }

        private void changeFileTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form2 = new Form();
            RadioButton php = new RadioButton();
            RadioButton html = new RadioButton();
            /*RadioButton css = new RadioButton();
            RadioButton js = new RadioButton();*/
            Label label1 = new System.Windows.Forms.Label();
            html.AutoSize = true;
            html.Location = new System.Drawing.Point(162, 29);
            html.Name = "html";
            html.Text = ".html";
            html.Size = new System.Drawing.Size(47, 17);
            html.UseVisualStyleBackColor = true;
            html.CheckedChanged += new EventHandler(html_CheckedChanged);
            php.Location = new System.Drawing.Point(15, 29);
            php.Size = new System.Drawing.Size(46, 17);
            php.Name = "php";
            php.Text = ".php";
            php.UseVisualStyleBackColor = true;
            php.CheckedChanged += new System.EventHandler(this.php_CheckedChanged);
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(12, 9);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(197, 17);
            label1.TabIndex = 2;
            label1.Text = "Select the web document type";
            form2.Size = new System.Drawing.Size(315, 110);
            form2.Controls.Add(label1);
            form2.Controls.Add(php);
            form2.Controls.Add(html);
            form2.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            form2.Name = "Form2";
            form2.Text = "DocumentType";
            form2.ShowDialog();
            if (php.Checked == true)
            {
                File_Key = ".php";
            }
            else if (html.Checked == true)
            {
                File_Key = ".html";
            }
            else
            {
                File_Key = "";
            }
        }
    public void update_Status()
        {
            Form form2 = new Form();
            RadioButton php = new RadioButton();
            RadioButton html = new RadioButton();
            Label label1 = new System.Windows.Forms.Label();
            html.AutoSize = true;
            html.Location = new System.Drawing.Point(162, 29);
            html.Name = "html";
            html.Text = ".html";
            html.Size = new System.Drawing.Size(47, 17);
            html.UseVisualStyleBackColor = true;
            html.CheckedChanged += new EventHandler(html_CheckedChanged);
            php.Location = new System.Drawing.Point(15, 29);
            php.Size = new System.Drawing.Size(46, 17);
            php.Name = "php";
            php.Text = ".php";
            php.UseVisualStyleBackColor = true;
            php.CheckedChanged += new System.EventHandler(this.php_CheckedChanged);
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(12, 9);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(197, 17);
            label1.TabIndex = 2;
            label1.Text = "Select the web document type";
            form2.Size = new System.Drawing.Size(315, 110);
            form2.Controls.Add(label1);
            form2.Controls.Add(php);
            form2.Controls.Add(html);
            form2.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            form2.Name = "Form2";
            form2.Text = "DocumentType";
            form2.ShowDialog();
            if (button2 != null)
            {
                //this.changeCursor(Cursors.WaitCursor);
                /*setCursor cursors = new setCursor(changeCursor);
                this.Invoke(cursors, new setCursor[] { cursors });
                /*object cursor = Cursors.WaitCursor;
                this.Invoke(update_Status,object[]{ cursor });*/
            button2.MouseClick += new MouseEventHandler(Display_Clicked);
            }
        }
        public void Display_Clicked(object sender, MouseEventArgs e)
        {
            Form_name = "Rendering...";
            this.Text = Form_name;
            webBrowser1.DocumentCompleted += WebBrowser1_DocumentCompleted;
        }

        private void WebBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            this.Text = "WebEditor";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
            richTextBox1.Focus();
        }
        /*private string[] populateSuggestions(string text)
{
string rtb_contents = richTextBox1.Text;
string[] js_keywords = {"var","function"};
string store="";
int length=0;
bool isDone = false;
bool IsValidProp=false;
//Match m = Regex.Match(rtb_contents, js_keywords[0]);
Match m1 = Regex.Match(rtb_contents, js_keywords[1]);
foreach(Match m in Regex.Matches(rtb_contents, js_keywords[0]))
{
int temp_index = m.Index;
int count = m.Index+2;
string temp = rtb_contents.Substring(temp_index+1, temp_index+1);
string pass_to_store="";
if (temp == " ")
{
  IsValidProp = true;

  do { temp = rtb_contents.Substring(count, count);if (temp != "=" || temp != ";" || temp != " ") { pass_to_store += temp; } else { } } while (isDone == false);
  store += IsValidProp == true ? m.Value : "";
  store += IsValidProp == true ? "," : "";
}
else
{

}
}
return js_keywords;
}*/

        /*private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }*/
        /*public void changeCursor(Cursor cursor)
{
setCursor cursors = new setCursor(changeCursor);
this.Invoke(cursors, cursors);
}
/*public bool name_stop(object input)
{
bool evaluation;
return false;
}
public new TimerStop
{
get{}
}*/
    }
}
/*partial class Form2 : Form
{
public Form2()
    {
        Form form2 = new Form();
        RadioButton php = new RadioButton();
        RadioButton html = new RadioButton();
        Label label1 = new System.Windows.Forms.Label();
        html.AutoSize = true;
        html.Location = new System.Drawing.Point(162, 29);
        html.Name = "html";
        html.Text = ".html";
        html.Size = new System.Drawing.Size(47, 17);
        html.UseVisualStyleBackColor = true;
        html.CheckedChanged += new EventHandler(html_CheckedChanged);
        php.Location = new System.Drawing.Point(15, 29);
        php.Size = new System.Drawing.Size(46, 17);
        php.Name = "php";
        php.Text = ".php";
        php.UseVisualStyleBackColor = true;
        php.CheckedChanged += new System.EventHandler(php_CheckedChanged);
        label1.AutoSize = true;
        label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        label1.Location = new System.Drawing.Point(12, 9);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(197, 17);
        label1.TabIndex = 2;
        label1.Text = "Select the web document type";
        form2.Size = new System.Drawing.Size(315, 110);
        form2.Controls.Add(label1);
        form2.Controls.Add(php);
        form2.Controls.Add(html);
        form2.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
        form2.Name = "Form2";
        form2.Text = "DocumentType";
        form2.ShowDialog();
    }
    public void html_CheckedChanged(object sender, EventArgs e)
    {
        bool isChecked;
        isChecked = (sender.ToString()).Contains("True");
        FileKey(ref isChecked,".html");
    }
    public void php_CheckedChanged(object sender, EventArgs e)
    {
        bool isChecked;
        isChecked = (sender.ToString()).Contains("True");
        FileKey(ref isChecked, ".php");
    }
    private string FileKey(ref bool IsFileKey, string possible_key)
    {
        string FileKey = IsFileKey == true ? possible_key:"";
        return FileKey;
    }
}*/