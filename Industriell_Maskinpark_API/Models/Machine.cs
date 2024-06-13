using static System.Runtime.InteropServices.JavaScript.JSType;
using Industriell_Maskinpark_API.ViewModels;
using System.Reflection.PortableExecutable;

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

        public Machine()
        {
            
        }

        /// <summary>
        /// Used to create a new machine.
        /// </summary>
        /// <param name="name"></param>
        public Machine(string name)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
            this.Status = false;
            this.LatestContact = DateTime.Now;
            this.LastMessage = string.Empty;
        }

        public Machine(MachineViewModel machineVM)
        {
            this.Id = machineVM.Id;
            this.Name = machineVM.Name;
            if (machineVM.Status == "Online")
            {
                this.Status = true;
            }
            else 
            { 
                this.Status = false; 
            }
            this.LatestContact = machineVM.LatestContact;
            this.LastMessage = machineVM.LastMessage;
        }
    }
}
