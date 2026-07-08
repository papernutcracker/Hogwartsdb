using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Hogwards.Models
{
    public class Program
    {
        public static void Main(string[] args)
        {
            System.Text.Encoding utf8 = new System.Text.UTF8Encoding(false);
            Console.OutputEncoding = utf8;
            Console.InputEncoding = utf8;

            var context = new HogwartsdbContext();

            string targetHouse = "Грифіндор";
            var houseParam = new SqlParameter("@House", targetHouse);

            var wizards = context.Wizards
                .FromSqlRaw("EXECUTE dbo.GetWizardsByHouse @House", houseParam)
                .ToList();

            foreach (var w in wizards)
            {
                Console.WriteLine($"{w.Name} навчається на факультеті {w.House}");
            }

        }
    }
}
