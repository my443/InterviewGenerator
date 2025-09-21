using InterviewGenerator.Models;

namespace InterviewGenerator.ViewModels
{
    public class MainWindowViewModel
    {
        public string _filePath = string.Empty;
        public List<Category> Categories { get; set; } = new List<Category>();
        public List<Question> Questions { get; set; } = new List<Question>();        
        public string FilePath
        {
            get { return _filePath; }
            set
            {
                if (_filePath != value)
                {
                    _filePath = value;
                }
            }
        }
        public MainWindowViewModel() { }

    }
}
