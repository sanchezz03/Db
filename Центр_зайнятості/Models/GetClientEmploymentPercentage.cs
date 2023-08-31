namespace Центр_зайнятості.Models
{
    public class GetClientEmploymentPercentage
    {
        public int TotalClientsBefore { get; set; }
        public int TotalClientsAfter { get; set; }
        public decimal EmploymentPercentageAfter { get; set; }
    }
}
