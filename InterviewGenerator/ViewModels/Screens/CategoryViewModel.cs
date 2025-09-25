using Microsoft.EntityFrameworkCore;
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
        public DbContext DbContext { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }



        public CategoryViewModel(DbContext dbContext)
        {
            DbContext = dbContext;
            SaveCommand = new RelayCommand(_ => Save());
            CancelCommand = new RelayCommand(_ => Cancel());
        }

        private void Save()
        {
            if (CategoryName != null)
            {
                var category = new Models.Category
                {
                    Name = CategoryName,
                    Description = Description ?? ""
                };

                DbContext.Add(category);
                DbContext.SaveChanges();
                Done?.Invoke();             // Only invoke done if you have saved. Otherwise you have to hit cancel.
            }


        }
        private void Cancel()
        {
            Done?.Invoke();
        }
    }
}
