using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphsForms
{
    public partial class Main : Form
    {
        Graph g = new Graph(6, true);

        public void GenerateGraph()
        {
            foreach (Control x in this.Controls)
            {
                string str = x.Name.ToString();

                if (x is TextBox && x.Text.ToString() == "1")
                {

                    str = Regex.Replace(str, "[^0-9]+", string.Empty);
                    int[] edges = str.Select(c => c - '0').ToArray();
                    edges = Array.ConvertAll(edges, y => y - 1);
                    
                    resultTextBox.Text = edges[1].ToString()+edges[0].ToString();

                    

                    g.AddEdge(edges[0] - 1, edges[1] -1);

                }
                else
                {
                    //label13.Visible = true;
                }
            }
        }

        public Main()
        {
            var adj = new TextBox[10];
            for (int i = 0; i < adj.Length; i++) {
                adj[i] = new TextBox();
                adj[i].Text = i.ToString();
                adj[i].Top = i*20;
                this.Controls.Add(adj[i]);
            }
            InitializeComponent();
        }

        private void textBox1_1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            GenerateGraph();
            //foreach (var item in g.BreadthFirstSearch(2)) {
            //    resultTextBox.Text = item.ToString();
            //}
        }
    }
}
//śmietanowy + fontanna
//algorytm kolorowania 