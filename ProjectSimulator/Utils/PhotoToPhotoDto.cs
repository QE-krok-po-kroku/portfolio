using System.Collections.Generic;
using ProjectSimulator.Models;

namespace ProjectSimulator.Utils
{
    public class PhotoToPhotoDto
    {
        public static IList<PhotoDto> Convert(IList<Photo> photos)
        {
            IList<PhotoDto> result  = new List<PhotoDto>();
            foreach (var photo in photos)
            {
                if (photo.Grade.ToLower() != "very_bad")                
                { 
                    result.Add(new PhotoDto
                {
                    Id = photo.Id,
                    Title = photo.Title,
                    Grade = photo.Grade,
                    Type = photo.Type,
                    Year = photo.Year   

                }
                
                );
                }
            }
            return result;
        }
    }
}
