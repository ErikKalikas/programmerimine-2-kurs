using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Naidis_IKTpv25_Windows_Forms
{
    public partial class Form1 : Form
    {
        Button nupp;
        Label silt;
        TreeView tree;
        PictureBox pilt;
        CheckBox mruut1, mruut2;
        RadioButton rnupp1, rnupp2;
        TextBox tbox;


        public Form1()
        {
            Height = 600;
            Width = 1000;
            Text = "Naidis IKTpv25 Windows Forms";

            tree = new TreeView();
            tree.Dock = DockStyle.Left;
            tree.AfterSelect += tree_AfterSelect;

            TreeNode tn = new TreeNode("Elemendid");
            tn.Nodes.Add(new TreeNode("Nupp"));
            tn.Nodes.Add(new TreeNode("silt"));
            tn.Nodes.Add(new TreeNode("Pilt"));
            tn.Nodes.Add(new TreeNode("Märkeruut"));
            tn.Nodes.Add(new TreeNode("Radionupp"));
            tn.Nodes.Add(new TreeNode("tekstiväli"));

            tree.Nodes.Add(tn);

            //nupp stil ja pilt
            nupp = new Button();
            nupp.Text = "Vajuta mind";
            nupp.Location = new Point(300, 100);
            nupp.Height = 50;
            nupp.Width = 100;
            nupp.Click += (sender, e) => { MessageBox.Show("Nuppu vajutalt!"); };
            nupp.BackColor = Color.Yellow;

            silt = new Label();
            silt.Text = "See on silt";
            silt.Location = new Point(300, 200);
            silt.AutoSize = true;
            silt.MouseLeave += silt_MouseLeave;
            silt.MouseHover += silt_MouseHover;

            pilt = new PictureBox();
            pilt.Image = Image.FromFile(@"..\..\Pildid\lodus.png");
            pilt.Location = new Point(300, 300);
            pilt.Size = new Size(100, 100);
            pilt.SizeMode = PictureBoxSizeMode.StretchImage;
            pilt.DoubleClick += Pilt_Doubleclick;

            Controls.Add(tree);
        }

        private void Pilt_Doubleclick(object sender, EventArgs e)
        {
            Size väike = new Size(200, 200);
            Size suur = new Size(400, 400);

            if (pilt.Size == suur)
                pilt.Size = väike;
            else
                pilt.Size = suur;
        }

        private void silt_MouseHover(object sender, EventArgs e)
        {
            silt.BackColor = Color.LightBlue;
            silt.BorderStyle = BorderStyle.Fixed3D;
        }

        private void silt_MouseLeave(object sender, EventArgs e)
        {
            silt.BackColor = Color.Gray;
            silt.BorderStyle = BorderStyle.None;
        }

        private void tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            {
                if (e.Node.Text == "Nupp")
                {
                    Controls.Add(nupp);
                    tree.SelectedNode = null;
                }
                else if (e.Node.Text == "stil")
                {
                    Controls.Add(silt);
                    tree.SelectedNode = null;
                }
                else if (e.Node.Text == "Pilt")
                {
                    Controls.Add(pilt);
                    tree.SelectedNode = null;
                }
                else if (e.Node.Text == "Märkeruut")
                {
                    mruut1 = new CheckBox();
                    mruut1.Text = "Tee väiksem";
                    mruut1.Location = new Point(300, 400);
                    mruut1.CheckedChanged += Mruut1_CheckedChanged;

                    mruut2 = new CheckBox();
                    mruut2.Text = "Näita pilt";
                    mruut2.Location = new Point(300, 450);
                    mruut2.CheckedChanged += Mruut2_CheckedChanged;

                    Controls.Add(mruut1);
                    Controls.Add(mruut2);
                    tree.SelectedNode = null;
                }
                else if (e.Node.Text == "Radionupp")
                {
                    rnupp1 = new RadioButton();
                    rnupp1.Text = "Roosa";
                    rnupp1.Location = new Point(200, 400);
                    rnupp1.CheckedChanged += Rnupp_CheckedChanged;

                    rnupp2 = new RadioButton();
                    rnupp2.Text = "Sinine";
                    rnupp2.Location = new Point(200, 430);
                    rnupp2.CheckedChanged += Rnupp_CheckedChanged;

                    Controls.Add(rnupp1);
                    Controls.Add(rnupp2);
                    tree.SelectedNode = null;
                }
            }
        }

        private void Rnupp_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton nupp = sender as RadioButton;

            if (nupp == rnupp1 && nupp.Checked)
            {
                BackColor = Color.Pink;
            }
            else if (nupp == rnupp2 && nupp.Checked)
            {
                BackColor = Color.Blue;
            }
        }

        private void Mruut2_CheckedChanged(object sender, EventArgs e)
        {
            Controls.Add(pilt);

            if (mruut2.Checked)
            {
                pilt.Visible = true;
                mruut2.Text = "peida pilt";
            }
            else
            {
                pilt.Visible = false;
                mruut2.Text = "Näita pilt";
            }
        }

        private void Mruut1_CheckedChanged(object sender, EventArgs e)
        {
            if (mruut1.Checked)
            {
                Size = new Size(350, 500);
                pilt.Visible = true;
                mruut1.Text = "Tee suuremaks";
            }
            else
            {
                Size = new Size(1000, 600);
                pilt.Visible = false;
                mruut1.Text = "Tee väiksemaks";
            }
        }
    }
}