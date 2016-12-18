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
    public partial class TambahJenisMotor : ContentPage
    {
        public TambahJenisMotor()
        {
            InitializeComponent();
            btnTambahJenis.Clicked += BtnTambahJenis_Clicked;
        }

        private async void BtnTambahJenis_Clicked(object sender, EventArgs e)
        {
            var _request = new RestRequest("api/JenisMotor", Method.POST);
            var newJenis = new JenisMotor { NamaJenisMotor = txtNamaJenisMtr.Text , NamaMerk = txtNamaMotor.Text};
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
