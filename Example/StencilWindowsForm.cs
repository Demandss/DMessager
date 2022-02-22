using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DMessager.Properties;
using DMessager.Utils;

namespace DMessager.Example
{
    public sealed class StencilWindowsForm : Form
    {
        private Form form;
        private bool fullscreen = false;
        
        private PictureBox windowCloseBox = new();
        private PictureBox windowCollapseBox = new();
        private PictureBox windowScaleBox = new();
        
        public StencilWindowsForm(Form form)
        {
            this.form = form;
            
            // 
            // windowCloseBox
            // 
            ((ISupportInitialize) windowCloseBox).BeginInit();

            windowCloseBox.Image = ResourcesManager.getProjectImage("WindowControlButtons/CloseButton.png");
            windowCloseBox.Location = new Point(form.Width-26, 12);
            windowCloseBox.Name = "windowCloseBox";
            windowCloseBox.Size = new Size(12, 12);
            windowCloseBox.TabIndex = 0;
            windowCloseBox.TabStop = false;
            windowCloseBox.Click += windowCloseBox_click;
            windowCloseBox.MouseHover += (sender, args) =>
            {
                windowCloseBox.Image = ResourcesManager.getProjectImage("WindowControlButtons/CloseButtonHover.png");
            };
            windowCloseBox.MouseLeave += (sender, args) =>
            {
                windowCloseBox.Image = ResourcesManager.getProjectImage("WindowControlButtons/CloseButton.png");
            };

            form.Controls.Add(windowCloseBox);
            
            ((ISupportInitialize) windowCloseBox).EndInit();
            
            
            // 
            // windowScaleBox
            // 
            ((ISupportInitialize) windowCollapseBox).BeginInit();

            windowCollapseBox.Image = ResourcesManager.getProjectImage("WindowControlButtons/SkipButton.png");
            windowCollapseBox.Location = new Point(form.Width-47, 12);
            windowCollapseBox.Name = "windowScaleBox";
            windowCollapseBox.Size = new Size(12, 12);
            windowCollapseBox.TabIndex = 0;
            windowCollapseBox.TabStop = false;
            windowCollapseBox.Click += WindowCollapseBoxClick;
            windowCollapseBox.MouseHover += (sender, args) =>
            {
                windowCollapseBox.Image = ResourcesManager.getProjectImage("WindowControlButtons/SkipButtonHover.png");
            };
            windowCollapseBox.MouseLeave += (sender, args) =>
            {
                windowCollapseBox.Image = ResourcesManager.getProjectImage("WindowControlButtons/SkipButton.png");
            };
            
            form.Controls.Add(windowCollapseBox);
            
            ((ISupportInitialize) windowCollapseBox).EndInit();
            
            
            // 
            // windowCollapseBox
            // 
            /*((ISupportInitialize) windowScaleBox).BeginInit();

            windowScaleBox.Image = ResourcesManager.getProjectImage("WindowControlButtons/ScaleButton.png");
            windowScaleBox.Location = new Point(form.Width-68, 12);
            windowScaleBox.Name = "windowCollapseBox";
            windowScaleBox.Size = new Size(12, 12);
            windowScaleBox.TabIndex = 0;
            windowScaleBox.TabStop = false;
            windowScaleBox.Click += WindowScaleBoxClick;
            windowScaleBox.MouseHover += (sender, args) =>
            {
                windowScaleBox.Image = ResourcesManager.getProjectImage("WindowControlButtons/ScaleButtonHover.png");
            };
            windowScaleBox.MouseLeave += (sender, args) =>
            {
                windowScaleBox.Image = ResourcesManager.getProjectImage("WindowControlButtons/ScaleButton.png");
            };
            
            form.Controls.Add(windowScaleBox);
            
            ((ISupportInitialize) windowScaleBox).EndInit();*/
        }

        public void setFormParams()
        {
            form.Bounds = Screen.PrimaryScreen.Bounds;
            form.Icon = Icon.FromHandle(ResourcesManager.getProjectImage("icon/icon.ico").GetHicon()); 
            form.FormBorderStyle = FormBorderStyle.None;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.BackColor = Color.FromArgb(54, 57, 63);
            form.Text = @"DMessager";
            form.Width = 800;
            form.Height = 600;
            form.MouseDown += Form_MouseDown;
            form.Resize += Form_Resize;
        }

        void Form_MouseDown(object sender, MouseEventArgs e)
        {
            form.Capture = false;
            Message m = Message.Create(form.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            WndProc(ref m);
        }

        void Form_Resize(object sender, EventArgs e)
        {
            windowCloseBox.Location = new Point(form.Width-26, 12);
            windowCollapseBox.Location = new Point(form.Width-47, 12);
            windowScaleBox.Location = new Point(form.Width-68, 12);
        }

        void windowCloseBox_click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        void WindowCollapseBoxClick(object sender, EventArgs e)
        {
            form.WindowState = FormWindowState.Minimized;
        }
        
        void WindowScaleBoxClick(object sender, EventArgs e)
        {
            if (form.WindowState != FormWindowState.Maximized)
            {
                form.FormBorderStyle = FormBorderStyle.Sizable;
                form.WindowState = FormWindowState.Maximized;
            } else
            {
                form.WindowState = FormWindowState.Normal;
            }
            form.FormBorderStyle = FormBorderStyle.None;
        }
    }
}