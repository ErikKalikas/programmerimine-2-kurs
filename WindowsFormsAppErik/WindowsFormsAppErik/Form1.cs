using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Naidis_IKTpv25_Windows_Forms
{
    public partial class Form1 : Form
    {
        private Button nupp;
        private Label silt;
        private TreeView tree;
        private PictureBox pilt;
        private CheckBox mruut1;
        private CheckBox mruut2;


    public Form1()
        {
            InitializeComponent();

            // Дерево
            tree = new TreeView();
            tree.Dock = DockStyle.Left;
            tree.Width = 180;
            tree.AfterSelect += tree_AfterSelect;

            TreeNode tn = new TreeNode("Elemendid");
            tn.Nodes.Add("Nupp");
            tn.Nodes.Add("Silt");
            tn.Nodes.Add("Pilt");
            tn.Nodes.Add("Märkeruut");

            tree.Nodes.Add(tn);

            // Кнопка
            nupp = new Button();
            nupp.Text = "Vajuta mind";
            nupp.Location = new Point(300, 100);
            nupp.Size = new Size(100, 50);
            nupp.BackColor = Color.Yellow;
            nupp.Click += Nupp_Click;

            // Надпись
            silt = new Label();
            silt.Text = "See on silt";
            silt.Location = new Point(300, 200);
            silt.AutoSize = true;
            silt.MouseHover += silt_MouseHover;
            silt.MouseLeave += silt_MouseLeave;

            // Картинка
            pilt = new PictureBox();
            pilt.Location = new Point(300, 300);
            pilt.Size = new Size(100, 100);
            pilt.SizeMode = PictureBoxSizeMode.StretchImage;
            pilt.Visible = false;
            pilt.DoubleClick += Pilt_DoubleClick;

            string imagePath = Path.Combine(
                Application.StartupPath,
                "Pildid",
                "lodus.png"
            );

            if (File.Exists(imagePath))
            {
                pilt.Image = Image.FromFile(imagePath);
            }

            Controls.Add(tree);
        }

        private void Nupp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nuppu vajutati!");
        }

        private void Pilt_DoubleClick(object sender, EventArgs e)
        {
            if (pilt.Size == new Size(400, 400))
            {
                pilt.Size = new Size(200, 200);
            }
            else
            {
                pilt.Size = new Size(400, 400);
            }
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
            if (e.Node.Text == "Nupp")
            {
                AddControl(nupp);
            }
            else if (e.Node.Text == "Silt")
            {
                AddControl(silt);
            }
            else if (e.Node.Text == "Pilt")
            {
                AddControl(pilt);
                pilt.Visible = true;
            }
            else if (e.Node.Text == "Märkeruut")
            {
                ShowCheckBoxes();
            }

            tree.SelectedNode = null;
        }

        private void ShowCheckBoxes()
        {
            if (mruut1 == null)
            {
                mruut1 = new CheckBox();
                mruut1.Text = "Tee väiksemaks";
                mruut1.Location = new Point(300, 420);
                mruut1.AutoSize = true;
                mruut1.CheckedChanged += Mruut1_CheckedChanged;

                Controls.Add(mruut1);
            }

            if (mruut2 == null)
            {
                mruut2 = new CheckBox();
                mruut2.Text = "Näita pilti";
                mruut2.Location = new Point(300, 450);
                mruut2.AutoSize = true;
                mruut2.CheckedChanged += Mruut2_CheckedChanged;

                Controls.Add(mruut2);
            }
        }

        private void Mruut1_CheckedChanged(object sender, EventArgs e)
        {
            if (mruut1.Checked)
            {
                ClientSize = new Size(350, 500);
                mruut1.Text = "Tee suuremaks";
            }
            else
            {
                ClientSize = new Size(1000, 600);
                mruut1.Text = "Tee väiksemaks";
            }
        }

        private void Mruut2_CheckedChanged(object sender, EventArgs e)
        {
            pilt.Visible = mruut2.Checked;

            if (mruut2.Checked)
            {
                mruut2.Text = "Peida pilt";
            }
            else
            {
                mruut2.Text = "Näita pilti";
            }
        }

        private void AddControl(Control control)
        {
            if (!Controls.Contains(control))
            {
                Controls.Add(control);
            }

            control.BringToFront();
        }
    }


}
