﻿using System;
using Xamarin.Forms;
using TpExam.Models;

namespace TpExam
{
    public partial class UpdateCategoryPage : ContentPage
    {
        private Categorie _category;

        public UpdateCategoryPage(Categorie category)
        {
            InitializeComponent();
            _category = category;
        }

        private async void UpdateButton_Clicked(object sender, EventArgs e)
        {
            // Update the category name and save changes
            _category.Nom = UpdatedCategoryName.Text;
            App.Database.ModifierCategorie(_category);

            // Log a message
            Console.WriteLine($"Category {_category.Nom} updated.");

            // Notify CategoriesPage to refresh the list
            MessagingCenter.Send(this, "RefreshCategories");
            
            // Navigate back to the CategoriesPage
            await Navigation.PopAsync();
        }
        
        
    }
}
