/* Jhenna-Rae Foronda-Caldetera, 11423409 
 * CPTS 321, SPRING 2017, February 2
 * HW3 - Notepad Application / Fibonacci Text Reader
 * Save and load files that contain Fibonacci sequence */


using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Windows.Forms;

namespace FibonacciNotepad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public class FibTextReader : TextReader
        {
            StringBuilder fib = new StringBuilder();
            int lines;

            // constructor that takes maxLines 
            public FibTextReader(int maxLines)
            { lines = maxLines; }

            // override function
            public override string ReadToEnd()
            {
                StringBuilder incmFib = new StringBuilder();

                for (int i = 0; i < lines; i++)
                {
                   
                    incmFib.Append(i + 1);
                    incmFib.Append(": ");
                    incmFib.Append(FibSeq(i));
                    incmFib.AppendLine();

                }
                string FIB = incmFib.ToString();
                return (FIB);
            }
        }

        // this function calculates the Fibonacci sequence
        static BigInteger FibSeq(int num)
        {
            BigInteger result = 0;
            BigInteger current = 1;
            
            // two special cases
            if (num == 0)
            { return 0; }

            if (num == 1)
            { return 1; }

            for (int i = 0; i < num; i++)
            {
                BigInteger temp = result;
                result = current;
                current = temp + current;
            }
            return result;
        }
       
        
        private void LoadText(TextReader sr)
        {
            textBox1.Text = sr.ReadToEnd();
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        // Event handler for when "Load from file..." is clicked
        private void loadFromFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // referenced MSDN .NET example 
                string fileName = openFileDialog1.FileName;
                StreamReader openFile = new StreamReader(fileName);
                LoadText(openFile);
                openFile.Dispose();
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        // this function loads the first 50 numbers of the Fibonacci sequence
        private void loadFibonacciNumbersfirst50ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FibTextReader seq = new FibTextReader(50);
            LoadText(seq);
        }

        // this function loads the first 100 bumbers of the Fibonacci sequence
        private void loadFibonacciNumbersfirst100ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FibTextReader seq = new FibTextReader(100);
            LoadText(seq);
        }

        // event handler for when "Save to file... " is clicked
        private void saveToFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            // referenced MSDN .NET example 
            saveFileDialog1.Filter = "txt files (.*txt) | *.txt | All files (*.*) | *.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            { File.WriteAllText(saveFileDialog1.FileName, textBox1.Text); }
            
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}
