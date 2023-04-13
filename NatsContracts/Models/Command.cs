using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// ВОЗМОЖНО ДОРАБАТЫВАТЬ
namespace NatsContracts.Models
{
    public class Command
    {
        public string CommandName { get; set; }
        public int Time { get; set; }
    }
}
