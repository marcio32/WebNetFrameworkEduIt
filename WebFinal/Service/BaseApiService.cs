using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web;

namespace WebFinal.Service
{
    public class BaseApiService
    {
        private string apiUrl { get { return ConfigurationManager.AppSettings["apiUrl"]; } }


        protected string GetToApi(string controllerMethodURL, string mail, string token)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response;
            string url = string.Format("{0}/{1}/?mail={2}", apiUrl, controllerMethodURL, mail);

            httpClient.DefaultRequestHeaders.Add("Authorization", token);
            response = httpClient.GetAsync(url).Result;
            response.EnsureSuccessStatusCode();
            return response.Content.ReadAsStringAsync().Result;
        }

        protected HttpResponseMessage DeleteToApi(string controllerMethodURL, int id, string token)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response;
            string url = string.Format("{0}/{1}?id={2}", apiUrl, controllerMethodURL, id);

            httpClient.DefaultRequestHeaders.Add("Authorization", token);
            response = httpClient.GetAsync(url).Result;
            response.EnsureSuccessStatusCode();
            return response;
        }
        protected HttpResponseMessage PostToApi(string controllerMethodURL, object BodyParameters, string token)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response;
            JsonMediaTypeFormatter JSONMediaFormatter = new JsonMediaTypeFormatter();
            HttpContent theContent = null;
            string url = string.Format("{0}/{1}", apiUrl, controllerMethodURL);
            if (BodyParameters != null)
            {
                theContent = new ObjectContent(BodyParameters.GetType(), BodyParameters, JSONMediaFormatter, new MediaTypeHeaderValue("application/json"));
            }

            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Add("Authorization", token);
            response = httpClient.PostAsync(url, theContent).Result;
            //response.EnsureSuccessStatusCode();
            return response;
        }

        protected string LoginToApi(string controllerMethodURL, object BodyParameters)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response;
            JsonMediaTypeFormatter JSONMediaFormatter = new JsonMediaTypeFormatter();
            HttpContent theContent = null;
            string url = string.Format("{0}/{1}", apiUrl, controllerMethodURL);
            if (BodyParameters != null)
            {
                theContent = new ObjectContent(BodyParameters.GetType(), BodyParameters, JSONMediaFormatter, new MediaTypeHeaderValue("application/json"));
            }

            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            response = httpClient.PostAsync(url, theContent).Result;
            //response.EnsureSuccessStatusCode();
            return response.Content.ReadAsStringAsync().Result;
        }
    }
}