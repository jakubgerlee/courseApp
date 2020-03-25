using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Register.Business.Layer.Dto;
using Register.Business.Layer.Mappers;
using Register.Business.Layer.Service;
using Register.Data.Layer.Models;
using Register.Data.Layer.Repositories;

namespace Register.Business.Layer.Test.ServiceTests
{
    [TestClass]
    public class CourseDayServiceTests
    {
       
      [TestMethod]
            public void CheckIfMethodGivingPoperHomeworkDto_()
            {
                //Arrange
                var courseDay = new CourseDay();
                var courseDayDto = new CourseDayDto();
                var CourseDayRepoMock = new Mock<ICourseDayRepo>();
                var entityToDtoMapper = new Mock<IEntityToDtoMapper>();

                CourseDayRepoMock.Setup(x => x.GetCourseDayFromD(It.IsAny<int>(), It.IsAny<int>())).Returns(courseDay);
                entityToDtoMapper.Setup(x => x.CourseDayModelToDto(courseDay)).Returns(courseDayDto); 
                var courseDayService = new CourseDayService(CourseDayRepoMock.Object, entityToDtoMapper.Object); 

                //Act
                var result = courseDayService.GetCourseDayByIds(1, 1); 

                //Assert

                Assert.AreSame(result, courseDayDto); 
            }
    }
}
