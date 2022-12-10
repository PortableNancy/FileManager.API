using FileManager.Core.DTOs;

namespace FileManager.Core.Interface
{
    public interface IFolderService
    {
        FolderResponseDto<string> CreateFolder(string name, string? path);
        void CreateSubfolder(string parentfolder, string path, string childfolder);
        void DeleteFolder(string path, string name);
        IEnumerable<string> GetFolder(string path);
        FolderResponseDto<string> RenameFolder(string Foldername, string path, string NewFoldername);
       
    }
}