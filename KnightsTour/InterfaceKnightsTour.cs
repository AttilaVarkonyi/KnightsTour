using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KnightsTour
{
    public partial class InterfaceKnightsTour : UserControl
    {
        public InterfaceKnightsTour()
        {
            InitializeComponent();
        }

        public Algorithm SelectedAlgorithm
        {
            get
            {
                return (Algorithm)comboBox1.SelectedItem;
            }
        }

        private void InterfaceKnightsTour_Load(object sender, EventArgs e)
        {
            List<Algorithm> list = new List<Algorithm>();
            list.Add(new Algorithm() { Name = "Backtracking" });
            list.Add(new Algorithm() { Name = "Genetic algorithm" });
            list.Add(new Algorithm() { Name = "Brute-force search" });
            list.Add(new Algorithm() { Name = "Warnsdorff's rule" });
            comboBox1.DataSource = list;
            comboBox1.DisplayMember = "Name";
        }
    }
}
