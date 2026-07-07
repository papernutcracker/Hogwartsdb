
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

            var wizards = context.Wizards
                .OrderBy(w => w.Name)
                .ToList();

            Console.WriteLine("Wizards:");
            foreach (var wizard in wizards)
            {
                var core = wizard.Wand?.CoreMaterial ?? "(no wand)";
                Console.WriteLine($"Wizard: {wizard.Name}, House: {wizard.House}, Wand: {core}");
            }
        }
    }
}
