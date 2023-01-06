using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Factory.Models
{
  public class Engineer
  {
    public int EngineerId { get; set; }
    [Required(ErrorMessage = "The Engineer's Name can't be empty!")]
    public string Name { get; set; }
    [Required(ErrorMessage = "The Engineer's Details can't be empty!")]
    public string Details { get; set; }
    public List<EngineerMachine> JoinEntities { get; }
  }
}