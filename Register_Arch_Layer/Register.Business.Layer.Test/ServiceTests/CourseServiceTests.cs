using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Register.Business.Layer.Dto;
using Register.Business.Layer.Mappers;
using Register.Business.Layer.Service;
using Register.Data.Layer.Interfaces;
using Register.Data.Layer.Models;
using Register.Data.Layer.Repositories;

namespace Register.Business.Layer.Test.ServiceTests
{
    [TestClass]
    public class CourseServiceTests
    {
        [TestMethod]
            public void _()
            {
                //Arrange
                var course = new Course();
                var courseDto = new CourseDto();
                var courseRepoMock = new Mock<ICourseRepo>();
                var entityToDtoMapper = new Mock<IEntityToDtoMapper>();

                courseRepoMock.Setup(x => x.GetCourse(It.IsAny<int>())).Returns(course);
                entityToDtoMapper.Setup(x => x.CourseModelToDto(course)).Returns(courseDto);
                var courseService = new CourseService(courseRepoMock.Object, entityToDtoMapper.Object);

                //Act
                var result = courseService.GetCourseById(1);

                //Assert

                Assert.AreSame(result, courseDto);
            }
        
    }
}
