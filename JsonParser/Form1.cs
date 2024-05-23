// Ignore Spelling: Json

using Newtonsoft.Json.Linq;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace JsonParser
{
    /// <summary>
    /// 
    /// </summary>
    public partial class DeltaReality_JsonParser : Form
    {
        // TODO - 1 - Create some Drag/Drop or browse logic for json loader!
        private string jsonFilePath = "C:/Users/Josip/Desktop/JsonParserApp/json1.json"; // Specify the path to your JSON file

        //private float _currentRotation = 0;

        private JObject _jsonStructure;
        private Panel _panelJsonEditor = new Panel();
        private Button _buttonSave = new Button();
        private Label _labelValidation = new Label();

        private Timer _timer;

        public Action OnJsonSelectedEvent = default;

        public DeltaReality_JsonParser()
        {
            InitializeComponent();
            StartDelay();

            //this.KeyPreview = true; // Ensure the form captures key events
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            //base.OnKeyDown(e);

            //// Check if Ctrl+Alt+R is pressed
            //if (e.Control && e.Alt && e.KeyCode == Keys.R)
            //{
            //    RotateForm();
            //}
        }

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

        private void LoadJson()
        {
            try
            {
                string json = File.ReadAllText(jsonFilePath);
                _jsonStructure = JObject.Parse(json);
                GenerateJsonEditor(_jsonStructure, _panelJsonEditor, 0);
                _labelValidation.Text = "JSON Loaded Successfully";
                _labelValidation.ForeColor = System.Drawing.Color.Green;
            }
            catch (Exception ex)
            {
                _labelValidation.Text = $"Error Loading JSON: {ex.Message}";
                _labelValidation.ForeColor = System.Drawing.Color.Red;
            }
        }

        private int GenerateJsonEditor(JToken token, Control parent, int top)
        {
            if (token is JObject obj)
            {
                foreach (var property in obj.Properties())
                {
                    var label = new Label
                    {
                        Text = property.Name,
                        Top = top,
                        Left = 0,
                        Width = 100
                    };
                    parent.Controls.Add(label);

                    //top += 20;

                    top = GenerateJsonEditor(property.Value, parent, top);

                    //top += 10;
                }
            }
            else if (token is JArray array)
            {
                foreach (var item in array)
                {
                    top = GenerateJsonEditor(item, parent, top);
                }
            }
            else
            {
                var textBox = new TextBox
                {
                    Text = token.ToString(),
                    Top = top,
                    Left = 120,
                    Width = 200,
                    Tag = token // Tag the TextBox with the JToken for later use
                };
                parent.Controls.Add(textBox);

                top += 30;
            }

            return top;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateJsonValues(_jsonStructure, _panelJsonEditor);
                File.WriteAllText(jsonFilePath, _jsonStructure.ToString());
                _labelValidation.Text = "JSON Saved Successfully";
                _labelValidation.ForeColor = System.Drawing.Color.Green;
            }
            catch (Exception ex)
            {
                _labelValidation.Text = $"Error Saving JSON: {ex.Message}";
                _labelValidation.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void UpdateJsonValues(JToken token, Control parent)
        {
            if (token is JObject obj)
            {
                foreach (var property in obj.Properties())
                {
                    foreach (Control control in parent.Controls)
                    {
                        if (control is Label label && label.Text == property.Name)
                        {
                            Control nextControl = parent.Controls[parent.Controls.IndexOf(control) + 1];
                            UpdateJsonValues(property.Value, nextControl);
                        }
                    }
                }
            }
            else if (token is JArray array)
            {
                int index = 0;
                foreach (var item in array)
                {
                    UpdateJsonValues(item, parent.Controls[index]);
                    index++;
                }
            }
            else
            {
                foreach (Control control in parent.Controls)
                {
                    if (control is TextBox textBox && textBox.Tag == token)
                    {
                        ((JValue)token).Value = textBox.Text;
                    }
                }
            }
        }

        private void Setup()
        {
            SuspendLayout();
            // 
            // panelJsonEditor
            // 
            _panelJsonEditor.AutoScroll = true;
            _panelJsonEditor.Location = new System.Drawing.Point(12, 12);
            _panelJsonEditor.Name = "panelJsonEditor";
            _panelJsonEditor.Size = new System.Drawing.Size(776, 396);
            _panelJsonEditor.TabIndex = 0;
            // 
            // buttonSave
            // 
            _buttonSave.Location = new System.Drawing.Point(713, 415);
            _buttonSave.Name = "buttonSave";
            _buttonSave.Size = new System.Drawing.Size(75, 23);
            _buttonSave.TabIndex = 1;
            _buttonSave.Text = "Save";
            _buttonSave.UseVisualStyleBackColor = true;
            _buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // labelValidation
            // 
            _labelValidation.AutoSize = true;
            _labelValidation.Location = new System.Drawing.Point(12, 420);
            _labelValidation.Name = "labelValidation";
            _labelValidation.Size = new System.Drawing.Size(0, 13);
            _labelValidation.TabIndex = 2;
            // 
            // Form1
            // 
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(this._labelValidation);
            Controls.Add(this._buttonSave);
            Controls.Add(this._panelJsonEditor);
            Name = "Form1";
            Text = "JSON Editor";
            ResumeLayout(false);
            PerformLayout();

        }

        #region Initial Delay part
        private void StartDelay()
        {
            _timer = new Timer();
            _timer.Interval = 2000; // 2 seconds
            _timer.Tick += Timer_Tick;
            _timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            _timer.Stop();
            _timer.Tick -= Timer_Tick;
            _timer.Dispose();

            // Invoke your action here
            MyAction();
        }

        private void MyAction()
        {
            DeltaRealityGif.Visible = false;

            Setup();
            LoadJson();
        }
        #endregion
    }
}