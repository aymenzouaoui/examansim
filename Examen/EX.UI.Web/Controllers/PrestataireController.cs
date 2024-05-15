using EX.Core.Domain;
using EX.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EX.UI.Web.Controllers
{
    public class PrestataireController : Controller
    {
        readonly IPrestataireService prestataireService;
        readonly IClientService clientService;  
        readonly ISpecialiteService specialiteService;
        readonly IPresationService presationService;

        public PrestataireController(IPrestataireService prestataireServicen,IClientService clientService, ISpecialiteService specialite,IPresationService presationService)
        {this.clientService = clientService;
            this.prestataireService = prestataireServicen;
            this.specialiteService = specialite;
            this.presationService = presationService;
            
        }

        // GET: PrestataireController
        public ActionResult Index()
        {
            return View(prestataireService.GetAll());
        }

        // GET: PrestataireController
        public ActionResult Index2()
        {
            return View(presationService.GetAll());
        }
        // GET: PrestataireController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PrestataireController/Create
        public ActionResult Create()
        {
            var c = specialiteService.GetAll();
            ViewBag.P = new SelectList(c, "code", "code");
            return View();
        }

        // POST: PrestataireController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Prestataire P, IFormFile photoImg)
        {
            try
            {
                if (photoImg != null && photoImg.Length > 0)
                {
                    // Save the image file to the "wwwroot/Images" folder
                    //  var fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + Path.GetFileName(photoImg.FileName);

                    var fileName = Path.GetFileName(photoImg.FileName);
                    var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images");
                    var filePath = Path.Combine(uploadsFolder, fileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        photoImg.CopyTo(fileStream);
                    }

                    // Set the image file path in the client object
                    P.prestatairePhoto = fileName;
                }

                // Add the client to the database
                prestataireService.Add(P);

                // Redirect to the Index action method
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // If an error occurs, add the error message to ModelState and return the View with the client object
                ModelState.AddModelError("", "An error occurred while adding the client: " + ex.Message);
                return View();
            }
        }

        // GET: PrestataireController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PrestataireController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PrestataireController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PrestataireController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
