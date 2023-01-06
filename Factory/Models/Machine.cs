using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Factory.Models
{
  public class Machine
  {
    public int MachineId { get; set; }
    [Required(ErrorMessage = "The Machine's Name can't be empty!")]
    public string Name { get; set; }
    [Required(ErrorMessage = "The Machine's Details can't be empty!")]
    public string Details { get; set; }
    public List<EngineerMachine> JoinEntities { get; }
  }
}