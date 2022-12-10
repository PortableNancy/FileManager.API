using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace FileManager.Domain.Model
{
    public class FileClass
    {
        public string ID { get; set; } = Guid.NewGuid().ToString();
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }

    }
}
