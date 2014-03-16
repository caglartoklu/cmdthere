// <copyright file="AboutForm.cs" company="https://github.com/caglartoklu">
// See the LICENSE file.
// </copyright>
namespace CmdThere
{
    using System;
    using System.Diagnostics.CodeAnalysis;    
    using System.Drawing;
    using System.IO;
    using System.Reflection;
    using System.Resources;
    using System.Security.Permissions;    
    using System.Text;
    using System.Windows.Forms;
    
    /// <summary>
    /// The main form.
    /// </summary>
    public partial class AboutForm : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AboutForm"/> class.
        /// </summary>        
        public AboutForm()
        {
            this.InitializeComponent();
        }
        
        /// <summary>
        /// Starts when the form is loaded.
        /// It loads the content to be displayed in the form.
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">Event arguments</param>
        [SuppressMessage("Microsoft.Performance", "CA1804", Justification = "No need to use the args, but removing is not needed either.")]
        public void AboutFormLoad(object sender, EventArgs e)
        {
            ResourceManager resources = new ResourceManager("CmdThere.Resources", Assembly.GetExecutingAssembly());
            //// byte[] fileData = (byte[])resources.GetObject("README");
            //// this.textReadme.Text = Encoding.UTF8.GetString(fileData);

            byte[] fileData = (byte[])resources.GetObject("About");
            Stream fileDataStream = new MemoryStream(fileData);
            this.textReadme.LoadFile(fileDataStream, RichTextBoxStreamType.RichText);
        }
        
        /// <summary>
        /// OK button click event.
        /// It ends the application.        
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">Event arguments</param>
        public void ButtonOkClick(object sender, System.EventArgs e)
        {
            Program.End();
        }

        /// <summary>
        /// Homepage link click event.
        /// It fires the default browser with the homepage link.
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">Event arguments</param>
        [PermissionSetAttribute(SecurityAction.LinkDemand, Name = "FullTrust")]
        public void LinkHomepageLinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                FileSystemHelper.OpenLink(this.linkHomepage.Text);
            }
            catch (ApplicationException exc)
            {
                string caption = "AboutForm.LinkHomepageLinkClicked";
                string message;
                message = exc.ToString();
                System.Windows.Forms.MessageBox.Show(message, caption);
            }
        }

        /// <summary>
        /// AboutForm key press event.
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">Event arguments, includes the char code of the pressed key</param>
        public void AboutFormKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            this.KeyPressed(e.KeyChar);
        }

        /// <summary>
        /// OK Button key press event. 
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">Event arguments, includes the char code of the pressed key</param>
        public void ButtonOkKeyPress(object sender, KeyPressEventArgs e)
        {
            this.KeyPressed(e.KeyChar);
        }

        /// <summary>
        /// Readme text key press event.
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">Event arguments, includes the char code of the pressed key</param>
        public void TextReadmeKeyPress(object sender, KeyPressEventArgs e)
        {
            this.KeyPressed(e.KeyChar);
        }

        /// <summary>
        /// Generic key press handler to catch if <code>Esc</code> is pressed.
        /// </summary>
        /// <param name="value">The char code of the pressed key.</param>
        public void KeyPressed(char value)
        {
            if (value == 27)
            {
                this.ButtonOkClick(this, null);
            }
        }
    }
}
