using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Newtonsoft.Json;

namespace App2.ViewModel
{           
    
   public class Comments
   {
     public int postId { get; set; }
     public int id { get; set; }
     public string name { get; set; }
     public string email { get; set; }
     public string body { get; set; }
   } 
    
    public class Resp
    {
       public List<Comments> Response { get; set; }
    }

    public class MainPageViewModel : BindableObject
    { 
       
        public ObservableCollection<Comments> SomeData;
        HttpClient client;
        private object source;

        public ICommand Fill => new Command(OnRequest);
   
        private const string url = "https://192.168.1.101:26333/Test/GetSome";

        public object Source
        {
            get => source;
            set
            {
                source = value;
                OnPropertyChanged();
            }
            
        }

       public async void OnRequest()
        {
            client = new HttpClient();
            var result = await client.GetStringAsync(url);
            SomeData = new ObservableCollection<Comments>(JsonConvert.DeserializeObject <List<Comments>>(result));
            Source = SomeData;
            /*var comments = JsonConvert.DeserializeObject<Resp>(result);
            SomeData = new ObservableCollection<Comments>(comments.Response);*/

        }
       

    }
}
