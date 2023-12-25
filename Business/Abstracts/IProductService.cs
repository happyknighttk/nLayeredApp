using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concretes;
using Core.DataAccess.Paging;
using Business.Dtos.Responses;
using Business.Dtos.Requests;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace Business.Abstracts
{
	public interface IProductService
	{
		Task<Paginate<GetListedProductResponse>> GetListAsync();
		Task<CreatedProductResponse> Add(CreateProductRequest createProductRequest);
		Task<UpdatedProductResponse> Update(UpdateProductRequest updateProductRequest);
		Task<DeletedProductResponse> Delete(DeleteProductRequest deleteProductRequest);
		Task<GetProductByIdResponse> GetById(GetProductByIdRequest getProductByIdRequest);
	}
}
