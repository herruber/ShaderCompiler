using ShaderAssembler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShaderAssembler
{

    public partial class Form1 : Form
    {

        public static string destination = @"C:\Repos\Arctic Wood\ConfiguratorBasic\ConfiguratorBasic\Shaders";
        public static string chunkLib = @"C:\Users\Grävling\Downloads\three.js-dev\src\renderers\shaders\ShaderChunk";
        public ThreeShader vertex_shader;
        public ThreeShader fragment_shader;

        public Form1()
        {
            InitializeComponent();
        }

        private void pickShader_Click(object sender, EventArgs e)
        {

            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.InitialDirectory = @"C:\Users\Grävling\Downloads\three.js-dev\src\renderers\shaders\ShaderLib";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    txt_Visual.Clear();
                    var p = dlg.FileName.Split('_')[0];
                    var vert = p + "_vert.glsl";
                    var frag = p + "_frag.glsl";
                    vertex_shader = new ThreeShader(vert);
                    fragment_shader = new ThreeShader(frag);

                }
            }


        }

        private void save_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dlg = new FolderBrowserDialog())
            {
                dlg.SelectedPath = destination;

                if (dlg.ShowDialog() == DialogResult.OK)
                {

                    var vertsource = vertex_shader.Parse(chunkLib, txt_Visual);
                    var fragsource = fragment_shader.Parse(chunkLib, txt_Visual);

                    System.IO.File.WriteAllLines( dlg.SelectedPath + "/" + System.IO.Path.GetFileName(vertex_shader.FilePath) , vertsource);
                    System.IO.File.WriteAllLines(dlg.SelectedPath + "/" + System.IO.Path.GetFileName(fragment_shader.FilePath), fragsource);

                }
            }
        }

        private void txt_Visual_TextChanged(object sender, EventArgs e)
        {

        }
    }


    public class ThreeShader
    {
        public string FilePath { get; set; }
        public string Name { get; set; }
        public List<string> Chunks { get; set; }


        public ThreeShader(string path)
        {
            FilePath = path;
            Name = System.IO.Path.GetFileNameWithoutExtension(path).Split('_')[0];
        }

        public List<string> Parse(string chunkLib, RichTextBox txt)
        {

            string[] paths = System.IO.Directory.GetFiles(chunkLib);
            string[] lines = System.IO.File.ReadAllLines(FilePath);
            List<string> print = new List<string>();

            txt.AppendText("\r\n" + System.IO.Path.GetFileNameWithoutExtension(FilePath));

            foreach (var line in lines)
            {
                txt.AppendText("\r\n");

                if (!line.Contains("include"))
                {
                    print.Add(line);
                    txt.AppendText(line);
                }
                else
                {

                    string formated = line.Split(' ')[1]; //Remove #include
                    formated = formated.Remove(0, 1);
                    formated = formated.Remove(formated.Length - 1, 1);

                    foreach (var path in paths)
                    {

                        if (path.Contains(formated))
                        {

                            int start = txt.TextLength;
                            txt.AppendText(line + "\r\n");
                            int end = txt.TextLength;

                            txt.Select(start, end - start);
                            {
                                txt.SelectionColor = Color.ForestGreen;
                                // could set box.SelectionBackColor, box.SelectionFont too.
                            }
                            txt.SelectionLength = 0; // clear
                            string[] chunks = System.IO.File.ReadAllLines(path);

                            foreach (var chunk in chunks)
                            {
                                print.Add(chunk);
                                txt.AppendText(chunk + "\r\n");
                            }





                            break;
                        }

                    }

                }

            }

            return print;
        }



    }

}
