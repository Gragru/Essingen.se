using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Script.Serialization;

namespace Essingen.Code
{
    public class Helpers
    {

        public static Image resizeImage(int newWidth, int newHeight, string stPhotoPath)
        {
            Image imgPhoto = Image.FromFile(stPhotoPath);

            int sourceWidth = imgPhoto.Width;
            int sourceHeight = imgPhoto.Height;

            //Consider vertical pics
            if (sourceWidth < sourceHeight)
            {
                int buff = newWidth;

                newWidth = newHeight;
                newHeight = buff;
            }

            int sourceX = 0, sourceY = 0, destX = 0, destY = 0;
            float nPercent = 0, nPercentW = 0, nPercentH = 0;

            nPercentW = ((float)newWidth / (float)sourceWidth);
            nPercentH = ((float)newHeight / (float)sourceHeight);
            if (nPercentH < nPercentW)
            {
                nPercent = nPercentH;
                destX = System.Convert.ToInt16((newWidth -
                          (sourceWidth * nPercent)) / 2);
            }
            else
            {
                nPercent = nPercentW;
                destY = System.Convert.ToInt16((newHeight -
                          (sourceHeight * nPercent)) / 2);
            }

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);


            Bitmap bmPhoto = new Bitmap(newWidth, newHeight,
                          PixelFormat.Format24bppRgb);

            bmPhoto.SetResolution(imgPhoto.HorizontalResolution,
                         imgPhoto.VerticalResolution);

            Graphics grPhoto = Graphics.FromImage(bmPhoto);
            grPhoto.Clear(Color.White);
            grPhoto.InterpolationMode =
                System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            grPhoto.DrawImage(imgPhoto,
                new Rectangle(destX, destY, destWidth, destHeight),
                new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
                GraphicsUnit.Pixel);

            grPhoto.Dispose();
            imgPhoto.Dispose();

            return bmPhoto;
        }

        public static string GetSL(string siteid, string filter, string transportmode, string timewindow, int maxhits)
        {
            string URL = "http://api.sl.se/api2/realtimedeparturesv4.json";


            //string URL = "https://api.trafiklab.se/sl/realtid2/GetAllDepartureTypes.json/" + siteid + "/20";
            string urlParameters = "?key=f1b7512b0672495d93ef0037f5f1b297&siteid=" + siteid + "&timewindow=" + timewindow;
            string output = "<table width=\"100%\">";


            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            // List data response.
            HttpResponseMessage response = client.GetAsync(urlParameters).Result;  // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body. Blocking!

                string json = response.Content.ReadAsStringAsync().Result;
                //DataObjects.Rootobject myDeserializedObj = (DataObjects.Rootobject)JavaScriptConvert.DeserializeObject(Request["jsonString"], typeof(Test));
                var entity = new JavaScriptSerializer().Deserialize<DataObjects.SL.DataObjects.Rootobject>(json);





                //List<DataObjects.Rootobject> myDeserializedObjList = (List<DataObjects.Rootobject>)Newtonsoft.Json.JsonConvert.DeserializeObject(response.Content.ReadAsStringAsync().Result, typeof(List<DataObjects.Rootobject>));


                //var dataObjects = response.Content.ReadAsAsync<IEnumerable<DataObjects.Bus>>().Result;
                int counter = 0;
                if (transportmode.ToLower() == "bus")
                {
                    foreach (var d in entity.ResponseData.Buses)
                    {
                        if (d.Destination.ToLower() != filter.ToLower() && counter < maxhits)
                        {
                            output += "<tr><td width=10%>" + d.LineNumber + "</td><td>" + d.Destination + "</td><td width=20%>" + d.DisplayTime + "</td></tr>";
                            counter += 1;
                        }
                    }
                }
                if (transportmode.ToLower() == "tram")
                {
                    foreach (var d in entity.ResponseData.Trams)
                    {
                        if (d.Destination.ToLower() != filter.ToLower() && counter < maxhits)
                        {
                            output += "<tr><td width=10%>" + d.LineNumber + "</td><td>" + d.Destination + "</td><td width=20%>" + d.DisplayTime + "</td></tr>";
                            counter += 1;
                        }
                    }
                }
            }
            else
            {
                output += ((int)response.StatusCode + response.ReasonPhrase);
            }
            return output + "</table>";
        }



    }
}