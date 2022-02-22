using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using DMessager.Example;
using DMessager.Utils;

namespace DMessager
{
    public partial class AuthForm : Form
    {
        public AuthForm()
        {
            InitializeComponent();
            new StencilWindowsForm(this).setFormParams();
        }
        
        public static TextBox loginTextBox = new ();
        private TextBox passwordTextBox = new ();
        private Size textBoxSize = new (376,28);
        private PictureBox loginPictureBox = new ();
        private PictureBox passwordPictureBox = new ();
        private Label labelAuth = new ();
        private Label labelLogin = new ();
        private Label labelPassword = new ();
        private Label authAuthButton = new ();
        private PictureBox authPictureBox = new ();
    
        [DllImport("kernel32")]
        public static extern bool AllocConsole();
        
        private void AuthForm_Load(object sender, EventArgs e)
        {
            int widthCenter = Width / 2;
            int heightCenter = Height / 2;
            

            //labelAuth
            labelAuth.Text = @"Авторизация";
            labelAuth.ForeColor = Color.White;
            labelAuth.Size = new Size(200, 40);
            labelAuth.Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelAuth.Location = new Point(widthCenter - labelAuth.Width / 2,
                (heightCenter - labelAuth.Height / 2) - 120);

            Controls.Add(labelAuth);

            //labelLogin
            labelLogin.Text = @"Логин";
            labelLogin.ForeColor = Color.FromArgb(142, 146, 151);
            labelLogin.Size = new Size(47, 20);
            labelLogin.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelLogin.Location = new Point(widthCenter - textBoxSize.Width / 2,
                (heightCenter - labelLogin.Height / 2) - 90);

            Controls.Add(labelLogin);

            //labelPassword
            labelPassword.Text = @"Пароль";
            labelPassword.ForeColor = Color.FromArgb(142, 146, 151);
            labelPassword.Size = new Size(80, 20);
            labelPassword.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelPassword.Location = new Point(widthCenter - textBoxSize.Width / 2,
                (heightCenter - labelPassword.Height / 2));

            Controls.Add(labelPassword);

            //LoginTextBox
            loginTextBox.Location = new Point(widthCenter - textBoxSize.Width / 2,
                (heightCenter - textBoxSize.Height / 2) - 57);
            loginTextBox.Size = textBoxSize;
            loginTextBox.BorderStyle = BorderStyle.None;
            loginTextBox.BackColor = Color.FromArgb(48, 51, 57);
            loginTextBox.ForeColor = Color.White;
            loginTextBox.Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Regular, GraphicsUnit.Point, 204);

            loginTextBox.KeyDown += (o, args) =>
            {
                if (args.Control & args.Alt & args.KeyCode.ToString() == "N")
                {
                    Hide();
                    AllocConsole();
                    
                    Console.WriteLine(@"Loading..");
                    Console.WriteLine(@"Сhecking port 8000");
                    Console.WriteLine(@"Starting RestAPI..");
                    Console.WriteLine(@"RestAPI started!");
                    
                    new Thread(() => 
                    {
                        Thread.CurrentThread.IsBackground = true; 
                        while (true)
                        {
                            string line = Console.ReadLine();
                            if (line.Contains("user"))
                            {
                                if (line.Contains("create"))
                                {
                                    line = line.Remove(0, 11);
                                    Console.WriteLine("User" + line + " add to system!");
                                }
                            }
                            if (line.Contains("end") || line.Contains("stop"))
                            {
                                Close();
                            }
                        }
                    }).Start();
                }
            };

            Controls.Add(loginTextBox);

            //loginPictureBox
            loginPictureBox.Image = ResourcesManager.getProjectImage("auth/auth_write.png");
            loginPictureBox.Size = new Size(400, 62);
            loginPictureBox.Location = new Point(widthCenter - loginPictureBox.Width / 2,
                (heightCenter - loginPictureBox.Height / 2) - 45);
            loginPictureBox.Name = "loginPictureBox";
            loginPictureBox.TabIndex = 0;
            loginPictureBox.TabStop = false;

            Controls.Add(loginPictureBox);

            //passwordTextBox
            passwordTextBox.Location = new Point(widthCenter - textBoxSize.Width / 2,
                (heightCenter - textBoxSize.Height / 2) + 32);
            passwordTextBox.Size = textBoxSize;
            passwordTextBox.BorderStyle = BorderStyle.None;
            passwordTextBox.BackColor = Color.FromArgb(48, 51, 57);
            passwordTextBox.ForeColor = Color.White;
            passwordTextBox.UseSystemPasswordChar = true;
            passwordTextBox.Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Regular, GraphicsUnit.Point, 204);
            
