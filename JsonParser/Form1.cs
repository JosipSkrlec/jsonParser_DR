// Ignore Spelling: Json

using JsonParser.Scripts;
using System;
using System.Windows.Forms;

namespace JsonParser
{
    /// <summary>
    /// 
    /// </summary>
    public partial class DeltaReality_JsonParser : Form
    {
        private string jsonFilePath = "C:/Users/Josip/Desktop/JsonParserApp/json1.json"; // Specify the path to your JSON file

        DelayController delayController = new DelayController();
        JsonFileLoaderController jsonFileLoaderController = new JsonFileLoaderController();
        JsonLoaderController jsonLoaderController = new JsonLoaderController();

        CanvasController canvasController = new CanvasController();

        public DeltaReality_JsonParser()
        {
            InitializeComponent();

            canvasController.ToggleKeyEvents(this,true);

            delayController.OnDelayFinishedEvent += OnDelayFinished;
            delayController.StartDelay();
        }

        private void OnDelayFinished()
        {
            jsonFileLoaderController.OnJsonFileLoadedEvent += OnJsonFileLoaded;
            jsonFileLoaderController.ToggleDragDropDetection(this, true);

            canvasController.HideCanvasElement(DRGifLoader);
        }

        private void OnJsonFileLoaded(string obj)
        {
            jsonFileLoaderController.ToggleDragDropDetection(this, false);

            jsonLoaderController.OnJsonLoadedEvent += OnJsonLoaded;
            jsonLoaderController.LoadJson(obj);

            canvasController.HideCanvasElement(JsonFileLoader);
        }

        private void OnJsonLoaded()
        {
            Console.WriteLine("JSON FILE LOADED!");
        }
    }
}