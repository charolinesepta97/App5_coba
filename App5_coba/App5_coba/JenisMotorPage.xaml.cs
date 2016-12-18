using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using App5_coba.ViewModels;
using App5_coba.Models;
namespace App5_coba
{
    public partial class JenisMotorPage : ContentPage
    {
        public JenisMotorPage()
        {
            InitializeComponent();
            this.BindingContext = new JenisMotorViewModel();
            listJenis.ItemTapped += ListJenis_ItemTapped;
            btnTambah.Clicked += BtnTambah_Clicked;
        }

        private async void BtnTambah_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TambahJenisMotor());
        }

        protected override void OnAppearing()
        {
            this.BindingContext = new JenisMotorViewModel();
        }

        private void ListJenis_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            JenisMotor item = (JenisMotor)e.Item;
            EditJenisMotor editPage = new EditJenisMotor();
            editPage.BindingContext = item;
            Navigation.PushAsync(editPage);
        }
    }
}
