using System.Net;
using FileManager.Core.DTOs;
using Microsoft.AspNetCore.Mvc;
using FileManager.Core.Interface;

namespace FileManager.API.Controllers
{
        [ApiController]
        [Route("api/[Controller]")]
    public class FileController : Controller
    {
        public readonly IFileService fileService;
        public FileController(IFileService fileService)
        {
            this.fileService = fileService;
        }

        [HttpPost("Create-file")]
        public IActionResult CreateFile(string path, string filename)
        {
            var result = fileService.CreateFile(path, filename);
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPatch("Rename-file")]
        public IActionResult RenameFile(string path, string oldfilename, string newfilename)
        {
            fileService.RenameFile(path, oldfilename, newfilename);
            return StatusCode((int)HttpStatusCode.OK);
        }

        [HttpDelete("Delete-file")]
        public IActionResult DeleteFileByName(string path, string name)
        {
            fileService.DeleteFileByName(path, name);
            return StatusCode((int)HttpStatusCode.NoContent);
        }


        [HttpGet("Get-All-files-in-a-folder")]
        public IActionResult GetFiles(string path)
        {
            var files = fileService.GetAllFiles(path);
            return Ok(files);
        }
    }
}
