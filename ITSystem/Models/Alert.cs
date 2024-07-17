using System.Xml.Linq;

namespace ITSystem.Models
{
    public class Alert
    {
        public int ID { get; set; }

        public DateTime? DateTimeStamp { get; set; }

        public string? Source { get; set; }

        public string? Type { get; set; }

        public string? Title { get; set; }

        public string? Data { get; set; }

        private static readonly IDictionary<AlertType, string[]> alertTypesStorage = new Dictionary<AlertType, string[]>
        {
            { AlertType.Blanks, new[] { " ", " "}},
            { AlertType.Warning, new[] {"Failed"," Fail"}},
            { AlertType.Confirmation, new[] {"Success", "Successfully"}},

        };

        public bool IsTypeOf(AlertType alertType) //Checking event/alert Type
        {
            return alertTypesStorage.ContainsKey(alertType) &&
                alertTypesStorage[alertType].Any(x => Title.Contains(x));
        }
    }
}
