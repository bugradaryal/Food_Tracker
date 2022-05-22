using System;
using System.Text;
using System.Net;
using System.IO;
using Entities;

namespace BackGroundJobs.Managers
{
    public class Sms
    {
        private string XMLPOST(string PostAddress, string xmlData)
        {
            try
            {
                var res = "";
                byte[] bytes = Encoding.UTF8.GetBytes(xmlData);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(PostAddress);

                request.Method = "POST";
                request.ContentLength = bytes.Length;
                request.ContentType = "text/xml";
                request.Timeout = 300000000;
                using (Stream requestStream = request.GetRequestStream())
                {
                    requestStream.Write(bytes, 0, bytes.Length);
                }

                // This sample only checks whether we get an "OK" HTTP status code back.
                // If you must process the XML-based response, you need to read that from
                // the response stream.
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        string message = String.Format(
                        "POST failed. Received HTTP {0}",
                        response.StatusCode);
                        throw new ApplicationException(message);
                    }

                    Stream responseStream = response.GetResponseStream();
                    using (StreamReader rdr = new StreamReader(responseStream))
                    {
                        res = rdr.ReadToEnd();
                    }
                    return res;
                }
            }
            catch
            {

                return "-1";
            }

        }
        public void smsbody(User user, Food myfood)
        {
            String testXml = "<request>";
            testXml += "<authentication>";
            testXml += "<username>5313375881</username>";
            testXml += "<password>31082000bugra12</password>";
            testXml += "</authentication>";
            testXml += "<order>";
            testXml += "<sender>APITEST</sender>";
            testXml += "<sendDateTime></sendDateTime>";
            testXml += "<message>";
            testXml += "<text>" + myfood.yemek_ismi + " Adlı yemeğinizin bozulmasına son 24 saat kalmıştır.</text>";
            testXml += "<receipents>";
            testXml += "<number>" + user.Telefon + "</number>";
            testXml += "</receipents>";
            testXml += "</message>";
            testXml += "</order>";
            testXml += "</request>";

            this.XMLPOST("http://api.iletimerkezi.com/v1/send-sms", testXml);
        }

    }
}
