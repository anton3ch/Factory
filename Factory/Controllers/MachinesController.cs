using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Factory.Controllers
{
  public class MachinesController : Controller
  {
    private readonly FactoryContext _db;

    public MachinesController(FactoryContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      ViewBag.PageTitle = "View All Machines";
      List<Machine> MachineList = _db.Machines.Include(machine => machine.JoinEntities)
                                    .ThenInclude(join => join.Engineer).OrderByDescending(machine => machine.JoinEntities.Count).ToList();

      return View(MachineList);
    }

    public ActionResult Details(int id)
    {
      Machine thisMachine = _db.Machines
                              .Include(machine => machine.JoinEntities)
                              .ThenInclude(join => join.Engineer)
                              .FirstOrDefault(machine => machine.MachineId == id);
      ViewBag.PageTitle = $"{thisMachine.Name} Details";
      return View(thisMachine);
    }

    public ActionResult Create()
    {
      ViewBag.PageTitle = "Add Machine";
      return View();
    }

    [HttpPost]
    public ActionResult Create(Machine machine)
    {
      ViewBag.PageTitle = "Machines";
      if (!ModelState.IsValid)
      {
        return View(machine);
      }
      else
      {
        _db.Machines.Add(machine);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }
    }

    public ActionResult AddEngineer(int id)
    {
      Machine thisMachine = _db.Machines
                              .Include(machine => machine.JoinEntities)
                              .ThenInclude(join => join.Engineer)
                              .FirstOrDefault(machine => machine.MachineId == id);
      ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "Name");
      ViewBag.PageTitle = $"Add Engineer to {thisMachine.Name}'s Schedule";
      return View(thisMachine);
    }

    [HttpPost]
    public ActionResult AddEngineer(Machine machine, int engineerId)
    {
      #nullable enable
      EngineerMachine? joinEntity = _db.EngineerMachines.FirstOrDefault(join => (join.EngineerId == engineerId && join.MachineId == machine.MachineId));
      #nullable disable
      if (joinEntity == null && engineerId != 0)
      {
        _db.EngineerMachines.Add(new EngineerMachine() { EngineerId = engineerId, MachineId = machine.MachineId });
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new { id = machine.MachineId });
    }

    public ActionResult Edit(int id)
    {
      Machine thisMachine = _db.Machines.FirstOrDefault(machines => machines.MachineId == id);
      ViewBag.PageTitle = $"Modify {thisMachine.Name}";
      return View(thisMachine);
    }

    [HttpPost]
    public ActionResult Edit(Machine machine)
    {
      _db.Machines.Update(machine);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Machine thisMachine = _db.Machines.FirstOrDefault(machines => machines.MachineId == id);
      ViewBag.PageTitle = $"Delete {thisMachine.Name}";
      return View(thisMachine);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Machine thisMachine = _db.Machines.FirstOrDefault(machines => machines.MachineId == id);
      _db.Machines.Remove(thisMachine);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult DeleteJoin(int joinId)
    {
      EngineerMachine joinEntry = _db.EngineerMachines.FirstOrDefault(entry => entry.EngineerMachineId == joinId);
      _db.EngineerMachines.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }



    // [HttpPost]
    // public ActionResult AddEngineer(Engineer engineer, int machineId)
    // {
    //   #nullable enable
    //   EngineerMachine? joinEntity = _db.EngineerMachines.FirstOrDefault(join => (join.MachineId == machineId && join.EngineerId == engineer.EngineerId));
    //   #nullable disable
    //   if (joinEntity == null && machineId != 0)
    //   {
    //     _db.EngineerMachines.Add(new EngineerMachine() { MachineId = machineId, EngineerId = engineer.EngineerId });
    //     _db.SaveChanges();
    //   }
    //   return RedirectToAction("Details", new { id = engineer.EngineerId });
    // }
  }
}