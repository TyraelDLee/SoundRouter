using System.Drawing;
using System.Windows.Forms;

namespace Sound
{
    partial class SoundMapper
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SoundMapper));
            this.ni = new System.Windows.Forms.NotifyIcon(this.components);
            this.SuspendLayout();
            // 
            // ni
            // 
            this.ni.Icon = ((System.Drawing.Icon)(resources.GetObject("ni.Icon")));
            this.ni.Text = "Sound Mapper";
            this.ni.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ni_MouseDoubleClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "SoundMapper";
            this.Text = "Sound Mapper";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.ResumeLayout(false);
        }

        #endregion

        private NotifyIcon ni;
    }
}