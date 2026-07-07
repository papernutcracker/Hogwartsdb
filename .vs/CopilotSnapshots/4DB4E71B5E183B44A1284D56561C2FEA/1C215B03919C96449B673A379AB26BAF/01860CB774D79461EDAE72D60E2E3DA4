
namespace Hogwards.Models
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var context = new HogwartsdbContext();

            var activeWizards = context.Vw_ActiveWizards
                .OrderBy(w => w.Name)
                .Select(w => w.Name)
                .ToList();

            Console.WriteLine("Active Wizards: ");
            foreach (var wizard in activeWizards) {

                Console.WriteLine($"- {wizard}");
            }
        }
    }
}
