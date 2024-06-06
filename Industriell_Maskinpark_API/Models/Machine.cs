using static System.Runtime.InteropServices.JavaScript.JSType;
namespace Industriell_Maskinpark_API.Models
{

//    maskinens namn, id (GUID), aktuell status(online/offline) samt senaste data
//som skickats från maskinen.Det ska även finnas en knapp som ska kunna skicka data till maskinen
    public class Machine
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public DateTime LatestContact { get; set; }
        public string LastMessage { get; set; }
    }
}
