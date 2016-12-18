using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using App5_coba.Models;
using RestSharp;
using RestSharp.Portable.HttpClient;
using RestSharp.Portable;

namespace App5_coba.ViewModels
{
    public class JenisMotorViewModel : BindableObject
    {
        private RestClient _client =
            new RestClient("http://contohdbinventorystok.azurewebsites.net/");

        private ObservableCollection<JenisMotor> listJenis;
        public ObservableCollection<JenisMotor> ListJenis
        {
            get { return listJenis; }
            set { listJenis = value; OnPropertyChanged("ListJenis"); }
        }
        private async void RefreshDataAsync()
        {
            RestRequest _request = new RestRequest("api/JenisMotor", Method.GET);
            var _response = await _client.Execute<List<JenisMotor>>(_request);
            ListJenis = new ObservableCollection<JenisMotor>(_response.Data);
        }
        public JenisMotorViewModel()
        {
            RefreshDataAsync();
        }
    }
}
