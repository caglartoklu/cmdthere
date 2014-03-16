// <copyright file="CmdThereDispatcher.cs" company="https://github.com/caglartoklu">
// See the LICENSE file.
// </copyright>
namespace CmdThere
{
    using System;
    using System.Collections.Generic;
    using System.Security.Permissions;

    /// <summary>
    /// Dispatches the files to the handlers.
    /// </summary>
    public class CmdThereDispatcher
    { 
        /// <summary>
        /// arguments from command line 
        /// </summary>
        private string[] args;

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="CmdThereDispatcher" /> class.
        /// </summary>
        /// <param name="args">arguments from command line</param>
        public CmdThereDispatcher(string[] args)
        {
            this.args = args;
        }

        /// <summary>
        /// Launches the actions for the files/directories.
        /// </summary>
        [PermissionSetAttribute(SecurityAction.LinkDemand, Name = "FullTrust")]
        public void Handle()
        {
            // the list of unique directories.
            List<string> uniqueDirectories = new List<string>();

            // the first loop fills the uniquedirectories list.
            foreach (string arg in this.args)
            {
                try
                {
                    FileSystemItem currentFileSystemItem = new FileSystemItem(arg);
    
                    if (!uniqueDirectories.Contains(currentFileSystemItem.DirectoryName))
                    {
                        uniqueDirectories.Add(currentFileSystemItem.DirectoryName);
                    }
                }
                catch (ApplicationException exc)
                {
                    string caption = "CmdThereDispatcher.Handle()";
                    System.Windows.Forms.MessageBox.Show(exc.ToString(), caption);
                }
            }

            // second loop traverses uniquedirectories list.
            foreach (string currentFileSystemItem in uniqueDirectories)
            {
                try
                {
                    FileSystemItem fsi = new FileSystemItem(currentFileSystemItem);
                    new CmdExeHandler(fsi).Start();
                }
                catch (ApplicationException exc)
                {
                    string caption = "CmdThereDispatcher.Handle()";
                    System.Windows.Forms.MessageBox.Show(exc.ToString(), caption);
                }
            }
        }
    }
}
