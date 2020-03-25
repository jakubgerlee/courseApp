using Register.Business.Layer.Dto;
using Register.Data.Layer.Models;

namespace Register.Business.Layer.Mappers
{
    public interface IDtoToEntityMapper
    {
        Homework HomeworkDtoToModelEntity(HomeworkDto homeworkDto);
    }
}