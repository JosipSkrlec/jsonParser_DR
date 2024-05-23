using System;
using System.Windows.Forms;

namespace JsonParser.Scripts
{
    internal class CanvasController
    {
        private int[] _opacityLevels = { 100, 90, 80, 70, 60, 50 };
        private int _currentIndex = 0;

        private Form _form;

        public void HideCanvasElement(Control UIControl)
        {
            if (UIControl != null)
            {
                UIControl.Visible = false;
            }
        }

        public void ShowCanvasElement(Control UIControl)
        {
            if (UIControl != null)
            {
                UIControl.Visible = true;
            }
        }

        public void ToggleKeyEvents(Form form, bool isActive)
        {
            _form = form;
            if (isActive)
            {
                _form.KeyDown += new KeyEventHandler(MainForm_KeyDown);
            }
            else
            {
                _form.KeyDown -= new KeyEventHandler(MainForm_KeyDown);
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Alt && e.KeyCode == Keys.O)
            {
                ChangeOpacity();
            }
        }

        private void ChangeOpacity()
        {
            // Cycle to the next opacity level
            _currentIndex = (_currentIndex + 1) % _opacityLevels.Length;
            _form.Opacity = _opacityLevels[_currentIndex] / 100.0;
        }

        #region Rotation Part

        //protected override void OnKeyDown(KeyEventArgs e)
        //{
        //base.OnKeyDown(e);

        //// Check if Ctrl+Alt+R is pressed
        //if (e.Control && e.Alt && e.KeyCode == Keys.R)
        //{
        //    RotateForm();
        //}
        //}

        //private void RotateForm()
        //{
        //    _currentRotation += 90;
        //    if (_currentRotation >= 360) _currentRotation = 0;

        //    // Apply rotation to the form
        //    this.SuspendLayout();
        //    this.Size = new Size(this.Height, this.Width);
        //    this.ResumeLayout();

        //    Graphics g = this.CreateGraphics();
        //    g.TranslateTransform(this.ClientSize.Width / 2, this.ClientSize.Height / 2);
        //    g.RotateTransform(_currentRotation);
        //    g.TranslateTransform(-this.ClientSize.Width / 2, -this.ClientSize.Height / 2);
        //    g.Dispose();

        //    // Redraw the form's contents (optional)
        //    this.Invalidate();
        //}
        #endregion
    }
}