using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace KnightsTour
{
    public partial class Form1 : Form
    {
        PictureBox selected = null;
        Movement movement;

        List<PictureBox> pbList = new List<PictureBox>(); //ez nem fog kelleni
        List<int[]> tableOrderList = new List<int[]>();

        public Form1()
        {
            InitializeComponent();
            movement = new Movement();

            foreach (Control con in this.Controls)
            {
                if (con is PictureBox)
                {
                    pbList.Add((PictureBox)con);
                }
            }

            //Control.CheckForIllegalCrossThreadCalls = false;
        }

        public void select(object o)
        {
            PictureBox file = (PictureBox)o;
            selected = file;
            selected.BackColor = Color.Lime;
        }

        private void move(PictureBox frame)
        {
                if (selected != null)
                {
                    if (true) //Validation
                    {
                        Point previous = selected.Location;
                        selected.Location = frame.Location;
                        int forwardDistance = previous.Y - frame.Location.Y;

                        if (true) //Verify extra movements
                        {
                            selected.BackColor = frame.BackColor;
                            selected = null;
                        }
                    }

                }
        }

        private void frameClick(object sender, MouseEventArgs e)
        {
            move((PictureBox)sender);
        }

        private void selectAgent(object sender, MouseEventArgs e)
        {
            select(sender);
        }

        Thread thread;//

        private void StartSolution(object sender, MouseEventArgs e)
        {
            thread = new Thread(new ThreadStart(doBacktracking));
            thread.Start();
            //wait doBacktracking();
        }


        private void doBacktracking()
        {

            if (knight.InvokeRequired)
            {
               MethodInvoker AssignMethodToControl = new MethodInvoker(doBacktracking);
               knight.Invoke(AssignMethodToControl);
            }
            else
            {
                movement.move(0, 1, 0);

                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (!((i == 0 && j == 0) || (i == 0 && j == 7) || (i == 7 && j == 0) || (i == 7 && j == 7)))
                        {
                            int[] temp = new int[3] { movement.chessTableOrder[i, j], i, j };
                            tableOrderList.Add(temp);
                        }
                    }
                }

                List<int[]> sortedList = tableOrderList.OrderBy(arr => arr[0]).ToList();

                int[] previous = new int[3] { -1, -1, -1 };

                foreach (var item in sortedList)
                {
                    if (previous[1] != -1)
                    {
                        previousBox2.BackColor = Color.Lime;
                        previousBox2.Location = new Point((previous[2] + 1) * 50, (previous[1] + 1) * 50);
                        previousBox2.BorderStyle = BorderStyle.FixedSingle;
                        previousBox2.Update();
                        //await Task.Run(() => previousBoxing(previous));
                    }
                    //await Task.Run(() =>
                    //{
                    //    knight.BackColor = Color.Lime;
                    //    knight.Location = new Point((item[2] + 1) * 50, (item[1] + 1) * 50);
                    //    knight.Update();
                    //});

                    knight.BackColor = Color.Lime;
                    knight.Location = new Point((item[2] + 1) * 50, (item[1] + 1) * 50);
                    knight.Update();
                    previous = item;
                    System.Threading.Thread.Sleep(300);
                }
                MessageBox.Show("Sorting finished!");
            }           
        }

        //public void previousBoxing(int[] prev)
        //{
        //    previousBox2.BackColor = Color.Lime;
        //    previousBox2.Location = new Point((prev[2] + 1) * 50, (prev[1] + 1) * 50);
        //    previousBox2.BorderStyle = BorderStyle.FixedSingle;
        //    previousBox2.Update();
        //}

        private void btnAbort_Click(object sender, EventArgs e)
        {
            
        }
    }
}
