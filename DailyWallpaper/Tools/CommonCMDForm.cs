﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DailyWallpaper.Tools
{
    public partial class CommonCMDForm : Form
    {
        public CommonCMDForm()
        {
            InitializeComponent();
            Icon = Properties.Resources.icon32x32;
            
            UpdateCMDText();
            var oldFont = cmdTextBox.Font;
            cmdTextBox.Font = new Font(oldFont.FontFamily, oldFont.Size + 1);
        }

        private void AppendText(int index, string cmd, string usage = "")
        {
            cmdTextBox.AppendText(" "+ index.ToString() + "." + usage + ":" + Environment.NewLine + "   ");
            cmdTextBox.AppendText(cmd + Environment.NewLine);
        }

        private void UpdateCMDText()
        {
            var cmdFile = Path.Combine(Helpers.ProjectInfo.executingLocation, "CommonCommands-UTF8.txt");
            if (File.Exists(cmdFile))
            {
                var lines = File.ReadAllLines(cmdFile);
                lines.ToList().ForEach(line => cmdTextBox.AppendText(line + Environment.NewLine));
                return;
            }
            AppendText(1, "ipconfig | find \"IPv4\"", "Query the local IPv4 address");
            cmdTextBox.AppendText(Environment.NewLine + Environment.NewLine  + " ### Record Common Commands to the file by yourself: " + 
                Environment.NewLine + "    " + cmdFile);
            File.WriteAllText(cmdFile, cmdTextBox.Text, Encoding.UTF8);
        }
    }
}