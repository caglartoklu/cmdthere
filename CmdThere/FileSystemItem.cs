// <copyright file="FileSystemItem.cs" company="https://github.com/caglartoklu">
// See the LICENSE file.
// </copyright>
namespace CmdThere
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    
    /// <summary>
    /// Defines a directory or a file.
    /// </summary>
    public class FileSystemItem : IEquatable<FileSystemItem>
    {
        /// <summary>
        /// To be used to mark the file with extra attributes if any.
        /// </summary>
        private List<string> tags = new List<string>();
        
        /// <summary>
        /// Initializes a new instance of the <see cref="FileSystemItem"/> class.
        /// </summary>
        /// <param name="arg">the path to the item.</param>
        public FileSystemItem(string arg)
        {
            this.Argument = arg;
            this.Parse();
        }
        
        /// <summary>
        /// Gets the argument as it is, untouched
        /// </summary>
        public string Argument { get; private set; }
        
        /// <summary>
        /// Gets the directory containing the item.
        /// If it is a directory, it is equal to the argument.
        /// </summary>
        public string DirectoryName { get; private set; }
        
        /// <summary>
        /// Gets a value indicating whether this this is a directory or not.
        /// </summary>
        public bool IsDirectory { get; private set; }

        /// <summary>
        /// Adds a tag to the file system item.
        /// The tag will be added if it does not exist already, otherwise,
        /// it will have no effect.
        /// </summary>
        /// <param name="tag">The tag</param>
        public void AddTag(string tag)
        {
            if (this.HasTag(tag))
            {
                this.tags.Add(tag);
            }
        }

        /// <summary>
        /// Removes a tag from the file system item.
        /// The tag will be removed if it exist already, otherwise,
        /// it will have no effect.
        /// </summary>
        /// <param name="tag">The tag</param>        
        public void RemoveTag(string tag)
        {
            if (this.HasTag(tag))
            {
                this.tags.Remove(tag);
            }
        }
        
        /// <summary>
        /// Returns true if the tag exists, false otherwise.
        /// </summary>
        /// <param name="tag">The tag</param>
        /// <returns>true if the tag exists, false otherwise.</returns>
        public bool HasTag(string tag)
        {
            return this.tags.Contains(tag);
        }
        
        /// <summary>
        /// Returns true if this file system item is equal with the other,
        /// false otherwise.
        /// </summary>
        /// <param name="other">Other file system item</param>
        /// <returns>true if this file system item is equal with the other,
        /// false otherwise.</returns>
        public bool Equals(FileSystemItem other)
        {
            bool result = false;
            
            if (this.IsDirectory != other.IsDirectory)
            {
                result = false;
            }
            
            if (this.Argument != other.Argument)
            {
                result = false;
            }
            
            if (this.DirectoryName != other.DirectoryName)
            {
                result = false;
            }
            
            return result;
        }
        
        /// <summary>
        /// Parses the file item and extracts the file name.
        /// </summary>
        private void Parse()
        {
            if (FileSystemHelper.IsDirectory(this.Argument))
            {
                this.IsDirectory = true;
                this.DirectoryName = this.Argument;
            }
            else if (FileSystemHelper.IsFile(this.Argument))
            {
                this.IsDirectory = false;
                this.DirectoryName = Path.GetDirectoryName(this.Argument);
            }
            else
            {
                string message = string.Empty;
                message += "Not a file or directory:";
                message += System.Environment.NewLine;
                message += System.Environment.NewLine;
                message += this.Argument;
                message += System.Environment.NewLine;
                message += System.Environment.NewLine;
                throw new FileNotFoundException(message);
            }
        }        
    }
}
