using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using ProjectSimulator.Models;
using ProjectSimulator.Utils;

namespace ProjectSimulatorTests
{
    [TestFixture]
    public class PhotoToPhotoDtoConverterTest
    {
        [Test]
        public void ShouldReturnEmptyListWhenEmptyListPassed()
        {
            IList<Photo> photos = new List<Photo>();

            IList<PhotoDto> dtos = PhotoToPhotoDto.Convert(photos);

            Assert.That(dtos, Is.Empty);
        }

        [Test]
        public void ShouldConvertPhotoIntoPhotoDto()
        {
            IList<Photo> photos = new List<Photo>();
            photos.Add(TestDataProvider.FirstPhoto());

            IList<PhotoDto> dtos = PhotoToPhotoDto.Convert(photos);

            Assert.That(dtos.Count, Is.EqualTo(1));
            PhotoDto dto = dtos.First();
            Assert.That(dto.Id, Is.EqualTo("12345"));
            Assert.That(dto.Grade, Is.EqualTo("good"));
        }
    }
}
