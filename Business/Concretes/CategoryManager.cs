using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests;
using Business.Dtos.Responses;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;
        IMapper _mapper;
        public CategoryManager(ICategoryDal categoryDal, IMapper mapper)
        {
            _categoryDal = categoryDal;
            _mapper = mapper;
        }
        public async Task<CreatedCategoryResponse> Add(CreateCategoryRequest createCategoryRequest)
        {
            Category category = _mapper.Map<Category>(createCategoryRequest);

            Category createdCategory = await _categoryDal.AddAsync(category);

            CreatedCategoryResponse createdCategoryResponse = _mapper.Map<CreatedCategoryResponse>(createdCategory);
            return createdCategoryResponse;
        }

        public async Task<Paginate<CreatedCategoryResponse>> GetListAsync()
        {
            var category = await _categoryDal.GetListAsync();

			List<CreatedCategoryResponse> getList = _mapper.Map<List<CreatedCategoryResponse>>(category.Items);

			Paginate<CreatedCategoryResponse> paginate = _mapper.Map<Paginate<CreatedCategoryResponse>>(category);

			paginate.Items = getList;
			return paginate;
        }
    }
}
