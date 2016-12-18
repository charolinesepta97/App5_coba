using RestSharp.Portable.HttpClient;
using RestSharp.Portable;
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
    public partial class EditJenisMotor : ContentPage
    {
        public EditJenisMotor()
        {
            InitializeComponent();
            btnEdit.Clicked += BtnEdit_Clicked;
            btnDelete.Clicked += BtnDelete_Clicked;
        }

        private RestClient _client =
            new RestClient("http://contohdbinventorystok.azurewebsites.net/");

        private async void BtnDelete_Clicked(object sender, EventArgs e)
        {
            var _request = new RestRequest("api/JenisMotor/{id}", Method.DELETE);

            _request.AddParameter("id", txtJenis.Text);
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
                await DisplayAlert("Error", "Error : " + ex.Message, "OK");
            }
        }

        private async void BtnEdit_Clicked(object sender, EventArgs e)
        {
            var _request = new RestRequest("api/JenisMotor", Method.PUT);
            var newJenis = new JenisMotor
            {
                IdJenisMotor = Convert.ToInt32(txtJenis.Text),
                NamaJenisMotor = txtNamaJenisMtr.Text,
                NamaMerk = txtNamaMotor.Text
            };
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
    }
}