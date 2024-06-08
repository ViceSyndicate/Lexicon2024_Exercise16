using Industriell_Maskinpark_API.Models;
using System.Reflection.PortableExecutable;

namespace Industriell_Maskinpark_API.ViewModels
{
    public class MachineViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public DateTime LatestContact { get; set; }
        public string LastMessage { get; set; }

        public MachineViewModel(Models.Machine machine)
        {
            this.Id = machine.Id;
            this.Name = machine.Name;
            if (machine.Status) { Status = "Online"; }
            else { Status = "Offline"; }
            this.LatestContact = machine.LatestContact;
            this.LastMessage = machine.LastMessage;
        }

        public MachineViewModel(Guid id, string name, bool status, DateTime latestContact, string lastMessage)
        {
            this.Id = id;
            this.Name = name;
            if(status) { Status = "Online"; }
            else { Status = "Offline"; }
            this.LatestContact = latestContact;
            this.LastMessage = lastMessage;
        }
    }

}
