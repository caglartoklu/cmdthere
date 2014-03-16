// <copyright file="CmdExeHandler.cs" company="https://github.com/caglartoklu">
// See the LICENSE file.
// </copyright>
namespace CmdThere
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Security.Permissions;

    /// <summary>
    /// The specific handler for Windows's <code>cmd.exe</code>.
    /// </summary>
    public class CmdExeHandler : ShellHandler
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CmdExeHandler" /> class.
        /// </summary>
        /// <param name="fileSystemItem">A file or directory</param>
        public CmdExeHandler(FileSystemItem fileSystemItem) : base(fileSystemItem)
        {
        }      

        /// <summary>
        /// Returns the executable path.
        /// For this class, it is the path of <code>cmd.exe</code>.
        /// </summary>
        /// <returns>Returns the executable path.</returns>
        public override string ExecutableName
        {
            get
            {
                string result;
                result = CmdExePath;
                return result;                
            }
        }

        /// <summary>
        /// Gets the path of <code>cmd.exe</code>.
        /// </summary>
        protected static string CmdExePath
        {
            get
            {
                string result = string.Empty;                     
                result = "cmd.exe";
                return result;                
            }
        }  
        
        /// <summary>
        /// Stuff to do before the launch.
        /// Automatically called by <code>ShellHandler.Start() method.</code>
        /// </summary>
        protected override void ConfigurePre()
        {
            System.IO.Directory.SetCurrentDirectory(this.TargetDirectory);
        }

        /// <summary>
        /// Stuff to do after the launch.
        /// Automatically called by <code>ShellHandler.Start() method.</code>
        /// </summary>
        protected override void ConfigurePost()
        {
        }

        /// <summary>
        /// Launches the action, opening a shell window in this case.
        /// For more information,
        /// <see href="http://www.dotnetperls.com/process-start">
        /// see here</see>.
        /// </summary>
        /// <remarks>
        /// Permission has been set for this method for the following reason:
        /// <code>
        /// 'CmdExeHandler.Launch()' calls into 'Process.Start(ProcessStartInfo)' which has a LinkDemand.
        /// By making this call, 'Process.Start(ProcessStartInfo)' is indirectly exposed to user code.
        /// Review the following call stack that might expose a way to circumvent security protection:
        ///    ->'CmdExeHandler.Launch()'
        ///    ->'CmdExeHandler.Launch()' (CA2122) - CmdThere\CmdExeHandler.cs:xy
        /// </code>
        /// </remarks>
        [PermissionSetAttribute(SecurityAction.LinkDemand, Name = "FullTrust")]
        protected override void Launch()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = false;
            //// startInfo.UseShellExecute = false;
            startInfo.UseShellExecute = true;
            startInfo.FileName = this.ExecutableName;

            // startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.Arguments = @"\k";
            Process.Start(startInfo);
        }      
    }
}
