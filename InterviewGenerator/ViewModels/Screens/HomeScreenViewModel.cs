using InterviewGenerator.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InterviewGenerator.ViewModels.Screens
{
    public class HomeScreenViewModel
    {
        public Action<Category> ShowCategoryScreen { get; set; }
        public ICommand ShowCategoryItemCommand { get; }
        public ICommand CategoryDoubleClickCommand { get; }
        public ObservableCollection<Category> Categories { get; set; }
        public DbContext DbContext { get; set; } 

        public HomeScreenViewModel(DbContext dbContext)
        {
            DbContext = dbContext;
            ShowCategoryItemCommand = new RelayCommand(
                categoryObj => ShowCategoryScreen?.Invoke(categoryObj as Category)
            );
            CategoryDoubleClickCommand = new RelayCommand(OnCategoryDoubleClick);

            LoadCategories();
        }

        private void LoadCategories()
        {
            var categories = DbContext.Set<Category>().ToList();
            Categories = new ObservableCollection<Category>(categories);
        }

        private void OnCategoryDoubleClick(object parameter)
        {
            var category = parameter as Category; // Cast parameter to Category

            if (category != null)
            {
                // Navigate, open detail view, etc.
                ShowCategoryItemCommand.Execute(category);
                Console.WriteLine($"Double-clicked: {category.Name}");
            }
        }
    }
}
