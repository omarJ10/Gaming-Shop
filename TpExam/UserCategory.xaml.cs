using System;
using System.Collections.Generic;
using Xamarin.Forms;
using TpExam.Models;

namespace TpExam
{
    public partial class UserCategory : ContentPage
    {
        public UserCategory()
        {
            InitializeComponent();

            // Populate the ListView with existing categories
            List<Categorie> categories = App.Database.ObtenirCategories();
            CategoriesListView.ItemsSource = categories;
        }

        private async void OnCategorySelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            // Get the selected category
            Categorie selectedCategory = e.SelectedItem as Categorie;

            // Navigate to the ProductsPage and pass the selected category ID
            await Navigation.PushAsync(new UserProducts(selectedCategory.Id));

            // Deselect the item
            CategoriesListView.SelectedItem = null;
        }
    }
}
