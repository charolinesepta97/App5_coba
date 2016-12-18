using RestSharp.Portable;
using RestSharp.Portable.HttpClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App5_coba.Models;
using App5_coba.ViewModels;
using Xamarin.Forms;


namespace App5_coba
{
    public partial class TambahBarang : ContentPage
    {
        public TambahBarang()
        {
            InitializeComponent();
            btnTambahBarang.Clicked += BtnTambahBarang_Clicked;
        }

        private async void BtnTambahBarang_Clicked(object sender, EventArgs e)
        {
            var _request = new RestRequest("api/Barang", Method.POST);
            var newJenis = new Barang { KodeBarang = Convert.ToInt16(txtKodeBarang.Text), IdJenisMotor = Convert.ToInt16(txtIdJenisMotor.Text), KategoriId = Convert.ToInt16(txtIdKategori.Text)
        , Nama = txtNamaMotor.Text, Stok = Convert.ToInt16(txtStok.Text), HargaBeli = Convert.ToInt16(txtHargaBeli.Text),
          HargaJual = Convert.ToInt16(txtHargaJual.Text), TanggalBeli = Convert.ToDateTime(txtTanggal.Text)};
            _request.AddBody(newJenis);
            try
            {
                var _response = await _client.Execute(_request);
                if (_response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    await Navigation.PopAsync();
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Error: " + ex.Message, "OK");
            }
        }

        private RestClient _client =
             new RestClient("http://contohdbinventorystok.azurewebsites.net/");
    }
}
