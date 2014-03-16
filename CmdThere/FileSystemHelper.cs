// <copyright file="FileSystemHelper.cs" company="https://github.com/caglartoklu">
// See the LICENSE file.
// </copyright>
namespace CmdThere
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Security.Permissions;

    /// <summary>
    /// Description of FileSystemHelper.
    /// </summary>
    public static class FileSystemHelper
    {
        /// <summary>
        /// Gets the path of the home directory.
        /// </summary>
        /// <remarks>
        /// <see href="http://stackoverflow.com/q/1143706"/>
        /// </remarks>
        public static string GetHomeDirectory
        {
            get
            {
                string result = null;
    
                if (Environment.OSVersion.Platform == PlatformID.MacOSX || Environment.OSVersion.Platform == PlatformID.Unix)
                {
                    result = Environment.GetEnvironmentVariable("HOME");
                }
                else
                {
                    result = Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%");
                }
    
                return result;
            }
        }

        /// <summary>
        /// Gets the path of the Windows directory.
        /// </summary>
        /// <remarks>
        /// <see href="http://stackoverflow.com/a/1499370"/>
        /// </remarks>
        public static string GetWindowsDirectory
        {
            get
            { 
                string result;
                result = Environment.GetEnvironmentVariable("windir");
                return result;                
            }
        }
        
        /// <summary>
        /// Returns <code>true</code> if the fileSystem item is an actual directory,
        /// <code>false</code> otherwise.
        /// </summary>
        /// <param name="fileSystemItem">The path to the file system item</param>
        /// <exception cref="System.IO.FileNotFoundException">When the fileSystemItem is not found.</exception>
        /// <returns>
        /// <code>true</code> if the fileSystem item is an actual directory,
        /// <code>false</code> otherwise.
        /// </returns>
        public static bool IsDirectory(string fileSystemItem)
        {
            bool result = false;
            try
            {
                FileAttributes attr = File.GetAttributes(fileSystemItem);
    
                if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
                {
                    result = true;
                }
            }
            catch (System.IO.FileNotFoundException)
            {
                // if the directory is not found, than it is not a directory.
                result = false;
            }

            return result;
        }

        /// <summary>
        /// Returns <code>true</code> if the fileSystem item is an actual file,
        /// <code>false</code> otherwise.
        /// </summary>
        /// <param name="fileSystemItem">The path to the file system item</param>
        /// <exception cref="System.IO.FileNotFoundException">When the fileSystemItem is not found.</exception>
        /// <returns>
        /// <code>true</code> if the fileSystem item is an actual file,
        /// <code>false</code> otherwise.
        /// </returns>
        public static bool IsFile(string fileSystemItem)
        {
            bool result = false;
            try
            {
                FileAttributes attr = File.GetAttributes(fileSystemItem);
    
                if ((attr & FileAttributes.Directory) != FileAttributes.Directory)
                {
                    result = true;
                }
            }
            catch (System.IO.FileNotFoundException)
            {
                // if the file is not found, than it is not a file.
                result = false;
            }

            return result;
        }
        
        /// <summary>
        /// Starts the link or file name with the default application.
        /// It if it is an URL, the default browser will be used.        
        /// </summary>
        /// <param name="link">The link or file name.</param>
        [PermissionSetAttribute(SecurityAction.LinkDemand, Name = "FullTrust")]
        public static void OpenLink(string link)
        {
            Process.Start(link);
        }
    }
}
