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
    public class HomeworkServiceTests
    {
        [TestMethod]
        public void CheckIfMethodGivingPoperHomeworkDto_()
        {
            //Arrange
            var homework = new Homework();
            var homeworkDto = new HomeworkDto();
            var homeworkRepoMock = new Mock<IHomeworkRepo>();
            var entityToDtoMapper = new Mock<IEntityToDtoMapper>();

            homeworkRepoMock.Setup(x => x.GetHomeworkByIds(It.IsAny<int>(), It.IsAny<int>())).Returns(homework); //Dla jakiegokolwiek id kursi i studenta zwroc mi homework       
            entityToDtoMapper.Setup(x => x.HomeworkModelToDto(homework)).Returns(homeworkDto);     //jezeli dostaniesz homework, zwroc mi homeworkDto

            var homeworkService = new HomeworkService(homeworkRepoMock.Object, entityToDtoMapper.Object); //tworze obiekt homeworkService, który bede zaraz testował
            
            //Act
            var result = homeworkService.GetHomeworkByIds(1, 1); //dla obojetnie jakich id 
            
            //Assert
            
            Assert.AreSame(result, homeworkDto); //Sprawdz, czy zwrocil mi HomeworkDTO
        }
    }
}
