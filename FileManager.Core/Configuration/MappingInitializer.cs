using System;
using AutoMapper;
using System.Linq;
using System.Text;
using FileManager.Core.DTOs;
using System.Threading.Tasks;
using FileManager.Core.Services;
using System.Collections.Generic;

namespace FileManager.Core.Configuration
{
    public class MappingInitializer : Profile
    {
        public MappingInitializer()
        {
            CreateMap<FolderService, FolderDto>().ReverseMap();
        }
    }
}
