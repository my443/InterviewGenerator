using InterviewGenerator.Data;
using InterviewGenerator.Models;
using InterviewGenerator.ViewModels.Screens;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Windows.Input;

namespace InterviewGenerator.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private object _currentViewModel;
        public object CurrentViewModel
        {
            get => _currentViewModel;
            set { _currentViewModel = value; OnPropertyChanged(); }
        }

        public ICommand ShowCategoryItemCommand { get; }
        public ICommand ShowMainScreenCommand { get; }

        public string _filePath = string.Empty;
        public DbContext DbContext { get; set; }

        public string FilePath
        {
            get { return Properties.Settings.Default.FilePath; }
            set
            {
                if (_filePath != value)
                {
                    _filePath = value;
                    Properties.Settings.Default.FilePath = value;
                    Properties.Settings.Default.Save();
                }
            }
        }

        public MainWindowViewModel() {
            var factory = new AppDbContextFactory();
            var db = factory.CreateDbContext(FilePath);
            db.Database.EnsureCreated();

            DbContext = db;

            ShowCategoryItemCommand = new RelayCommand(_ => ShowCategoryScreen());
            ShowMainScreenCommand = new RelayCommand(_ => ShowMainScreen());

            ShowMainScreen();
        }

        private void ShowCategoryScreen(Category selectedCategory = null)
        {
            var viewModel = new CategoryViewModel(DbContext, selectedCategory);
            viewModel.Done = ShowMainScreen;
            CurrentViewModel = viewModel;
        }

        private void ShowMainScreen()
        {
            var viewModel = new HomeScreenViewModel(DbContext);
            viewModel.ShowCategoryScreen = ShowCategoryScreen;
            CurrentViewModel = viewModel;
        }

    }
}
