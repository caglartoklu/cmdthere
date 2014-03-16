// <copyright file="ShellHandler.cs" company="https://github.com/caglartoklu">
// See the LICENSE file.
// </copyright>
namespace CmdThere
{
    using System;
    using System.Security.Permissions;

    /// <summary>
    /// The base class for handlers.
    /// </summary>
    public abstract class ShellHandler
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShellHandler"/> class.
        /// </summary>        
        /// <param name="fileSystemItem">The item representing the file or folder.</param>
        protected ShellHandler(FileSystemItem fileSystemItem)
        {
            this.FileOrDirectoryItem = fileSystemItem;
            this.TargetDirectory = fileSystemItem.DirectoryName;
        }

        /// <summary>
        /// Gets the file or directory item.
        /// </summary>
        public FileSystemItem FileOrDirectoryItem { get; private set; }

        /// <summary>
        /// Gets the target directory. 
        /// </summary>
        /// <remarks>
        /// This is the directory that will be used as working directory.
        /// </remarks>
        public string TargetDirectory { get; private set; }

        /// <summary>
        /// Gets the executable file name of the shell.
        /// </summary>
        public abstract string ExecutableName
        {
            get;                
        }
        
        /// <summary>
        /// Starts and finishes the launching process.
        /// </summary>
        [PermissionSetAttribute(SecurityAction.LinkDemand, Name = "FullTrust")]
        public void Start()
        {
            this.ConfigurePre();
            this.Launch();
            this.ConfigurePost();
        }        

        /// <summary>
        /// Applies configuration before launching.
        /// </summary>
        protected abstract void ConfigurePre();

        /// <summary>
        /// Applies configuration after launching.
        /// </summary>        
        protected abstract void ConfigurePost();

        /// <summary>
        /// Actually applies the launching.
        /// </summary>
        [PermissionSetAttribute(SecurityAction.LinkDemand, Name = "FullTrust")]
        protected abstract void Launch();
    }
}
