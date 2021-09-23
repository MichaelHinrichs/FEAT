using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using FE3D;
using FE3D.IO;

namespace FEAT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            lZ10CompressionToolStripMenuItem.Click += (sender, EventArgs) => { int Type = 10; CompressionButton_Click(sender, EventArgs, Type); };
            lZ11ToolStripMenuItem.Click += (sender, EventArgs) => { int Type = 11; CompressionButton_Click(sender, EventArgs, Type); };
            lZ13ToolStripMenuItem.Click += (sender, EventArgs) => { int Type = 13; CompressionButton_Click(sender, EventArgs, Type); };
        }
        private volatile int threads;
        private string Selected_Path;

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            if (threads > 0)
            {
                MessageBox.Show("Please wait until all operations are finished.");
                return;
            }
            new Thread(() =>
            {
                threads++;
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (string file in files)
                    Open(file);
                threads--;
            }).Start();
        }

        private void Open(string infile)
        {
            if (Directory.Exists(infile))
            {
                
            }
            else if (File.Exists(infile))
            {
                byte[] data = File.ReadAllBytes(infile);
                string magic = FEIO.GetMagic(data);
                string ext = Path.GetExtension(infile);

                if (batchCompressToolStripMenuItem.Checked)
                {

                }
                else if (ModifierKeys == Keys.Control) // Compression Method
                {
                    byte[] cmp;
                    if (lZ10CompressionToolStripMenuItem.Checked)
                    {
                        AddText(richTextBox1, $"Compressing {Path.GetFileName(infile)} to {Path.GetFileName(infile)}.lz using lz10...");
                        try
                        {
                            cmp = FEIO.LZ10Compress(data);
                        }
                        catch (Exception ex)
                        {
                            AddLine(richTextBox1, $"\nUnable to automatically Compress {Path.GetFileName(infile)}");
                            return;
                        }
                        File.WriteAllBytes(infile + ".lz", cmp);
                        AddLine(richTextBox1, "Done");
                    }
                    else if (lZ11ToolStripMenuItem.Checked)
                    {
                        AddText(richTextBox1, $"Compressing {Path.GetFileName(infile)} to {Path.GetFileName(infile)}.lz using lz11...");
                        try
                        {
                            cmp = FEIO.LZ11Compress(data);
                        }
                        catch (Exception ex)
                        {
                            AddLine(richTextBox1, $"\nUnable to automatically Compress {Path.GetFileName(infile)}");
                            return;
                        }
                        File.WriteAllBytes(infile + ".lz", cmp);
                        AddLine(richTextBox1, "Done");
                    }
                    else if (lZ13ToolStripMenuItem.Checked)
                    {
                        AddText(richTextBox1, $"Compressing {Path.GetFileName(infile)} to {Path.GetFileName(infile)}.lz using lz13...");
                        try
                        {
                            cmp = FEIO.LZ13Compress(data);
                        }
                        catch (Exception ex)
                        {
                            AddLine(richTextBox1, $"\nUnable to automatically Compress {Path.GetFileName(infile)}");
                            return;
                        }
                        File.WriteAllBytes(infile + ".lz", cmp);
                        AddLine(richTextBox1, "Done");
                    }
                    else
                        AddLine(richTextBox1, "No Compression Method Selected, How did this even happen?");
                }
                else if (ext == ".lz" || magic == "Yaz0") // Decompress Method
                {
                    byte[] dcmp;
                    if (data[0] == 0x10)
                    {
                        AddText(richTextBox1, $"Decompressing {Path.GetFileName(infile)} using lz10...");
                        try
                        {
                            dcmp = FEIO.LZ10Decompress(data);
                        }
                        catch (Exception e)
                        {
                            AddLine(richTextBox1, $"\nUnable to automatically Decompress {Path.GetFileName(infile)}");
                            return;
                        }
                        File.WriteAllBytes(infile.Replace(".lz", ""), dcmp);
                        AddLine(richTextBox1, "Done");
                    } //LZ10
                    else if (data[0] == 0x11)
                    {
                        AddText(richTextBox1, $"Decompressing {Path.GetFileName(infile)} using lz11...");
                        try
                        {
                            dcmp = FEIO.LZ11Decompress(data);
                        }
                        catch (Exception e)
                        {
                            AddLine(richTextBox1, $"\nUnable to automatically Decompress {Path.GetFileName(infile)}");
                            return;
                        }
                        File.WriteAllBytes(infile.Replace(".lz", ""), dcmp);
                        AddLine(richTextBox1, "Done");
                    } //LZ11
                    else if (data[0] == 0x13 && data[4] == 0x11)
                    {
                        AddText(richTextBox1, $"Decompressing {Path.GetFileName(infile)} using lz13...");
                        try
                        {
                            dcmp = FEIO.LZ13Decompress(data);
                        }
                        catch (Exception e)
                        {
                            AddLine(richTextBox1, $"\nUnable to automatically Decompress {Path.GetFileName(infile)}");
                            return;
                        }
                        File.WriteAllBytes(infile.Replace(".lz", ""), dcmp);
                        AddLine(richTextBox1, "Done");
                    } //LZ13
                    else if (magic == "Yaz0")
                    {
                        AddLine(richTextBox1, "Yaz0 Method not implemented");
                        return;
                    } //Yaz0
                }
            }
        }

        #region Text Box Code
        private void AddText(RichTextBox RTB, string msg)
        {
            if (RTB.InvokeRequired)
                RTB.Invoke(new Action(() => RTB.AppendText(msg)));
            else
                RTB.AppendText(msg);
        }

        private void AddLine(RichTextBox RTB, string line)
        {
            if (RTB.InvokeRequired)
                RTB.Invoke(new Action(() => RTB.AppendText(line + Environment.NewLine)));
            else
                RTB.AppendText(line + Environment.NewLine);
        }
        #endregion

        #region Check Box Code

        private void CompressionButton_Click(object sender, EventArgs e, int Type)
        {
            lZ10CompressionToolStripMenuItem.Checked = false;
            lZ11ToolStripMenuItem.Checked = false;
            lZ13ToolStripMenuItem.Checked = false;

            switch (Type)
            {
                case 10:
                    lZ10CompressionToolStripMenuItem.Checked = true;
                    break;
                case 11:
                    lZ11ToolStripMenuItem.Checked = true;
                    break;
                case 13:
                    lZ13ToolStripMenuItem.Checked = true;
                    break;
            }
        }

        #endregion
    }
}
