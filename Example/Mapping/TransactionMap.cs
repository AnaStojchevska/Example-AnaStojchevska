using CsvHelper.Configuration;
using Example.Models;
namespace Example.Mapping
{ 
public class TransactionMap : ClassMap<Transaction>
{
    public TransactionMap()
    {
        Map(m => m.Id).Index(0);
        Map(m => m.BeneficiaryName).Name("beneficiary-name");
        Map(m => m.Date).Name("date");
        Map(m => m.Direction).Name("direction");
        Map(m => m.Amount).Name("amount");
        Map(m => m.Description).Name("description");
        Map(m => m.Currency).Name("currency");
        Map(m => m.Mcc).Name("mcc");
        Map(m => m.Kind).Name("kind");
    }
} }
