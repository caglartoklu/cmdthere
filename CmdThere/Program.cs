// <copyright file="Program.cs" company="https://github.com/caglartoklu">
// See the LICENSE file.
// </copyright>
namespace CmdThere
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// Class including the program entry point.
    /// </summary>
    internal sealed class Program
    {
        /// <summary>
        /// Ends the application.
        /// </summary>
        public static void End()
        {
            Application.Exit();
        }

        /// <summary>
        /// Program entry point.
        /// </summary>
        /// <param name="args">The list of command line parameters.</param>
        [STAThread]
        private static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                // we do not have any arguments,
                // simply show the main form.
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new AboutForm());
            }
            else
            {
                // we have at least 1 argument,
                // see what we can do with them.
                new CmdThereDispatcher(args).Handle();
            }
        }
    }
}
