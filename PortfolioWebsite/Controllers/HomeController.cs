using BartlomiejJagielloLab4ZadDom.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BartlomiejJagielloLab4ZadDom.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        // File path to a file used to store contact messages
        private const string MessagesPath = "messages.txt";

        // List of portfolio projects
        private List<ProjectViewModel> _allProjects;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            // Create a list of projects
            _allProjects = new List<ProjectViewModel>();

            _allProjects.Add(new ProjectViewModel("Village builder", "Game goal is to reach 500 village population. " +
                "There are many random events which prevent player from reaching goal. " +
                "\nIncrease your production, buy upgrades and protect your people from different disasters. " +
                "\nIncrease your faith and population to earn more gold. " +
                "\nSpeed up, slow down or pause the game at any moment." +
                "\nGame build using purely C# and Windows Forms.", new List<string>()
            {
                    "~/img/game1.png",
                    "~/img/game2.png",
                    "~/img/game3.png"
            }));

            _allProjects.Add(new ProjectViewModel("Personal trainer", "Application made to help you stay fit. " +
                "\nChoose workouts. Create new training sessions and track your progress" +
                "\nBuilt using C#, Windows Forms and Windows Sql database." +
                "\n Currently unfinished, application will be rewritten in Python Kivy.", new List<string>()
            {
                "~/img/PersonalTrainer1.png",
                "~/img/PersonalTrainer2.png",
                "~/img/PersonalTrainer3.png"
                }));

            ProjectViewModel game = new ProjectViewModel("2048", "2048 game clone. Play the game and compare your score to famous people.",
                new List<string>()
                {
                    "~/img/2048.png"
                });
            game.addComment("Reknor", "Nice game. My mum wrote something like this when she was 10.");
            _allProjects.Add(game);
        }

        // Default main website view
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        // Default privacy sub page
        public IActionResult Privacy()
        {
            return View();
        }

 
        // Page containing all projects in shortcut
        [HttpGet]
        public IActionResult Portfolio()
        {
            return View(_allProjects);
        }


        // Page used to show chosen project in details
        [HttpGet]
        public IActionResult GetProject(string projectName)
        {
            var project = _allProjects.Where(a => a.Name.ToLower() == projectName.ToLower()).FirstOrDefault();
            // Get current opened project name for adding comments
            TempData["projectName"] = project.Name;
            return View(project);
        }

        // User add comment page

        [HttpGet]
        public IActionResult AddComment()
        {
            return View();
        }
        
        // Adding a new comment

        [HttpPost]
        public IActionResult AddComment(ProjectViewModel.Comment comment)
        {
            // If required fields were given
            if (ModelState.IsValid)
            {
                var project = _allProjects.Where(a => a.Name.ToLower() == TempData["projectName"].ToString().ToLower()).FirstOrDefault();
                project.addComment(comment.Nick, comment.Message);
                return View("GetProject", project);
            }
            return View();
        }

        // Form used to contact website owner
        [HttpGet]
        public IActionResult ContactForm()
        {
            return View();
        }

        // Information to user concerning his message
        [HttpPost]
        public IActionResult ContactForm(ContactFormViewModel userData)
        {
            // If required fields were given
            if (ModelState.IsValid)
            {
                // Save user message
                bool saved = SaveMessage(userData.Name, userData.Email, userData.Text);

                ViewBag.Name = userData.Name;

                if (saved)
                    // Confirmation to user that his contact message was saved
                    return View("ContactFormConfirmation");
                // Unable to save
                return View();
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // Save user message to file
        private bool SaveMessage(string name, string email, string message)
        {
            string[] lines = { "---------------------", name, email, message, "" };

            try
            {
                using (StreamWriter outputFile = new StreamWriter(MessagesPath, append: true))
                {
                    foreach (string l in lines)
                        outputFile.WriteLine(l);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e);
                return false;
            }
            return true;
        }
    }
}

