using parser.Core.Habra;
using System;
using System.Windows.Forms;

namespace parser
{
    public partial class Form1 : Form
    {
        ParserWorker<string[]> parser;

        public Form1()
        {
            InitializeComponent();
            parser = new ParserWorker<string[]>(new HabraParser());
            parser.OnCompleted += Parser_OnCompleted;
            parser.OnNewData += Parser_OnNewData;
        }

        private void Parser_OnNewData(object arg1, string[] arg2)
        {
            listBox1.Items.AddRange(arg2);
        }

        private void Parser_OnCompleted(object obj)
        {
            MessageBox.Show("Parser ostanovlen");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            parser.Settings = new HabraParserSettings((int)NumericStart.Value, (int)NumericEnd.Value);
            parser.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            parser.Abort();
        }
    }
}
