using System.IO;
using Newtonsoft.Json;
using Register.Business.Layer.Dto;

namespace Register.Business.Layer.Service
    
{
    public class RaportService : IRaportService
    {
        public int CheckHowManyParcent(int maxPoints, int points)
        {

                return points * 100 / maxPoints;
        }

        public string CheckIfResultsIsHigherThanThreshold(int parcent, int threshold)
        {
            string higer = "zaliczone";
            string lower = "niezaliczone";

            if (parcent>=threshold)
            {
                return higer;
            }
            else
            {
                return lower;
            }
        }

        public void ExportRaportToFile(string msg, RaportDto raportDto)
        {
            string filePath = @"C:\Users\Student13\Desktop\du usuniecia\homework_iii\jsonPliki\";
            filePath += msg;
            File.WriteAllText(filePath, JsonConvert.SerializeObject(raportDto, Formatting.Indented));
        }
    }
}