using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

public class AnnouncementsController : Controller
{
    private readonly ApplicationDbContext _context;

    public AnnouncementsController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var announcements = _context.Announcements.OrderByDescending(a => a.DatePosted).ToList();
        return View(announcements);
    }

    [HttpPost]
    public IActionResult Create(string title, string content)
    {
        var announcement = new Announcement { Title = title, Content = content };
        _context.Announcements.Add(announcement);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}
