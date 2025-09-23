using System;
using System.Collections.Generic;
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

        public HomeScreenViewModel()
        {
            ShowCategoryItemCommand = new RelayCommand(_ => ShowCategoryScreen?.Invoke());
        }
    }
}
