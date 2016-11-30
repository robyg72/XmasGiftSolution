using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace XmasGift
{
    public static class NetworkServices
    {
        public static async Task<ObservableCollection<GiftInfo>> GetGiftList(string year)
        {
            ObservableCollection<GiftInfo> gifts = new ObservableCollection<GiftInfo>();
            HttpClient client = new HttpClient();
            try { 
            client.MaxResponseContentBufferSize = 256000;
            string RestUrl = @"";
            var uri = new Uri(string.Format(RestUrl, string.Empty));
    
            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                gifts = JsonConvert.DeserializeObject<ObservableCollection<GiftInfo>>(content);
            }
            }
            catch
            {
                gifts = null;
            }
            return gifts;
        }
    }
}
