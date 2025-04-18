﻿using Services.DTO;

namespace Presentation.Contracts.Source
{
    public class CreateSource
    {
        public string? Name { get; set; }
        public string? Url { get; set; }
        public SourceType? SourceType { get; set; }
        internal SourceDTO MapToDTO()
        {
            return new SourceDTO
            {
                Name = Name,
                Url = Url,
                SourceType = (int)SourceType
            };
        }
    }
}