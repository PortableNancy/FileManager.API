using System.Net;
using FileManager.Core.DTOs;
using FileManager.Core.Interface;

namespace FileManager.Core.Services
{
    public class FileService : IFileService
    {
        private static string Rootpath = Directory.GetCurrentDirectory();

        public FileResponseDto<string> CreateFile(string path, string filename)
        {
            try
            {
                if (Directory.Exists(path))
                {

                    string filepath = Path.Combine(Rootpath, path, filename);
                    var CreatedFile = File.Create(filepath);
                    return FileResponseDto<string>.Success((int)HttpStatusCode.Created, "File has been created", CreatedFile.ToString());

                }
                else
                {
                    return FileResponseDto<string>.Fail((int)HttpStatusCode.NotFound, "Folder not found");
                }
            }
            catch (Exception ex)
            {

                return FileResponseDto<string>.Fail((int)HttpStatusCode.BadRequest, "failed to create file");
            }

        }
        public FileResponseDto<string> RenameFile (string path, string oldfilename, string newfilename)
        {
            if (Directory.Exists(path))
            {
                var oldFilepath = Path.Combine(Rootpath, path, oldfilename);
                var newFilepath = Path.Combine(Rootpath, path, newfilename);
                File.Move(oldFilepath, newFilepath);
                File.Delete(oldFilepath);
                return FileResponseDto<string>.Success((int)HttpStatusCode.Moved, $" successfully renamed"+oldfilename, newfilename);
            }
            else
            {
                return FileResponseDto<string>.Fail((int)HttpStatusCode.NotFound, $" not found"+ oldfilename);
            }
           
        }
        public FileResponseDto<string> DeleteFileByName(string path, string name)
        {
            if (File.Exists(Path.Combine(Rootpath,path,name)))
            {
                File.Delete(Path.Combine(Rootpath,path,name));
                return FileResponseDto<string>.Success((int)HttpStatusCode.NoContent,$"Successfully deleted" + name, name);
            }
            return FileResponseDto<string>.Fail((int)HttpStatusCode.NotFound, "file not found");
        }
        public IEnumerable<string> GetAllFiles(string path)
        {
           
               
            var files = Directory.GetFiles(path, "*.*",SearchOption.AllDirectories);   
            return files;
        }


    }
}
