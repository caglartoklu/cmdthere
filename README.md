# CmdThere
*Microsoft Windows* will not go easy with the command line users.
*CmdThere* is a tool to simplify it.

If you drag and drop a file or a directory on to the icon of *CmdThere*,
it will open a shell window (`cmd.exe` on *Microsoft Windows*)
on the target folder. The target folder is either the folder dragged and dropped,
or the folder containing the corresponding file.

**Homepage**: https://github.com/caglartoklu/cmdthere


# Downloads
Except the source form, you can also
[Download the Windows binary](http://ubuntuone.com/7ftSiVMm3cNhzACnbWPjW2)

**Size:** 141 KB
**MD5:** `3cb07980c3479b385fb62af1a1567122`


# Installation
No need to install, the package is portable.
Simply put the exe file to a directory of your choice,
and then create a shortcut on your Desktop or
`%APPDATA%\Microsoft\Windows\SendTo` folder.


# Configuration
None, currently.


# Usage
Simply drag and drop files and directories to the icon of `CmdThere.exe`.
It is possible to drag and drop more than one file or directory.

![drag1.png](https://raw.github.com/caglartoklu/cmdthere/CmdThere/img/drag1.png)

In this case, CmdThere will extract the unique directories of all parameters,
and open command windows are required.

![cmdexes.png](https://raw.github.com/caglartoklu/cmdthere/CmdThere/img/cmdexes.png)

If the item is a directory, it will be used as it is.
If it is a file, the directory containing it will be used.

Examples:

- Drag and drop 10 files from a directory, CmdThere will open a single
  command window since their directories are the same.
- Drag and drop 2 directories from a directory, CmdThere will open a
  command window for each of them, 2 in total.
- Drag and drop 1 file and 1 directory from a directory, CmdThere will open a
  command window for each of them, 2 in total.


# Tools and Libraries Used
- [Microsoft .NET Framework 3.5](http://www.microsoft.com/en-us/download/details.aspx?id=22)
- [SharpDevelop 4.4](https://github.com/icsharpcode/SharpDevelop)
- FxCop 10.0 from [Microsoft Windows SDK for Windows 7 and .NET Framework 4](http://www.microsoft.com/en-us/download/details.aspx?id=8279)
- [StyleCop 4.7](https://stylecop.codeplex.com/)
- [Vim 7.4](http://www.vim.org) with [Omnisharp](https://github.com/nosami/Omnisharp)
- [Git for Windows](http://msysgit.github.io/)
- [IrfanView](http://www.irfanview.com/)
- http://www.dropshadowz.net/



# To do
- A settings file and default actions
- Copying the files/directories to the clipboard (controllable by settings file)
- MSYS support
- PowerShell support


# License

Licensed with
[2-clause license](https://en.wikipedia.org/wiki/BSD_licenses#2-clause_license_.28.22Simplified_BSD_License.22_or_.22FreeBSD_License.22.29)
("Simplified BSD License" or "FreeBSD License").
See the
[LICENSE](https://github.com/caglartoklu/cmdthere/blob/master/LICENSE) file.


# Legal

All trademarks and registered trademarks are the property of their respective owners.


# Contact Info
You can find me on
[Google+](https://plus.google.com/108566243864924912767/posts)

Feel free to send bug reports, or ask questions.