            Controls.Add(passwordTextBox);

            //passwordPictureBox
            passwordPictureBox.Image = ResourcesManager.getProjectImage("auth/auth_write.png");
            passwordPictureBox.Size = new Size(400, 62);
            passwordPictureBox.Location = new Point(widthCenter - passwordPictureBox.Width / 2,
                (heightCenter - passwordPictureBox.Height / 2) + 45);
            passwordPictureBox.Name = "passwordPictureBox";
            passwordPictureBox.TabIndex = 0;
            passwordPictureBox.TabStop = false;


            Controls.Add(passwordPictureBox);

            //authTextBox
            authAuthButton.Text = @"Aвторизоваться";
            authAuthButton.BackColor = Color.FromArgb(114, 137, 218);
            authAuthButton.ForeColor = Color.White;
            authAuthButton.Size = new Size(140, 20);
            authAuthButton.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            authAuthButton.Location = new Point(widthCenter - authAuthButton.Width / 2,
                (heightCenter - authAuthButton.Height / 2) + 125);
            authAuthButton.MouseHover += (o, args) =>
            {
                authAuthButton.BackColor = Color.FromArgb(103, 123, 196);
                authPictureBox.Image = ResourcesManager.getProjectImage("auth/auth_button_hover.png");
            };
            authAuthButton.MouseClick += openMainForm;

            Controls.Add(authAuthButton);

            //authPictureBox
            authPictureBox.Image = ResourcesManager.getProjectImage("auth/auth_button.png");
            authPictureBox.Size = new Size(400, 62);
            authPictureBox.Location = new Point(widthCenter - authPictureBox.Width / 2,
                (heightCenter - authPictureBox.Height / 2) + 135);
            authPictureBox.Name = "authPictureBox";
            authPictureBox.TabIndex = 0;
            authPictureBox.TabStop = false;
            authPictureBox.MouseHover += (o, args) =>
            {
                authAuthButton.BackColor = Color.FromArgb(103, 123, 196);
                authPictureBox.Image = ResourcesManager.getProjectImage("auth/auth_button_hover.png");
            };
            authPictureBox.MouseLeave += (o, args) =>
            {
                authAuthButton.BackColor = Color.FromArgb(114, 137, 218);
                authPictureBox.Image = ResourcesManager.getProjectImage("auth/auth_button.png");
            };
            authPictureBox.MouseClick += openMainForm;

            Controls.Add(authPictureBox);
        }

        private void openMainForm(object sender, EventArgs e)
        {
            if (passwordTextBox.Text == "123321")
            {
                Hide();
                MainForm form = new MainForm();
                form.Show();
            }
            else
            {
                MessageBox.Show(@"Данные пользователя введены не верно");
            }
        }

        private void AuthForm_Resize(object sender, EventArgs e)
        {
            int widthCenter = Width / 2;
            int heightCenter = Height / 2;
            
            //LoginTextBox
            loginTextBox.Location = new Point(widthCenter - textBoxSize.Width/2,
                (heightCenter - textBoxSize.Height / 2) - 57);
            //loginPictureBox
            loginPictureBox.Location = new Point(widthCenter - loginPictureBox.Width/2,
                (heightCenter - loginPictureBox.Height / 2) - 45);
            //passwordTextBox
            passwordTextBox.Location = new Point(widthCenter - textBoxSize.Width/2,
                (heightCenter - textBoxSize.Height / 2) + 32);
            //passwordPictureBox
            passwordPictureBox.Location = new Point(widthCenter - passwordPictureBox.Width/2,
                (heightCenter - passwordPictureBox.Height / 2) + 45);
            //labelAuth
            labelAuth.Location = new Point(widthCenter - labelAuth.Width / 2,
                (heightCenter - labelAuth.Height / 2) - 120);
            //labelPassword
            labelPassword.Location = new Point(widthCenter - textBoxSize.Width/2,
                (heightCenter - labelPassword.Height / 2));
            //labelLogin
            labelLogin.Location = new Point(widthCenter - textBoxSize.Width/2,
                (heightCenter - labelLogin.Height / 2) - 90);
            //authPictureBox
            authPictureBox.Location = new Point(widthCenter - authPictureBox.Width / 2,
                (heightCenter - authPictureBox.Height / 2) + 135);
            //authTextBox
            authAuthButton.Location = new Point(widthCenter - authAuthButton.Width / 2,
                (heightCenter - authAuthButton.Height / 2) + 125);
        }
    }
}