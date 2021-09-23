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
using FE3D.Image;
using SPICA.Formats.CtrH3D;
using SPICA.Formats.CtrGfx;
using SPICA.Formats.Generic.COLLADA;
using SPICA.Formats.Generic.StudioMdl;
using SPICA.Formats.CtrH3D.Texture;

namespace FEAT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            #region Button Clicks
            lZ10CompressionToolStripMenuItem.Click += (sender, EventArgs) => { int Type = 10; CompressionButton_Click(sender, EventArgs, Type); };
            lZ11ToolStripMenuItem.Click += (sender, EventArgs) => { int Type = 11; CompressionButton_Click(sender, EventArgs, Type); };
            lZ13ToolStripMenuItem.Click += (sender, EventArgs) => { int Type = 13; CompressionButton_Click(sender, EventArgs, Type); };
            bytesToolStripMenuItem.Click += (sender, EventArgs) => { int Align = 0; AlignmentButton_Click(sender, EventArgs, Align); };
            bytesToolStripMenuItem1.Click += (sender, EventArgs) => { int Align = 4; AlignmentButton_Click(sender, EventArgs, Align); };
            bytesToolStripMenuItem2.Click += (sender, EventArgs) => { int Align = 8; AlignmentButton_Click(sender, EventArgs, Align); };
            bytesToolStripMenuItem3.Click += (sender, EventArgs) => { int Align = 16; AlignmentButton_Click(sender, EventArgs, Align); };
            bytesToolStripMenuItem4.Click += (sender, EventArgs) => { int Align = 32; AlignmentButton_Click(sender, EventArgs, Align); };
            bytesToolStripMenuItem5.Click += (sender, EventArgs) => { int Align = 64; AlignmentButton_Click(sender, EventArgs, Align); };
            bytesToolStripMenuItem6.Click += (sender, EventArgs) => { int Align = 128; AlignmentButton_Click(sender, EventArgs, Align); };
            #endregion
        }
        private volatile int threads;
        private string Selected_Path;
        private uint Alignment = 128;

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
                if (ModifierKeys == Keys.Control)
                {
                    AddText(richTextBox1, $"Building Arc from {Path.GetFileName(infile)}..."); 
                    FEArc.PackArc(infile, Alignment, enablePaddingToolStripMenuItem.Checked);
                    AddLine(richTextBox1, "Done");
                }
                else if (ModifierKeys == Keys.Shift)
                {
                    AddText(richTextBox1, $"Building BCH from {Path.GetFileName(infile)}...");

                    if (File.Exists(infile + ".bch"))
                        File.Delete(infile + ".bch");

                    List<string> files = Directory.GetFiles(infile, "*.*", SearchOption.AllDirectories).ToList();
                    H3D Scene = new H3D();
                    foreach (string file in files)
                    {
                        Bitmap texture;
                        try
                        {
                            texture = (Bitmap)Bitmap.FromFile(file);
                        }
                        catch (OutOfMemoryException)
                        {
                            Console.WriteLine("invalid image format, skipping");
                            continue;
                        }
                        Scene.Textures.Add(new H3DTexture(Path.GetFileNameWithoutExtension(file), texture, SPICA.PICA.Commands.PICATextureFormat.RGBA8));
                    }

                    if (Scene.Textures.Count <= 0)
                    {
                        AddLine(richTextBox1, "Error");
                        AddLine(richTextBox1, $"No images found in {Path.GetFileName(infile)}");
                    }
                    else
                    {
                        H3D.Save($"{infile}.bch", Scene);
                        AddLine(richTextBox1, "Done");
                    }
                    return;
                }
                else if (ModifierKeys == Keys.Alt)
                {
                    AddText(richTextBox1, $"Building CTPK from {Path.GetFileName(infile)}...");
                    CTPK.MakeCTPK(infile);
                    AddLine(richTextBox1, "Done");
                }
                else
                {
                    foreach (string p in (new DirectoryInfo(infile)).GetFiles().Select(f => f.FullName))
                        Open(p);
                    foreach (string p in (new DirectoryInfo(infile)).GetDirectories().Select(f => f.FullName))
                        Open(p);
                }
            }
            else if (File.Exists(infile))
            {
                byte[] data = File.ReadAllBytes(infile);
                string magic = FEIO.GetMagic(data);
                string ext = Path.GetExtension(infile);

                if (ModifierKeys == Keys.Control || batchCompressToolStripMenuItem.Checked) // Compression Method
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
                else if (ext == ".lz" || magic == "Yaz0" || ext == ".cms" || ext == ".cmp") // Decompress Method
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
                    if (File.Exists(infile.Replace(".lz", "")) && autoExtractToolStripMenuItem.Checked)
                        Open(infile.Replace(".lz",""));
                }
                else if (ext == ".arc") //Archive file
                {
                    AddText(richTextBox1, $"Extract Files from {Path.GetFileName(infile)}...");
                    FEArc.ExtractArc(infile.Replace(ext, ""), data);
                    AddLine(richTextBox1, "Done");
                }
                else if (magic == "BCH" || magic == "CGFX") //BCH / Bcres file
                {
                    H3D Scene = new H3D();
                    if (magic == "CGFX")
                        Scene = Gfx.Open(infile).ToH3D();
                    else
                        Scene = H3D.Open(data);

                    if (Directory.Exists(infile.Replace(ext, "")))
                        Directory.Delete(infile.Replace(ext, ""), true);
                    Directory.CreateDirectory(infile.Replace(ext, ""));

                    //Export method for textures, this is always enabled by default
                    if (Scene.Textures.Count > 0)
                    {
                        AddText(richTextBox1, $"Extracting Textures from {Path.GetFileName(infile)}...");
                        foreach (var texture in Scene.Textures)
                        {
                            Image img = texture.ToBitmap();
                            img.Save($"{infile.Replace(ext,"")}\\{texture.Name}.png", System.Drawing.Imaging.ImageFormat.Png);
                        }
                        AddLine(richTextBox1, "Done");
                    }
                    if (exportDaeToolStripMenuItem.Checked || exportSMDToolStripMenuItem.Checked && Scene.Models.Count > 0)
                    {
                        AddText(richTextBox1, $"Extracting Models from {Path.GetFileName(infile)}...");
                        for (int i = 0; i < Scene.Models.Count; i++)
                        {
                            if (exportDaeToolStripMenuItem.Checked)
                            {
                                DAE dae = new DAE(Scene, i);
                                dae.Save($"{infile.Replace(ext, "")}\\{Scene.Models[i].Name}.dae");
                            }
                            if (exportSMDToolStripMenuItem.Checked)
                            {
                                SMD smd = new SMD(Scene, i);
                                smd.Save($"{infile.Replace(ext, "")}\\{Scene.Models[i].Name}.smd");
                            }
                        }
                        AddLine(richTextBox1, "Done");
                    }
                }
                else if (magic == "CTPK") //CTPK file
                {
                    AddText(richTextBox1, $"Extract Textures from {Path.GetFileName(infile)}...");
                    CTPK.ExtractCTPK(infile);
                    AddLine(richTextBox1, "Done");
                }
                else if (ext == ".bin")
                {
                    if (FEIO.ReadStringFromArray(data, Encoding.UTF8, 0x20).Contains("MESS_ARCHIVE"))
                    {
                        AddText(richTextBox1, $"Extracting Message Archive {Path.GetFileName(infile)}...");
                        FEMessage.ExtractMessage(infile.Replace(ext, ".txt"), data);
                        AddLine(richTextBox1, "Done");
                    }
                    else if (enableBinDecomplingToolStripMenuItem.Checked)
                    {
                        AddText(richTextBox1, $"Decompiling {Path.GetFileName(infile)} to txt...");
                        FEBin.ExtractBin(infile);
                        AddLine(richTextBox1, "Done");
                    }
                }
                if (deleteAfterProcessingToolStripMenuItem.Checked)
                    File.Delete(infile);
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

        private void AlignmentButton_Click(object sender, EventArgs e, int Align)
        {
            bytesToolStripMenuItem.Checked = false;
            bytesToolStripMenuItem1.Checked = false;
            bytesToolStripMenuItem2.Checked = false;
            bytesToolStripMenuItem3.Checked = false;
            bytesToolStripMenuItem4.Checked = false;
            bytesToolStripMenuItem5.Checked = false;
            bytesToolStripMenuItem6.Checked = false;

            switch (Align)
            {
                case 0:
                    bytesToolStripMenuItem.Checked = true;
                    Alignment = 0;
                    break;
                case 4:
                    bytesToolStripMenuItem1.Checked = true;
                    Alignment = 4;
                    break;
                case 8:
                    bytesToolStripMenuItem2.Checked = true;
                    Alignment = 8;
                    break;
                case 16:
                    bytesToolStripMenuItem3.Checked = true;
                    Alignment = 16;
                    break;
                case 32:
                    bytesToolStripMenuItem4.Checked = true;
                    Alignment = 32;
                    break;
                case 64:
                    bytesToolStripMenuItem5.Checked = true;
                    Alignment = 64;
                    break;
                case 128:
                    bytesToolStripMenuItem6.Checked = true;
                    Alignment = 128;
                    break;
            }
        }

        #endregion

        #region Buttons

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (threads > 0)
            {
                MessageBox.Show("Please wait until all operations are finished.");
                return;
            }
            goToolStripMenuItem.Enabled = false;
            CommonDialog dialog;
            if (ModifierKeys == Keys.Alt)
                dialog = new FolderBrowserDialog();
            else
                dialog = new OpenFileDialog();
            if (dialog.ShowDialog() != DialogResult.OK) return;

            if (dialog is OpenFileDialog)
                textBox1.Text = (dialog as OpenFileDialog).FileName;
            else textBox1.Text = (dialog as FolderBrowserDialog).SelectedPath;
            goToolStripMenuItem.Enabled = true;
        }

        private void goToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (threads > 0)
            {
                MessageBox.Show("Please wait until all operations are finished.");
                return;
            }
            new Thread(() =>
            {
                threads++;
                Open(Selected_Path);
                threads--;
            }).Start();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            string message = "Basic Operations:\n" +
                "Ctrl + Drag File to Compress\nCtrl + Drag Folder to make arc\nShift + Drag Folder to make BCH\nAlt + Drag Folder to make ctpk\n\n" +
                "Options:\n" +
                "Auto Extract will process the file again after decompressing\nBatch Compress will compress every file that's dragged in\n" +
                "Delete after Procress will Delete the file after it's been used\nArc Options gives different options for the arc builder\n" +
                "Compression Options sets which compression method to use when compressing\nModel Options allows exporting models like textures\n" +
                "Enable Bin Decompiling allows bin files to be decompiled into text based files";
            AddLine(richTextBox1, message);
        }

        private void richTextBox1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            AddLine(richTextBox1, "Open a file, or Drag/Drop several! Click this box to clear its text.");
        }

        private void creditsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            string message = "FEAT - Fire Emblem Archive Tool\nv3.0\n\n" +
                "FEAT Credits:\nSciresM: Original Creator\nMoonling: Coder, FE3D Library\n" +
                "FE3D Library Credits:\nMoonling: Creator\nBarubary: DSDecmp\nGovanifY: BinaryStream\ngdkchan: SPICA\nSciresM: FEAT";
            AddLine(richTextBox1, message);
        }

        #endregion
    }
}
