using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Windows.Forms;

namespace JsonParser.Scripts
{
    internal class JsonLoaderController
    {
        public Action OnJsonLoadedEvent;

        private JObject _jsonStructure;
        private Panel _panelJsonEditor = new Panel();
        private Button _buttonSave = new Button();
        private Label _labelValidation = new Label();

        private string _jsonFilePath = default;

        public void LoadJson(string jsonFilePath)
        {
            // Assign the JSON file path
            _jsonFilePath = jsonFilePath;

            // Setup UI
            SetupUI();

            try
            {
                string json = File.ReadAllText(jsonFilePath);
                _jsonStructure = JObject.Parse(json);
                GenerateJsonEditor(_jsonStructure, _panelJsonEditor, 0);
                _labelValidation.Text = "JSON Loaded Successfully";
                _labelValidation.ForeColor = System.Drawing.Color.Green;

                OnJsonLoadedEvent?.Invoke();
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

                    top = GenerateJsonEditor(property.Value, parent, top);

                    // Increase top to create space between controls
                    //top += 20;
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

                // Subscribe to TextChanged event for the TextBox
                textBox.TextChanged += TextBox_TextChanged;

                parent.Controls.Add(textBox);

                // Increase top to create space between controls
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
                    break; // Exit the loop after updating the value
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
                // Update the value of the token directly
                JValue jValue = (JValue)token;
                switch (jValue.Type)
                {
                    case JTokenType.Integer:
                        if (int.TryParse(textBox.Text, out int intValue))
                            jValue.Value = intValue;
                        break;
                    case JTokenType.Float:
                        if (double.TryParse(textBox.Text, out double doubleValue))
                            jValue.Value = doubleValue;
                        break;
                    case JTokenType.Boolean:
                        if (bool.TryParse(textBox.Text, out bool boolValue))
                            jValue.Value = boolValue;
                        break;
                    case JTokenType.Date:
                        if (DateTime.TryParse(textBox.Text, out DateTime dateValue))
                            jValue.Value = dateValue;
                        break;
                    default:
                        jValue.Value = textBox.Text;
                        break;
                }
                break; // Exit the loop after updating the value
            }
        }
    }
}

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            JToken token = (JToken)textBox.Tag;
            JValue jValue = (JValue)token;

            // Attempt to parse the text back to the original type
            switch (jValue.Type)
            {
                case JTokenType.Integer:
                    if (int.TryParse(textBox.Text, out int intValue))
                        jValue.Value = intValue;
                    break;
                case JTokenType.Float:
                    if (double.TryParse(textBox.Text, out double doubleValue))
                        jValue.Value = doubleValue;
                    break;
                case JTokenType.Boolean:
                    if (bool.TryParse(textBox.Text, out bool boolValue))
                        jValue.Value = boolValue;
                    break;
                case JTokenType.Date:
                    if (DateTime.TryParse(textBox.Text, out DateTime dateValue))
                        jValue.Value = dateValue;
                    break;
                default:
                    jValue.Value = textBox.Text;
                    break;
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

                Console.WriteLine("BUTTON SAVED JSON");
            }
            catch (Exception ex)
            {
                _labelValidation.Text = $"Error Saving JSON: {ex.Message}";
                _labelValidation.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void SetupUI()
        {
            // Add panelJsonEditor to the form
            _panelJsonEditor.AutoScroll = true;
            _panelJsonEditor.Location = new System.Drawing.Point(12, 12);
            _panelJsonEditor.Name = "panelJsonEditor";
            _panelJsonEditor.Size = new System.Drawing.Size(776, 396);
            _panelJsonEditor.TabIndex = 0;
            // Add buttonSave to the form
            _buttonSave.Location = new System.Drawing.Point(713, 415);
            _buttonSave.Name = "buttonSave";
            _buttonSave.Size = new System.Drawing.Size(75, 23);
            _buttonSave.TabIndex = 1;
            _buttonSave.Text = "Save";
            _buttonSave.UseVisualStyleBackColor = true;
            _buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // Add labelValidation to the form
            _labelValidation.AutoSize = true;
            _labelValidation.Location = new System.Drawing.Point(12, 420);
            _labelValidation.Name = "labelValidation";
            _labelValidation.Size = new System.Drawing.Size(0, 13);
            _labelValidation.TabIndex = 2;

            // Add controls to the form
            Form form = Application.OpenForms[0];
            form.Controls.Add(_panelJsonEditor);
            form.Controls.Add(_buttonSave);
            form.Controls.Add(_labelValidation);
        }
    }
}
