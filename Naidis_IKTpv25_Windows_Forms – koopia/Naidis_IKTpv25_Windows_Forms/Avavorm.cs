using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Naidis_IKTpv25_Windows_Forms
{
    public partial class Avavorm : Form
    {
        TreeView tree;
        Button nupp;
        Label silt;
        PictureBox pilt;
        CheckBox mruut1, mruut2;
        RadioButton rnupp1, rnupp2;
        TextBox tbox;
        TabControl tabs;
        TabPage tab1, tab2, tab3;
        ListBox lb;

        public Avavorm()
        {
            Height = 600;
            Width = 1000;
            Text = "Naidis IKTpv25 windows forms";

            tree = new TreeView();
            tree.Dock = DockStyle.Left;
            tree.AfterSelect += Tree_AfterSelect;

            TreeNode tn = new TreeNode("Elemendid");
            tn.Nodes.Add(new TreeNode("Nupp"));
            tn.Nodes.Add(new TreeNode("Silt"));
            tn.Nodes.Add(new TreeNode("Pilt"));
            tn.Nodes.Add(new TreeNode("Märkeruut"));
            tn.Nodes.Add(new TreeNode("Radionuupud"));
            tn.Nodes.Add(new TreeNode("Tekstiväli"));
            tn.Nodes.Add(new TreeNode("Vahekaardid"));
            tn.Nodes.Add(new TreeNode("ListBox"));
            tn.Nodes.Add(new TreeNode("DataGridView"));
            tn.Nodes.Add(new TreeNode("MainMenu"));

            tree.Nodes.Add(tn);

            // Nupp
            nupp = new Button();
            nupp.Text = "Vajuta mind";
            nupp.Location = new Point(300, 100);
            nupp.Height = 50;
            nupp.Width = 100;
            nupp.Click += (sender, e) =>
            {
                MessageBox.Show("Nuppu vajutati");
            };

            // Silt
            silt = new Label();
            silt.Text = "See on silt";
            silt.Location = new Point(300, 200);
            silt.AutoSize = true;
            silt.MouseLeave += Silt_MouseLeave;

            // Pilt
            pilt = new PictureBox();

            try
            {
                pilt.Image = Image.FromFile(@"..\..\Pildid\R2D2.png");
            }
            catch
            {
                MessageBox.Show("Pilti R2D2.png ei leitud!");
            }

            pilt.Location = new Point(300, 300);
            pilt.Size = new Size(200, 200);
            pilt.SizeMode = PictureBoxSizeMode.StretchImage;
            pilt.DoubleClick += Pilt_DoubleClick;

            Controls.Add(tree);
        }

        private void Silt_MouseLeave(object sender, EventArgs e)
        {
            silt.BackColor = Color.LightGray;
            silt.BorderStyle = BorderStyle.Fixed3D;
        }

        private void Pilt_DoubleClick(object sender, EventArgs e)
        {
            Size väike = new Size(200, 200);
            Size suur = new Size(400, 400);

            if (pilt.Size == suur)
                pilt.Size = väike;
            else
                pilt.Size = suur;
        }

        private void Tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Text == "Nupp")
            {
                Controls.Add(nupp);
                tree.SelectedNode = null;
            }
            else if (e.Node.Text == "Silt")
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
                mruut1.Text = "Märkeruut 1";
                mruut1.Location = new Point(300, 400);
                mruut1.CheckedChanged += Mruut_CheckedChanged;

                mruut2 = new CheckBox();
                mruut2.Text = "Märkeruut 2";
                mruut2.Location = new Point(300, 450);
                mruut2.CheckedChanged += Mruut_CheckedChanged;

                Controls.Add(mruut1);
                Controls.Add(mruut2);
                tree.SelectedNode = null;
            }
            else if (e.Node.Text == "Radionuupud")
            {
                rnupp1 = new RadioButton();
                rnupp1.Text = "Punane";
                rnupp1.Location = new Point(200, 400);
                rnupp1.CheckedChanged += Rnupp_CheckedChanged;

                rnupp2 = new RadioButton();
                rnupp2.Text = "Sinine";
                rnupp2.Location = new Point(200, 450);
                rnupp2.CheckedChanged += Rnupp_CheckedChanged;

                Controls.Add(rnupp1);
                Controls.Add(rnupp2);
                tree.SelectedNode = null;
            }
            else if (e.Node.Text == "Tekstiväli")
            {
                tbox = new TextBox();
                tbox.Location = new Point(200, 500);
                tbox.Width = 200;

                tbox.TextChanged += (s, arg) =>
                {
                    Controls.Add(silt);

                    if (tbox.Text.Length > 0)
                    {
                        silt.Text = tbox.Text;
                    }

                    if (tbox.Text.Length == 0)
                    {
                        silt.Text = "See on silt";
                    }
                };

                Controls.Add(tbox);
                tree.SelectedNode = null;
            }
            else if (e.Node.Text == "Vahekaardid")
            {
                tabs = new TabControl();
                tabs.Location = new Point(500, 100);
                tabs.Size = new Size(400, 300);

                tab1 = new TabPage("Techno+TLN");

                WebBrowser brauser = new WebBrowser();
                brauser.Dock = DockStyle.Fill;
                brauser.ScriptErrorsSuppressed = true;
                brauser.Url = new Uri("https://www.techno.ee/");

                tab1.Controls.Add(brauser);

                tab2 = new TabPage("Tee ise");

                tab3 = new TabPage("+");

                tabs.SelectedIndexChanged += (s, arg) =>
                {
                    if (tabs.SelectedTab == tab3)
                    {
                        // 1. Küsitakse veebiaadressi (URL)
                        string veebiaadress = Interaction.InputBox(
                            "Sisesta veebiaadress, mida soovid avada:",
                            "Veebilehe avamine",
                            "https://www.google.com");

                        if (string.IsNullOrWhiteSpace(veebiaadress))
                        {
                            MessageBox.Show("Veebiaadress ei tohi olla tühi!");
                            tabs.SelectedTab = tab1;
                            return;
                        }

                        // Lisame automaatselt "https://", kui kasutaja unustas
                        if (!veebiaadress.StartsWith("http://") &&
                            !veebiaadress.StartsWith("https://"))
                        {
                            veebiaadress = "https://" + veebiaadress;
                        }

                        Uri uri;

                        if (!Uri.TryCreate(veebiaadress, UriKind.Absolute, out uri))
                        {
                            MessageBox.Show("Vale veebiaadress!");
                            tabs.SelectedTab = tab1;
                            return;
                        }

                        // Kasutame doomeeninime vahekaardi nimeks
                        string uusKardinimi = uri.Host;

                        if (uusKardinimi.StartsWith("www."))
                        {
                            uusKardinimi = uusKardinimi.Substring(4);
                        }

                        int pos = uusKardinimi.LastIndexOf('.');

                        if (pos > 0)
                        {
                            uusKardinimi = uusKardinimi.Substring(0, pos).ToUpper();
                        }

                        // 2. Kinnituse küsimine
                        var vastus = MessageBox.Show(
                            $"Kas soovid lisada uue vahekaardi nimega '{uusKardinimi}'?",
                            "Kinnita",
                            MessageBoxButtons.YesNo);

                        if (vastus == DialogResult.No)
                        {
                            tabs.SelectedTab = tab1;
                            return;
                        }

                        TabPage uusVahekaart = new TabPage(uusKardinimi);

                        WebBrowser uusBrauser = new WebBrowser();
                        uusBrauser.Dock = DockStyle.Fill;
                        uusBrauser.ScriptErrorsSuppressed = true;
                        uusBrauser.Url = uri;

                        uusVahekaart.Controls.Add(uusBrauser);

                        tabs.TabPages.Insert(tabs.TabCount - 1, uusVahekaart);
                        tabs.SelectedTab = uusVahekaart;
                    }
                };

                tabs.TabPages.Add(tab1);
                tabs.TabPages.Add(tab2);
                tabs.TabPages.Add(tab3);

                Controls.Add(tabs);
                tree.SelectedNode = null;
            }
            else if (e.Node.Text == "ListBox")
            {
                lb = new ListBox();

                lb.Location = new Point(500, 400);
                lb.Width = 150;
                lb.Height = 120;

                lb.Items.Add("Roheline");
                lb.Items.Add("Sinine");
                lb.Items.Add("Kollane");
                lb.Items.Add("Punane");

                lb.SelectedIndexChanged += Lb_SelectedIndexChanged;

                Controls.Add(lb);
                tree.SelectedNode = null;
            }
            else if (e.Node.Text == "DataGridView")
            {
                DataSet ds = new DataSet("XML fail");

                try
                {
                    ds.ReadXml(@"..\..\XMLFile1.xml");

                    DataGridView dg = new DataGridView();
                    dg.Width = 450;
                    dg.Height = 150;
                    dg.Location = new Point(500, 250);
                    dg.DataMember = "Address";
                    dg.AutoGenerateColumns = true;
                    dg.DataSource = ds;


                   

                    Controls.Add(dg);
                }
                catch
                {
                    MessageBox.Show("menu.xml faili ei leitud või failis on viga!");
                }

                tree.SelectedNode = null;
            }
            else if (e.Node.Text == "MainMenu")
            {
                MainMenu menu = new MainMenu();
                MenuItem menuFile = new MenuItem("File");
                MenuItem memuExit = new MenuItem($"Exit", new EventHandler(menuFile_exit), Shortcut.CtrlQ);
                MenuItem memuOpenForm = new MenuItem($"OpenForm", new EventHandler(menuFile_OpenForm), Shortcut.CtrlW);
                MenuItem memuHide = new MenuItem($"Hide", new EventHandler(menuFile_Hide), Shortcut.CtrlR);
                menuFile.MenuItems.Add(memuExit);
                menuFile.MenuItems.Add(memuOpenForm);
                menu.MenuItems.Add(menuFile);

                Menu = menu;
                tree.SelectedNode = null;
            }
        }

        private void menuFile_exit(object sender, EventArgs e)
        {
            Close();
        }

        private void menuFile_OpenForm(object sender, EventArgs e)
        {
            OpenForm();
        }

        private void menuFile_Hide(object sender, EventArgs e)
        {
            tabs.Hide();
        }
        private void OpenForm()
        {
            Form uusvorm = new Form();
            uusvorm.Text = "UUS VORM";
            uusvorm.Size = new Size(300, 300);
            uusvorm.StartPosition = FormStartPosition.CenterParent;
            uusvorm.Show();
        }
        private void Lb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lb.SelectedItem == null)
            {
                return;
            }

            switch (lb.SelectedItem.ToString())
            {
                case "Roheline":
                    tree.BackColor = Color.Green;
                    break;

                case "Sinine":
                    tree.BackColor = Color.Blue;
                    break;

                case "Kollane":
                    tree.BackColor = Color.Yellow;
                    break;

                case "Punane":
                    tree.BackColor = Color.Red;
                    break;

                default:
                    break;
            }
        }

        private void Rnupp_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton nupp = sender as RadioButton;

            if (nupp == rnupp1 && nupp.Checked)
            {
                BackColor = Color.Red;
            }
            else if (nupp == rnupp2 && nupp.Checked)
            {
                BackColor = Color.Blue;
            }
        }

        private void Mruut_CheckedChanged(object sender, EventArgs e)
        {
            if (mruut1 != null && mruut2 != null)
            {
                if (mruut1.Checked && mruut2.Checked)
                {
                    BackColor = Color.Green;
                }
                else if (mruut1.Checked)
                {
                    BackColor = Color.Yellow;
                }
                else if (mruut2.Checked)
                {
                    BackColor = Color.Orange;
                }
                else
                {
                    BackColor = SystemColors.Control;
                }
            }
        }
    }
}