using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OneAndMany.Models;

namespace OneAndMany.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext _context;


    public HomeController(ILogger<HomeController> logger,MyContext context)
    {
        _logger = logger;
        _context= context;
    }

    public IActionResult Index()
    {
        ViewBag.posts = _context.Posts.Include(post=> post.Creator).ToList();
        return View();
    }

   [HttpGet("AddUser")]
   public IActionResult AddUser(){
    return View();
   }
    [HttpPost("CreateUser")]
    public IActionResult CreateUser(User useriNgaForma){
        if (ModelState.IsValid)
        {
            _context.Add(useriNgaForma);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View("AddUser");

    }

    [HttpGet("AddPost")]
   public IActionResult AddPost(){
    ViewBag.Users =  _context.Users.ToList();
    return View();
   }
   [HttpPost("CreatePost")]
    public IActionResult CreatePost(Post postNgaForma){
        if (ModelState.IsValid)
        {
            _context.Add(postNgaForma);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        ViewBag.Users =  _context.Users.ToList();
        return View("AddPost");

    }
    [HttpGet("AddComment/{id}")]
   public IActionResult AddComment(int id){
    ViewBag.Users =  _context.Users.ToList();
    ViewBag.post =  _context.Posts.Include(post=>post.komentet).ThenInclude(koment=>koment.creatorOfComment).FirstOrDefault(post=>post.PostId == id);
    return View();
   }
   [HttpPost("CreateComment/{id}")]
    public IActionResult CreateComment(Comment komentiNgaForma,int id){
        if (ModelState.IsValid)
        {
            komentiNgaForma.PostId= id;
            _context.Add(komentiNgaForma);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        ViewBag.post =  _context.Posts.Include(post=>post.komentet).ThenInclude(koment=>koment.creatorOfComment).FirstOrDefault(post=>post.PostId == id);
   
        ViewBag.Users =  _context.Users.ToList();
        return View("AddComment");

    }



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
