using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Windows.Forms;

namespace JsonParser.Scripts
{
    internal class JsonLoaderController
    {
        public Action OnJsonSelectedEvent;

        private JObject _jsonStructure;
        private Panel _panelJsonEditor = new Panel();
        private Button _buttonSave = new Button();
        private Label _labelValidation = new Label();

        private string _jsonFilePath = default;

        public void LoadJson(string jsonFilePath)
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

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateJsonValues(_jsonStructure, _panelJsonEditor);
                File.WriteAllText(_jsonFilePath, _jsonStructure.ToString());
                _labelValidation.Text = "JSON Saved Successfully";
                _labelValidation.ForeColor = System.Drawing.Color.Green;
            }
            catch (Exception ex)
            {
                _labelValidation.Text = $"Error Saving JSON: {ex.Message}";
                _labelValidation.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void Setup()
        {
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
        }
    }
}
