using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Diagnostics;

namespace XamlResponsiveTechniques
{
    public class AutoPredictionAzureMLClient
    {


        public static async Task<string> InvokeRequestResponseService(String EquipmentID, String GroupID, double Sequence, double Cycle, double VP1, double VP2, double VP3,
            double VAP1, double VAP2, double VAP3, double VAP4, double VAP5, double VAP6, double VAP7, double VAP8, double VAP9, double VAP10,
            double VHP1, double VHP2, double VHP3, double VHP4, double VHP5, double VHP6, double VHP7, double VHP8, double VHP9, double VHP10,
            double VVP1, double VVP2, double VVP3, double VVP4, double VVP5, double VVP6, double VVP7, double VVP8, double VVP9, double VVP10,
            double TP1, double TP2, double TP3, double TP4, double TP5, double TP6, double TP7, double TP8, double TP9, double TP10, double TTl
            )
        {
            using (var client = new HttpClient())
            {
                ScoreData scoreData = new ScoreData()
                {
                    FeatureVector = new Dictionary<string, string>()
                    {
                     //   { "EquipmentID", EquipmentID },
                        { "GroupID", GroupID },
                      //  { "Sequence", Sequence.ToString() },
                        { "Cycle", Cycle.ToString()},

                        { "Vibration  A P1", VAP1.ToString() },
                        { "Vibration  A P2", VAP2.ToString() },
                        { "Vibration  A P3", VAP3.ToString() },
                        { "Vibration  A P4", VAP4.ToString() },
                        { "Vibration  A P5", VAP5.ToString() },
                        { "Vibration  A P6", VAP6.ToString() },
                        { "Vibration  A P7", VAP7.ToString() },
                        { "Vibration  A P8", VAP8.ToString() },
                        { "Vibration  A P9", VAP9.ToString() },
                        { "Vibration  A P10", VAP10.ToString()},

                        { "Vibration  H P1", VHP1.ToString() },
                        { "Vibration  H P2", VHP2.ToString() },
                        { "Vibration  H P3", VHP3.ToString() },
                        { "Vibration  H P4", VHP4.ToString() },
                        { "Vibration  H P5", VHP5.ToString() },
                        { "Vibration  H P6", VHP6.ToString() },
                        { "Vibration  H P7", VHP7.ToString() },
                        { "Vibration  H P8", VHP8.ToString() },
                        { "Vibration  H P9", VHP9.ToString() },
                        { "Vibration  H P10", VHP10.ToString() },

                          { "Température P10", TP10.ToString() },
                          { "Température P8", TP8.ToString()},
                          {"Température P9", TP9.ToString()},
                          { "Température P6", TP6.ToString()},
                          { "Température P7", TP7.ToString()},
                          { "Température P4", TP4.ToString()},
                          { "Température P5", TP5.ToString()},
                          { "Température P2", TP2.ToString()},
                          { "Température P3", TP3.ToString()},
                          { "Température P1", TP1.ToString()},

                          { "Vibration  V P10", VVP10.ToString() },
                          { "Vibration  V P9", VVP9.ToString()},
                          { "Vibration  V P8", VVP8.ToString()},
                          { "Vibration  V P7", VVP7.ToString()},
                          { "Vibration  V P6", VVP6.ToString()},
                          { "Vibration  V P5", VVP5.ToString()},
                          { "Vibration  V P4", VVP4.ToString()},
                          { "Vibration  V P3", VVP3.ToString()},
                          { "Vibration  V P2", VVP2.ToString()},
                          { "Vibration  V P1", VVP1.ToString()},

                          { "Vibration P1", VP1.ToString()},
                          { "Vibration P2", VP3.ToString()},
                          { "Vibration P3",VP3.ToString()},
                          { "TTL", TTl.ToString()}

                    },
                    GlobalParameters = new Dictionary<string, string>()
                    {
                    }
                };

                ScoreRequest scoreRequest = new ScoreRequest()
                {
                    Id = "score00001",
                    Instance = scoreData
                };

                const string apiKey = "fT2LYRcF3PfngInfR/ornGuWOVt3JLI4RUB7FV/q4NlE3JuLoW9ktbNtthICT3yVUWOzmRCFjAE13qPz0memOw=="; // Replace this with the API key for the web service
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

                client.BaseAddress = new Uri("https://europewest.services.azureml.net/workspaces/dc713004d5f14fd7a71f235c469976df/services/b29354ade2b44725beae07be4554e1b0/score");
                HttpResponseMessage response = await client.PostAsJsonAsync("", scoreRequest);
                if (response.IsSuccessStatusCode)
                {
                    string jsonString = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine(jsonString);

                    String[] rs = JsonConvert.DeserializeObject<string[]>(jsonString);
                    if (rs != null && rs.Count() > 0)
                    {
                        return String.Format("{0:0.00}", (Double.Parse(rs[0])));
                    }

                    throw new Exception("Nothing returned.");

                }
                else
                {
                    throw new Exception(string.Format("Failed with status code: {0}", response.StatusCode));
                }
            }
        }
    }

    public class ScoreData
    {
        public Dictionary<string, string> FeatureVector { get; set; }
        public Dictionary<string, string> GlobalParameters { get; set; }
    }

    public class ScoreRequest
    {
        public string Id { get; set; }
        public ScoreData Instance { get; set; }
    }


    public class Response
    {
        public string[] Properties { get; set; }
    }

}







