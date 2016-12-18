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
    public partial class BarangPage : ContentPage
    {
        public BarangPage()
        {
            InitializeComponent();
            this.BindingContext = new BarangViewModel();
            listBarang.ItemTapped += ListBarang_ItemTapped;
            BtnTambah.Clicked += BtnTambah_Clicked;
            BtnCariB.Clicked += BtnCariB_Clicked;
            BtnCariK.Clicked += BtnCariK_Clicked;
        }

        private void BtnCariK_Clicked(object sender, EventArgs e)
        {
            this.BindingContext = new SearchByKategori(txtKat.Text);
        }

        private void BtnCariB_Clicked(object sender, EventArgs e)
        {
            this.BindingContext = new SearchByBarang(txtBrg.Text);
        }

        private async void BtnTambah_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TambahBarang());
        }

        private void ListBarang_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Barang item = (Barang)e.Item;
            EditBarang editPage = new EditBarang();
            editPage.BindingContext = item;
            Navigation.PushAsync(editPage);
        }

        protected override void OnAppearing()
        {
            this.BindingContext = new BarangViewModel();
        }
    }
}
