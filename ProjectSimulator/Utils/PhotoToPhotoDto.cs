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
                result.Add(new PhotoDto
                {
                    Id = photo.Id,
                    Grade = photo.Grade
                });
            }
            return result;
        }
    }
}
