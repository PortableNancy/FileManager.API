using System.Net;
using FileManager.Core.DTOs;
using Microsoft.AspNetCore.Mvc;
using FileManager.Core.Interface;

namespace FileManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FolderController : Controller
    {
        public readonly IFolderService folderService;
        public FolderController(IFolderService folder)
        {
            folderService = folder;
                
        }
        [HttpPost("Create-folder")]
        public IActionResult CreateFolder(string name, string path)
        {
            var result = folderService.CreateFolder(name, path);
            return StatusCode((int)HttpStatusCode.Created, result); 
        }
        [HttpPost("RenameFolder")]
        public IActionResult RenameFolder(string Foldername,string path, string newfoldername)
        {
             folderService.RenameFolder(Foldername,path, newfoldername);
            return StatusCode((int) HttpStatusCode.OK);

        }
        [HttpPost("Created-subfolder")]
        public IActionResult CreateSubfolders(string folderA, string path, string folderB)
        {
             folderService.CreateSubfolder(folderA, path, folderB);
            return StatusCode((int) HttpStatusCode.OK);
        }

        [HttpDelete]
        public IActionResult DeleteFolder(string path, string name)
        {
            folderService.DeleteFolder(path, name);
            return StatusCode((int) HttpStatusCode.OK);
        }
        [HttpGet ("Get-folder")]
        public IActionResult GetFolder(string Foldername, string path)
        {
            var folder = folderService.GetFolder(Foldername, path);
            return StatusCode((int)HttpStatusCode.Found);
        }
    }
}
