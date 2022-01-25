using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PictureFrame
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadConfig();
        }

        private string ConfigFilePath = @"%USERPROFILE%\AppData\Local\PictureFrame\settings.json";

        public void LoadConfig()
        {
            string ConfigurationJsonString = "";
            var JsonOptions = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            Configuration JsonConfiguration = JsonSerializer.Deserialize<Configuration>(ConfigurationJsonString, JsonOptions);

            WindowWidth = JsonConfiguration.DefaultWindowWidth;
            WindowHeight = JsonConfiguration.DefaultWindowHeight;
            LoadedImagePath = JsonConfiguration.LoadedFilePath;
            ImageUniformScale = JsonConfiguration.UniformScale;
        }

        private uint WindowWidth = 800;
        private uint WindowHeight = 450;
        private string LoadedImagePath = "";
        private double ImageUniformScale = 1.0;

        private void OnMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("내용", "제목");
        }
    }
}

class Configuration
{
    public uint DefaultWindowWidth = 800;
    public uint DefaultWindowHeight = 450;
    public string LoadedFilePath = "";
    public double UniformScale = 1.0;
}