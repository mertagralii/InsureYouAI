using InsureYouAI.Context;
using InsureYouAI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace InsureYouAI.Controllers
{
    public class TrailerVideoController : Controller
    {
        private readonly InsureContext _context;

        public TrailerVideoController(InsureContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult TrailerVideoList()
        {
            var TrailerVideo = _context.TrailerVideos.ToList();
            return View(TrailerVideo);
        }

        [HttpGet]
        public IActionResult CreateTrailerVideo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateTrailerVideo(TrailerVideo TrailerVideo)
        {
            _context.TrailerVideos.Add(TrailerVideo);
            _context.SaveChanges();
            return RedirectToAction("TrailerVideoList");
        }

        [HttpGet]
        public IActionResult UpdateTrailerVideo(Guid id)
        {
            var TrailerVideo = _context.TrailerVideos.Find(id);
            return View(TrailerVideo);
        }

        [HttpPost]
        public IActionResult UpdateTrailerVideo(TrailerVideo TrailerVideo)
        {
            _context.TrailerVideos.Update(TrailerVideo);
            _context.SaveChanges();
            return RedirectToAction("TrailerVideoList");
        }

        [HttpGet]
        public IActionResult DeleteTrailerVideo(Guid id)
        {
            var TrailerVideo = _context.TrailerVideos.Find(id);
            if (TrailerVideo != null)
            {
                _context.TrailerVideos.Remove(TrailerVideo);
                _context.SaveChanges();
            }
            return RedirectToAction("TrailerVideoList");
        }
    }
}
