using FileManager.Core.DTOs;

namespace FileManager.Core.Interface
{
    public interface IFileService
    {
        FileResponseDto<string> CreateFile(string path, string filename);
        FileResponseDto<string> RenameFile(string path, string oldfilename, string newfilename);
        FileResponseDto<string> DeleteFileByName(string path, string name);
        IEnumerable<string> GetAllFiles(string path);
    }
}