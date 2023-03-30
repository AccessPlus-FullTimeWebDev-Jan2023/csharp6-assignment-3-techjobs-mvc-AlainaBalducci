using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechJobsMVCAutograded6.Data;
using TechJobsMVCAutograded6.Models;

namespace TechJobsMVCAutograded6.Controllers;

public class SearchController : Controller
{
    // GET: /<controller>/
    public IActionResult Index()
    {
        ViewBag.columns = ListController.ColumnChoices;
        
        //ViewBag.tableChoices = ListController.TableChoices;
        //ViewBag.employers = JobData.GetAllEmployers();
        //ViewBag.locations = JobData.GetAllLocations();
        //ViewBag.positionTypes = JobData.GetAllPositionTypes();
        //ViewBag.skills = JobData.GetAllCoreCompetencies();

        return View();
    }
    //[Route("/search")]
    public IActionResult Results(string searchType, string searchTerm)
    {
        List<Job> jobs;

        if (searchTerm == null || searchTerm == "all" || searchTerm == "" )
        {
            jobs = JobData.FindAll();
            ViewBag.jobs = jobs;
            ViewBag.title = "All Jobs";
        }
        else
        {
            jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
            ViewBag.jobs = jobs;
            ViewBag.title = "Jobs with " + searchType + ": " + searchTerm;

        }
        ViewBag.columns = ListController.ColumnChoices;

        return View("Results");
    }

    // TODO #3 - Create an action method to process a search request and render the updated search views.
}

