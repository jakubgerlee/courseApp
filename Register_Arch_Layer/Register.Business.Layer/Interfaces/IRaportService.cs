using Register.Business.Layer.Dto;

namespace Register.Business.Layer.Service
{
    public interface IRaportService
    {
        int CheckHowManyParcent(int maxPoints, int points);
        string CheckIfResultsIsHigherThanThreshold(int parcent, int threshold);
        void ExportRaportToFile(string msg, RaportDto raportDto);
    }
}