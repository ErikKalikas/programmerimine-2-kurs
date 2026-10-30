using System;
using System.Drawing;
using System.Windows.Forms;

namespace Iseseisevtöö_Kolm_rakendust
{
    public partial class Avavorm : Form
    {
        private PictureBox kartinka;
        private Button avaleht;
        private Button btnPictureViewer;
        private Button btnMathQuiz;
        private Button btnMatchingGame;
        private Label silt = new Label();

        public Avavorm()
        {
            InitializeComponent();

            Height = 600;
            Width = 1000;
            Text = "Naidis IKTpv25 windows forms";

            // Picture viewer
            btnPictureViewer = new Button();
            btnPictureViewer.Text = "picture viewer";
            btnPictureViewer.Location = new Point(50, 100);
            btnPictureViewer.Size = new Size(150, 40);
            btnPictureViewer.Click += Button_Click;

            // Math quiz
            btnMathQuiz = new Button();
            btnMathQuiz.Text = "math quiz";
            btnMathQuiz.Location = new Point(50, 150);
            btnMathQuiz.Size = new Size(150, 40);
            btnMathQuiz.Click += Button_Click;

            // Matching game
            btnMatchingGame = new Button();
            btnMatchingGame.Text = "matching game";
            btnMatchingGame.Location = new Point(50, 200);
            btnMatchingGame.Size = new Size(150, 40);
            btnMatchingGame.Click += Button_Click;

            silt.Text = "Tere tulemast!";
            silt.Location = new Point(300, 10);
            silt.AutoSize = true;
            silt.Font = new Font("Arial", 16, FontStyle.Bold);
            silt.ForeColor = Color.Black;


            BackgroundImage = Image.FromFile(@"..\..\Pildid\Kot.png");
            BackgroundImageLayout = ImageLayout.Stretch;

            Controls.Add(btnPictureViewer);
            Controls.Add(btnMathQuiz);
            Controls.Add(btnMatchingGame);
            Controls.Add(silt);
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button vajutatudNupp = sender as Button;

            if (vajutatudNupp == null)
            {
                return;
            }
                

            if (vajutatudNupp.Text == "picture viewer")
            {
                PictureViewerForm pictureForm = new PictureViewerForm();

                pictureForm.FormClosed += (s, args) => this.Show();

                pictureForm.Show();
                this.Hide();
            }
            else if (vajutatudNupp.Text == "math quiz")
            {
                MathQuizForm form = new MathQuizForm();

                form.FormClosed += (s, args) => this.Show();

                form.Show();
                this.Hide();
            }
            else if (vajutatudNupp.Text == "matching game")
            {
                MatchingGameForm gameForm = new MatchingGameForm();

                gameForm.FormClosed += (s, args) => this.Show();

                gameForm.Show();
                this.Hide();
            }
        }

        

        
    }
}
