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
        public Action ShowCategoryScreen { get; set; }
        public ICommand ShowCategoryItemCommand { get; }
        public ObservableCollection<Category> Categories { get; set; }
        public DbContext DbContext { get; set; } 

        public HomeScreenViewModel(DbContext dbContext)
        {
            DbContext = dbContext;
            ShowCategoryItemCommand = new RelayCommand(_ => ShowCategoryScreen?.Invoke());
            LoadCategories();
        }

        private void LoadCategories()
        {
            var categories = DbContext.Set<Category>().ToList();
            Categories = new ObservableCollection<Category>(categories);
        }
    }
}
