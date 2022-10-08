using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Collections.Specialized;
using System.Net.Http;




public class SendRequests : MonoBehaviour
{
    private static readonly HttpClient httpClient = new HttpClient();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetMouseButtonDown(0))){

            var values = new Dictionary<string, string>
              {
                  { "thing1", "hello" },
                  { "thing2", "world" }
              };

            var content = new FormUrlEncodedContent(values);
            var response = httpClient.PostAsync("http://192.168.0.16:5000/gamedev", content);
            //var responseString = response.Content.ReadAsStringAsync();

            //using (var wb = new WebClient())
            //{
            //    var data = new NameValueCollection();
            //    data["username"] = "myUser";
            //    data["password"] = "myPassword";

            //    var response = wb.UploadValues("http://192.168.0.16:5000/gamedev", "POST", data);
            //    string responseInString = Encoding.UTF8.GetString(response);
            //}
        }

    }
}
