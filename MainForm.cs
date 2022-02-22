using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DMessager.Example;
using System.Drawing;
using System.Linq;
using DMessager.Utils;

namespace DMessager
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
            new StencilWindowsForm(this).setFormParams();
            //AuthForm.AllocConsole();
        }
        
        List<MessageBuilder> messages = new(); 

        Label userName = new();
        
        ScrollControl chatsControlBox = new();
        ScrollControl messagesControlBox = new();
        PictureBox sendPictureBox = new();
        TextBox sendTextBox = new ();
        Button sendMessageButton = new();
        
        Label NameSend = new();
        Label messageText = new();
        
        private void MainForm_Load(object sender, EventArgs e)
        {
            sendPictureBox.Image = ResourcesManager.getProjectImage("main/WriteMSG.png");
            sendPictureBox.Size = new Size(500, 50);
            sendPictureBox.Location = new Point(240,Height - 30);
            sendPictureBox.Name = "SendMSGBox";
            sendPictureBox.TabIndex = 0;
            sendPictureBox.TabStop = false;
                
            sendTextBox.Size = new Size(460, 50);
            sendTextBox.Location = new Point(245, Height - 29);
            sendTextBox.BorderStyle = BorderStyle.None;
            sendTextBox.BackColor = Color.FromArgb(64, 68, 75);
            sendTextBox.ForeColor = Color.White;
            sendTextBox.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);

            sendMessageButton.Image = ResourcesManager.getProjectImage("main/SendMessageButton.png");
            sendMessageButton.Size = new Size(20, 20);
            sendMessageButton.Location = new Point(Width - 60,Height - 30);
            sendMessageButton.FlatAppearance.BorderSize = 0;
            sendMessageButton.FlatStyle = FlatStyle.Flat;
            sendMessageButton.Name = "SendMSGButton";
            sendMessageButton.TabIndex = 0;
            sendMessageButton.Click += (o, args) =>
            {
                //MessageBuilder messageСonstructor = new MessageBuilder(getUserName + " " + getUserLastName,sendTextBox.Text);
                //messages.Add(messageСonstructor);
                //DialogBoxLoad(messageСonstructor);
                //Refresh();
                messageText.Text = sendTextBox.Text;
                messageText.Show();
                NameSend.Show();
                sendTextBox.Text = "";
            }; 
            sendMessageButton.TabStop = false;

            Controls.Add(sendTextBox);
            Controls.Add(sendPictureBox);
            Controls.Add(sendMessageButton);
            
            //initialize
            MessageBoxLoad();
            
            DialogBoxLoad(new MessageBuilder(getUserName + " " + getUserLastName,"Тестовое сообщение"));
        }

        static String[] UserName = AuthForm.loginTextBox.Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        
        string getUserName = UserName[1];
        string getUserLastName = UserName[0];

        private void DialogBoxLoad(MessageBuilder value)
        {
            messages.Add(value);

            string name = value.Author;
            string message = value.Text;
            
            Point namePosition = new();
            Point messageTextPosition = new();

            if (message.Length > 66)
            {
                int count = (int) Math.Ceiling((double) (message.Length / 66));

                for (var i = 0; i < count; i++)
                {
                    namePosition = new Point(240, Height - 93);
                    messageTextPosition = new Point(240, Height - 80);
                }
            }
            else
            {
                namePosition = new Point(240, Height - 93);
                messageTextPosition = new Point(240, Height - 80);
            }

            NameSend.Text = name;
            NameSend.Location = namePosition;
            NameSend.ForeColor = Color.FromArgb(85, 111, 205);
            NameSend.Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            NameSend.Size = new Size(Width, 13);

            messageText.Text = message;
            messageText.Location = messageTextPosition;
            messageText.ForeColor = Color.White;
            messageText.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);
            messageText.Size = new Size(Width - 240, 50);

            NameSend.Hide();
            messageText.Hide();

            Controls.Add(NameSend);
            Controls.Add(messageText);

            namePosition.Y -= namePosition.Y;
            messageTextPosition.Y -= messageTextPosition.Y;
        }

        private void MessageBoxLoad()
        {
            Dictionary<string, string> users = new();
            
            users.Add("Name LastName", "");
            users.Add("Jane Stat", "");
            users.Add("Stiven Nuel", "");
            users.Add("Gabe Nuel", "");
            users.Add("Steam Corps", "");
            users.Add("Stive Alexen", "");
            users.Add("Marry Jane", "");
            users.Add("Andre Anfiv", "");
            users.Add("Anfanik Andray", "");
            users.Add("Ahmedsh Viliam", "");

            int y = 0;
            
            foreach (var val in users)
            {
                Dialog(val.Key, 0, y);
            
                y += 56;
            }

            chatsControlBox.Location = new Point(0,0);
            chatsControlBox.AutoSize = true;
            chatsControlBox.MouseWheel += (o, args) =>
            {
                int limit = 0;
                chatsControlBox.AutoScrollPosition = new Point(0, 
                    Math.Min(limit, chatsControlBox.Location.Y - args.Delta / 10));
            };

            userName.Size = new Size(140,40);
            userName.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            userName.Text = getUserLastName.Remove(1) + ". " + getUserName;
            userName.BackColor = Color.FromArgb(48, 51, 57);
            userName.ForeColor = Color.FromArgb(185, 187, 190);
            userName.Location = new Point(6,Height - 40);
            
            Controls.Add(userName);
            Controls.Add(chatsControlBox);
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            Graphics graph = e.Graphics;
            
            //base rectangle
            graph.FillRectangle(new SolidBrush(Color.FromArgb(48, 51, 57)),new Rectangle(0, Height - 40, 223, 40));
        }

        private List<Button> messageButtons = new();
        
        private void Dialog(string name,int x,int y)
        {
            var color = Color.FromArgb(48, 51, 57);
            
            Button button = new Button();

            Dictionary<string, string> usersMessages = new();

            button.Size = new Size(223,56);
            button.Location = new Point(x, y);
            button.BackColor = color;
            button.Text = name + "\n";
            button.TextAlign = ContentAlignment.MiddleLeft;
            button.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button.ForeColor = Color.FromArgb(206, 206, 206);
            button.FlatAppearance.BorderSize = 0;
            button.FlatStyle = FlatStyle.Flat;
            button.MouseClick += (sender, args) =>
            {
                Button clickButton = (Button)sender;
                foreach (var messageButton in messageButtons)
                {
                    if (messageButton != clickButton)
                    {
                        messageButton.BackColor = Color.FromArgb(48, 51, 57);
                    }
                }
                clickButton.BackColor = Color.FromArgb(114, 137, 218);
                if (usersMessages.Keys.Contains(name))
                {
                    usersMessages.Remove(name);
                    usersMessages.Add(name,sendTextBox.Text);
                }
                else
                {
                    usersMessages.Add(name,sendTextBox.Text);
                }

                sendTextBox.Text = usersMessages[name];
            };
            
            messageButtons.Add(button);
            chatsControlBox.Controls.Add(button);
        }
        
        private void MainForm_Resize(object sender, EventArgs e)
        {
            chatsControlBox.Size = new Size(223,Height - 40);
            userName.Location = new Point(6,Height - 40);
        }
    }
}