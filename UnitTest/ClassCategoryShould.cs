using AutoMapper;
using BackEnd.Model;
using BackEnd.Profiles;
using ClassLibrary.Service;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTest
{
    public class ClassCategoryShould
    {
        //private readonly ClassCategory _classCategory;
        //private readonly Mock<Category> _categoryRepository;
        //private readonly IMapper _mapper;

        //public ClassCategoryShould()
        //{
        //    _categoryRepository = new Mock<Category>();

        //    var config = new MapperConfiguration(cfg => cfg.AddProfile<AllProfile>());
        //    _mapper = config.CreateMapper();

        //    _classCategory = new ClassCategory(
        //            _categoryRepository.Object,
        //            _mapper
        //        );
        //}

        //[Fact]
        //public async Task GetAsyncShouldReturnNullAsync()
        //{
        //    var id = Guid.NewGuid();
        //    _categoryRepository
        //          .Setup(x => x.GetByIdAsync(id))
        //          .Returns(Task.FromResult<Category>(null));

        //    var result = await _categoryService.GetByIdAsync(id);
        //    result.Should().BeNull();
        //}

        //[Fact]
        //public async Task GetAsyncShouldReturnObjectAsync()
        //{
        //    var entity = new Category()
        //    {
        //        Desc = "code",
        //        Id = Guid.NewGuid(),
        //        Name = "Name"
        //    };

        //    _categoryRepository.Setup(x => x.GetByIdAsync(entity.Id)).Returns(Task.FromResult(entity));
        //    var result = await _categoryService.GetByIdAsync(entity.Id);
        //    result.Should().NotBeNull();
        //    result.Id.Should().Be(entity.Id);


        //    _categoryRepository.Verify(mock => mock.GetByIdAsync(entity.Id), Times.Once);
        //}

        //[Fact]
        //public async Task AddCategoryShouldThrowExceptionAsync()
        //{
        //    Func<Task> act = async () => await _categoryService.AddAsync(null);
        //    await act.Should().ThrowAsync<ArgumentNullException>();
        //}

        //[Fact]
        //public async Task AddCategoryShouldBeSuccessfullyAsync()
        //{
        //    var category = new Category()
        //    {
        //        Desc = "code",
        //        Id = Guid.NewGuid(),
        //        Name = "name"
        //    };

        //    var newCategoryDto = new CreateCategoryDto()
        //    {
        //        Desc = "code",
        //        ImageUrl = "string>imgurl",
        //        Name = "name"
        //    };
        //    _categoryRepository.Setup(x => x
        //        .GetByAsync(It.IsAny<Expression<Func<Category, bool>>>(), It.IsAny<string>()))
        //        .Returns(Task.FromResult<Category>(category));

        //    _categoryRepository.Setup(x => x.AddAsync(It.IsAny<Category>())).Returns(Task.FromResult(category));

        //    var result = await _categoryService.AddAsync(newCategoryDto);

        //    result.Should().NotBeNull();

        //    _categoryRepository.Verify(mock => mock.AddAsync(It.IsAny<Category>()), Times.Once());
        //}

        ///*[Fact]
        //public async Task GetCategoryByNameShouldReturnObjectAsync()
        //{
        //    var entity = new Category()
        //    {
        //        Desc = "code",
        //        ImageUrl = "string>imgurl",
        //        Name = "name",
        //        Id = Guid.NewGuid(),
        //    };
        //    _categoryRepository.Setup(x => x.GetByIdAsync(entity.Id)).Returns(Task.FromResult(entity));
        //    var result = await _categoryService.GetByNameAsync(entity.Name);
        //    result.Should().NotBeNull();
        //    result.Name.Should().Be(entity.Name);
        //    _categoryRepository.Verify(mock => mock.GetByIdAsync(entity.Id), Times.Once);
        //}*/

        //[Fact]
        //public async Task UpdateCategoryShouldHaveUpdatedDateGreaterThanCreatedDate()
        //{

        //}
    }
}