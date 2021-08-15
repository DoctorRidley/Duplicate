using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;

namespace Duplicate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Dir_Button_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dir = new FolderBrowserDialog();

            if (dir.ShowDialog() == DialogResult.OK)
            {
                dir_text.Text = dir.SelectedPath;
            }
        }

        private void start_button_Click(object sender, EventArgs e)
        {
            if (dir_text.Text == "")
            {
                string text = "Select a Folder";
                string caption = "No folder detected";
                MessageBox.Show(text, caption);
                return;
            }

            // User confirmation to recompute
            if (listbox.Items.Count > 0)
            {
                string text = "Do you wish to proceed?";
                string caption = "Confirmation";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(text, caption, buttons);
                if (result == DialogResult.No) { return; }
            }
            
            string path = dir_text.Text;

            List<List<Check_Sum>> groups = new List<List<Check_Sum>>();
            Build_List(path, ref groups);

            Display_Duplicates(ref groups);
        }

        private void Build_List(string path, ref List<List<Check_Sum>> groups)
        {
            // Foreach item in directory
            string[] files, dir;
            try
            {
                files = Directory.GetFiles(path);
                dir = Directory.GetDirectories(path);
            }
            catch (UnauthorizedAccessException) { return; } // cannot access, ignore it
            // FIXME: handle unauthorized file/dir access separately

            // If subdirectory, recursively call, passing directory path
            for (int i = 0; i < dir.Length; ++i)
            {
                Build_List(dir[i], ref groups);
            }

            for (int i = 0; i < files.Length; ++i)
            {
                // Convert file data to MD5 hash
                byte[] file_data = File.ReadAllBytes(files[i]);
                byte[] hash = MD5.Create().ComputeHash(file_data);

                // Push file name and hash to list
                Check_Sum new_sum = new Check_Sum(files[i], hash);
                Sort_Duplicates(ref groups, new_sum);
            }
        }

        private void Sort_Duplicates(ref List<List<Check_Sum>> groups, Check_Sum c)
        {
            // Each element of a group contains list of duplicate files

            bool group_found = false; // FIXME: feels like cheating

            for (int i = 0; i < groups.Count && !group_found; ++i)
            {
                // Check if each group has the same hash as current file
                // Puts that check sum into appropriate group
                if (c.file_hash.SequenceEqual(groups[i][0].file_hash))
                {
                    // Ensures loop break
                    group_found = true;
                    groups[i].Add(c);
                }
            }

            // No match, new file/checksum
            if (!group_found)
            {
                List<Check_Sum> new_group = new List<Check_Sum>();
                groups.Add(new_group);
                new_group.Add(c);
            }
        }

        private void Display_Duplicates(ref List<List<Check_Sum>> groups)
        {
            // While loop ensures incrementing only
            // when needed, reducing computations
            listbox.Items.Clear();
            listbox.BeginUpdate();
            int i = 0;
            while (i < groups.Count)
            {

                // If multiple files, output each of those files
                if (groups[i].Count > 1)
                {
                    // Output each file in a group
                    for (int j = 0; j < groups[i].Count; ++j)
                    {
                        listbox.Items.Add(groups[i][j].file_name);
                    }

                    listbox.Items.Add("");
                    ++i; // Element not removed, move to next element
                }

                // if file is unique, remove it. FIXME: may be unneeded
                else { groups.Remove(groups[i]); }
            }

            if (listbox.Items.Count == 0) { listbox.Items.Add("No duplicate files found"); }

            listbox.EndUpdate();
        }

        private void listbox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = listbox.IndexFromPoint(e.Location);
            string path = listbox.Items[index].ToString();
            
            if (!File.Exists(path))
            {
                string text = "File has been deleted or moved.";
                string caption = "No file found";
                MessageBox.Show(text, caption);
                return;
            }
            
            System.Diagnostics.Process.Start("explorer.exe", "/select, " + path);
        }
    }
}
