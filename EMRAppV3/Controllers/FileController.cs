using EMRAppV3.Data;
using EMRAppV3.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EMRAppV3.Controllers
{
    public class FileController : Controller
    {
        private readonly ApplicationDbContext context;

        public FileController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [Authorize]
        public async Task<IActionResult> UploadIndex()
        {
            var fileuploadViewModel = await LoadAllFiles();
            ViewBag.Message = TempData["Message"];
            return View(fileuploadViewModel);
        }
       
        
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> UploadToDatabase(List<IFormFile> files, string description)
        {
            foreach (var file in files)
            {
                var fileName = Path.GetFileNameWithoutExtension(file.FileName);
                var extension = Path.GetExtension(file.FileName);
                var fileModel = new FileOnDatabaseModel
                {
                    CreatedOn = DateTime.UtcNow,
                    FileType = file.ContentType,
                    Extension = extension,
                    Name = fileName,
                    Description = description,
                    UserId = User.FindFirstValue(ClaimTypes.NameIdentifier)
                    
                };
                using (var dataStream = new MemoryStream())
                {
                    await file.CopyToAsync(dataStream);
                    fileModel.Data = dataStream.ToArray();
                }
                context.FileOnDatabaseModel.Add(fileModel);
                context.SaveChanges();
            }
            TempData["Message"] = "File successfully uploaded to Database";
            return RedirectToAction("UploadIndex");
        }

        [Authorize]
        private async Task<FileUploadViewModel> LoadAllFiles()
        {
            string UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var viewModel = new FileUploadViewModel();
            viewModel.FilesOnDatabase =  context.FileOnDatabaseModel.Where(f => f.UserId == UserId).ToList();
            return viewModel;
        }

        public async Task<IActionResult> DownloadFileFromDatabase(int id)
        {

            var file = await context.FileOnDatabaseModel.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (file == null) return null;
            return File(file.Data, file.FileType, file.Name + file.Extension);
        }
       
        public async Task<IActionResult> DeleteFileFromDatabase(int id)
        {

            var file = await context.FileOnDatabaseModel.Where(x => x.Id == id).FirstOrDefaultAsync();
            context.FileOnDatabaseModel.Remove(file);
            context.SaveChanges();
            TempData["Message"] = $"Removed {file.Name + file.Extension} successfully from Database.";
            return RedirectToAction("UploadIndex");
        }


       
    }
}
