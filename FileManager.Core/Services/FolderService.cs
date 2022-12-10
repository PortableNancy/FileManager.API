using System.Net;
using FileManager.Core.DTOs;
using FileManager.Core.Interface;

namespace FileManager.Core.Services
{
    public class FolderService : IFolderService
    {

        private static string Rootpath = Directory.GetCurrentDirectory();   


        public FolderResponseDto<string> CreateFolder(string name, string? path)
        {
            try
            {

                if (path is null)
                {
                    var CreatedFolder = Directory.CreateDirectory(Path.Combine(Rootpath, name));
                    return FolderResponseDto<string>.Success((int)HttpStatusCode.Created, "folder created", CreatedFolder.Name);
                }

                var newfolder = Directory.CreateDirectory(Path.Combine(Rootpath, path, name));
                return FolderResponseDto<string>.Success((int)HttpStatusCode.Created, "folder created", newfolder.Name);
            }
            catch (Exception ex)
            {

                return FolderResponseDto<string>.Fail((int)HttpStatusCode.InternalServerError, "not created");
            }



        }
        public FolderResponseDto<string> RenameFolder(string Foldername, string path, string NewFoldername)
        {
            try
            {
                var oldfolder = Path.Combine(Rootpath,path,Foldername);
                var newfolder = Path.Combine(Rootpath,path,NewFoldername);

                Directory.Move(oldfolder, newfolder);
                return FolderResponseDto<string>.Success((int)HttpStatusCode.OK, "Folder successfully renamed", newfolder);
            }
            catch(Exception ex)
            {
                return FolderResponseDto<string>.Fail((int)HttpStatusCode.InternalServerError, ex.Message);
            }

        }
        public IEnumerable<string> GetFolder(string path)
        {
            
               
                var directories = Directory.GetDirectories(path);
                return directories;
           
        }
           
           
        public void CreateSubfolder(string parentfolder, string path,string childfolder)
        {
            try
            {

               
                if (path is null)
                {
                    var Parentdirectory = Directory.CreateDirectory(Path.Combine(Rootpath, path, parentfolder));

                    var Childdirectory = Path.Combine(Parentdirectory.FullName, childfolder);
                    Directory.CreateDirectory(Childdirectory);
                }
                else
                {
                    var parent = Path.Combine(Rootpath, path, parentfolder);
                    var child = Directory.CreateDirectory(Path.Combine(parent, childfolder));
                }


            
            }
            catch (Exception ex)
            {
               
                
            }
        }
        public void DeleteFolder(string path, string name)
        {
            var dir = Path.Combine(Rootpath,path, name);
            if (Directory.Exists(dir))
            {
                Directory.Delete(dir, true);
            }

        }




    }
}
