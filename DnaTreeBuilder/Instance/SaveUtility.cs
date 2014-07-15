using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace DnaTreeBuilder.Instance
{
    class SaveUtility
    {
        static StringBuilder sb = new StringBuilder();
        public static void SaveRadTree(RadTreeView view, IWin32Window frm = null, string filename = "")
        {
            var saveFileDialogCsv = new SaveFileDialog();
            saveFileDialogCsv.Title = "Save data to Comma Separated File";
            saveFileDialogCsv.Filter = "CSV or Excel|*.csv";
            saveFileDialogCsv.CheckPathExists = true;
            saveFileDialogCsv.DefaultExt = "csv";
            saveFileDialogCsv.AddExtension = true;
            saveFileDialogCsv.OverwritePrompt = true;
            saveFileDialogCsv.InitialDirectory = Repository.DataFolder;
            saveFileDialogCsv.FileName = filename;
            if (saveFileDialogCsv.ShowDialog(frm) == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    sb = new StringBuilder();
                    foreach (var node in view.Nodes)
                    {
                        sb.AppendLine(node.Text.Replace("<=", ","));
                        ListNodes(node);
                    }
                    System.IO.File.WriteAllText(saveFileDialogCsv.FileName, sb.ToString(),Encoding.UTF8);
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, "Unexpected Error");
                }
            }
        }
        private static void ListNodes(RadTreeNode node)
        {
            var buff = new StringBuilder();
            for (var i = 0; i < node.Level; i++)
                buff.Append(",");
            foreach (var subnode in node.Nodes)
            {
                sb.AppendLine(buff.ToString()+"," + subnode.Text.Replace("<=", ","));
                ListNodes(subnode);
            }
        }
        public static void SaveString(string txt, IWin32Window frm = null, string filename = "")
        {
            var saveFileDialogCsv = new SaveFileDialog();
            saveFileDialogCsv.Title = "Save data to Comma Separated File";
            saveFileDialogCsv.Filter = "CSV or Excel|*.csv";
            saveFileDialogCsv.CheckPathExists = true;
            saveFileDialogCsv.DefaultExt = "csv";
            saveFileDialogCsv.AddExtension = true;
            saveFileDialogCsv.OverwritePrompt = true;
            saveFileDialogCsv.InitialDirectory = Repository.DataFolder;
            saveFileDialogCsv.FileName = filename;
            if (saveFileDialogCsv.ShowDialog(frm) == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    System.IO.File.WriteAllText(saveFileDialogCsv.FileName, txt,Encoding.UTF8);
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, "Unexpected Error");
                }
            }
        }


    }
}
