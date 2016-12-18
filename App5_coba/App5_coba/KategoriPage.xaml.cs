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
    public partial class KategoriPage : ContentPage
    {
        public KategoriPage()
        {
            InitializeComponent();
            this.BindingContext = new KategoriViewModel();
            listKategori.ItemTapped += listKategori_ItemTapped;
            btnTambah.Clicked += BtnTambah_Clicked;
        }

        private async void BtnTambah_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TambahKategori());
        }

        protected override void OnAppearing()
        {
            this.BindingContext = new KategoriViewModel();
        }

        private void listKategori_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Kategori item = (Kategori)e.Item;
            EditKategori editPage = new EditKategori();
            editPage.BindingContext = item;
            Navigation.PushAsync(editPage);
        }
    }
}
