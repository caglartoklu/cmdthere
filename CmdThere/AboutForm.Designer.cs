// <copyright file="AboutForm.Designer.cs" company="https://github.com/caglartoklu">
// See the LICENSE file.
// </copyright>

namespace CmdThere
{
    using System.Diagnostics.CodeAnalysis;
    using System.Security.Permissions;
    using System.Windows.Forms;

    /// <summary>
    /// The visual design of the form.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.NamingRules", "*", Justification = "Reviewed. Suppression is OK here.")]
    [SuppressMessage("StyleCop.CSharp.LayoutRules", "*", Justification = "Reviewed. Suppression is OK here.")]
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "*", Justification = "Reviewed. Suppression is OK here.")]
    [SuppressMessage("StyleCop.CSharp.OrderingRules", "*", Justification = "Reviewed. Suppression is OK here.")]
    [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "*", Justification = "Reviewed. Suppression is OK here.")]
    [SuppressMessage("StyleCop.CSharp.SpacingRules", "*", Justification = "Reviewed. Suppression is OK here.")]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "*", Justification = "Reviewed. Suppression is OK here.")]
    public partial class AboutForm
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Disposes resources used by the form.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.components != null)
                {
                    this.components.Dispose();
                }
            }

            base.Dispose(disposing);
        }

        /// <summary>
        /// This method is required for Windows Forms designer support.
        /// Do not change the method contents inside the source code editor. The Forms designer might
        /// not be able to load this method if it was changed manually.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.linkHomepage = new System.Windows.Forms.LinkLabel();
            this.buttonOk = new System.Windows.Forms.Button();
            this.pictureDrag = new System.Windows.Forms.PictureBox();
            this.pictureCmdExes = new System.Windows.Forms.PictureBox();
            this.textReadme = new System.Windows.Forms.RichTextBox();
            this.labelDrag = new System.Windows.Forms.Label();
            this.labelCmdExes = new System.Windows.Forms.Label();
            this.pictureIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureDrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCmdExes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // linkHomepage
            // 
            this.linkHomepage.Location = new System.Drawing.Point(12, 15);
            this.linkHomepage.Name = "linkHomepage";
            this.linkHomepage.Size = new System.Drawing.Size(424, 23);
            this.linkHomepage.TabIndex = 1;
            this.linkHomepage.TabStop = true;
            this.linkHomepage.Text = "https://github.com/caglartoklu/cmdthere";
            this.linkHomepage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkHomepageLinkClicked);
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.Location = new System.Drawing.Point(733, 651);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(134, 37);
            this.buttonOk.TabIndex = 0;
            this.buttonOk.Text = "&OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.ButtonOkClick);
            this.buttonOk.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ButtonOkKeyPress);
            // 
            // pictureDrag
            // 
            this.pictureDrag.Image = ((System.Drawing.Image)(resources.GetObject("pictureDrag.Image")));
            this.pictureDrag.Location = new System.Drawing.Point(12, 89);
            this.pictureDrag.Name = "pictureDrag";
            this.pictureDrag.Size = new System.Drawing.Size(365, 328);
            this.pictureDrag.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureDrag.TabIndex = 3;
            this.pictureDrag.TabStop = false;
            // 
            // pictureCmdExes
            // 
            this.pictureCmdExes.BackColor = System.Drawing.SystemColors.Control;
            this.pictureCmdExes.Image = ((System.Drawing.Image)(resources.GetObject("pictureCmdExes.Image")));
            this.pictureCmdExes.Location = new System.Drawing.Point(399, 89);
            this.pictureCmdExes.Name = "pictureCmdExes";
            this.pictureCmdExes.Size = new System.Drawing.Size(459, 393);
            this.pictureCmdExes.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureCmdExes.TabIndex = 4;
            this.pictureCmdExes.TabStop = false;
            // 
            // textReadme
            // 
            this.textReadme.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                                    | System.Windows.Forms.AnchorStyles.Left) 
                                    | System.Windows.Forms.AnchorStyles.Right)));
            this.textReadme.Location = new System.Drawing.Point(12, 433);
            this.textReadme.Name = "textReadme";
            this.textReadme.ReadOnly = true;
            this.textReadme.Size = new System.Drawing.Size(855, 212);
            this.textReadme.TabIndex = 6;
            this.textReadme.Text = "";
            this.textReadme.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextReadmeKeyPress);
            // 
            // labelDrag
            // 
            this.labelDrag.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDrag.Location = new System.Drawing.Point(12, 63);
            this.labelDrag.Name = "labelDrag";
            this.labelDrag.Size = new System.Drawing.Size(364, 23);
            this.labelDrag.TabIndex = 7;
            this.labelDrag.Text = "Drag the files to drop to the icon of CmdThere";
            // 
            // labelCmdExes
            // 
            this.labelCmdExes.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCmdExes.Location = new System.Drawing.Point(399, 63);
            this.labelCmdExes.Name = "labelCmdExes";
            this.labelCmdExes.Size = new System.Drawing.Size(459, 23);
            this.labelCmdExes.TabIndex = 8;
            this.labelCmdExes.Text = "Then you will have cmd.exe instances for files and directories there";
            // 
            // pictureIcon
            // 
            this.pictureIcon.Image = ((System.Drawing.Image)(resources.GetObject("pictureIcon.Image")));
            this.pictureIcon.Location = new System.Drawing.Point(810, 3);
            this.pictureIcon.Name = "pictureIcon";
            this.pictureIcon.Size = new System.Drawing.Size(48, 48);
            this.pictureIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureIcon.TabIndex = 9;
            this.pictureIcon.TabStop = false;
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 692);
            this.Controls.Add(this.pictureIcon);
            this.Controls.Add(this.labelCmdExes);
            this.Controls.Add(this.labelDrag);
            this.Controls.Add(this.textReadme);
            this.Controls.Add(this.pictureCmdExes);
            this.Controls.Add(this.pictureDrag);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.linkHomepage);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AboutForm";
            this.Text = "CmdThere";
            this.Load += new System.EventHandler(this.AboutFormLoad);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AboutFormKeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.pictureDrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCmdExes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        private System.Windows.Forms.PictureBox pictureIcon;
        private System.Windows.Forms.Label labelCmdExes;
        private System.Windows.Forms.Label labelDrag;
        private System.Windows.Forms.PictureBox pictureCmdExes;
        private System.Windows.Forms.PictureBox pictureDrag;

        private System.Windows.Forms.RichTextBox textReadme;

        private System.Windows.Forms.Button buttonOk;

        private System.Windows.Forms.LinkLabel linkHomepage;
    }
}
