using System;
using System.IO;
using System.Windows.Forms;

namespace JsonParser.Scripts
{
    internal class JsonFileLoaderController
    {
        public Action<string> OnJsonFileLoadedEvent;

        public void ToggleDragDropDetection(Form form, bool isActive)
        {
            if (isActive)
            {
                form.DragEnter += new DragEventHandler(MainForm_DragEnter);
                form.DragDrop += new DragEventHandler(MainForm_DragDrop);
            }
            else
            {
                form.DragEnter -= new DragEventHandler(MainForm_DragEnter);
                form.DragDrop -= new DragEventHandler(MainForm_DragDrop);
            }
        }

        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files.Length == 1 && Path.GetExtension(files[0]).ToLower() == ".json")
                {
                    e.Effect = DragDropEffects.Copy;
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                }
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                string filePath = files[0];

                if (Path.GetExtension(filePath).ToLower() == ".json")
                {
                    OnJsonFileLoadedEvent?.Invoke(filePath);
                }
            }
        }
    }
}