using System.Collections.Generic;
using System.Linq;
using MessageClient.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MessageClient.Controllers
{
  public class GroupsController : Controller
  {
    private readonly MessageClientContext _db;

    public GroupsController(MessageClientContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Group> model = _db.Groups.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Group group)
    {
      _db.Groups.Add(group);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisGroup = _db.Groups.Include(group => group.JoinEntities).ThenInclude(join => join.Message).FirstOrDefault(group => group.GroupId == id);
      return View(thisGroup);
    }
  }
}