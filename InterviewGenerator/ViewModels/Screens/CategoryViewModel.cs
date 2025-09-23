using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InterviewGenerator.ViewModels.Screens
{
    public class CategoryViewModel
    {
        public Action Done { get; set; }
        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }

        public CategoryViewModel()
        {
            SaveCommand = new RelayCommand(_ => Save());
            CancelCommand = new RelayCommand(_ => Cancel());
        }

        private void Save()
        {
            // Save logic here...
            Done?.Invoke();
        }
        private void Cancel()
        {
            Done?.Invoke();
        }
    }
}
