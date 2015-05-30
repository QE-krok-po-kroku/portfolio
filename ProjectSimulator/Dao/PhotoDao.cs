using System.Collections.Generic;
using ProjectSimulator.Models;

namespace ProjectSimulator.Dao
{
    class PhotoDao
    {
        readonly ApplicationDbContext _db = new ApplicationDbContext();

        public IEnumerable<Photo> GetPhotos()
        {
            return _db.Photos;
        }

        public void AddPhoto(Photo photo)
        {
            _db.Photos.Add(photo);
            _db.SaveChanges();
        }

        public void ResetDatabase()
        {
            _db.Database.Initialize(true);
        }
    }
}
