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
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;
        private IMapper _mapper;

        public ProductManager(IProductDal productDal, IMapper mapper)
        {
            _productDal = productDal;
            _mapper = mapper;
        }

        public async Task<CreatedProductResponse> Add(CreateProductRequest createProductRequest)
        {
            Product product = _mapper.Map<Product>(createProductRequest);

            Product createdProduct = await _productDal.AddAsync(product);

            CreatedProductResponse createdProductResponse = _mapper.Map<CreatedProductResponse>(createdProduct);

            return createdProductResponse;

        }
        public async Task<Paginate<GetListedProductResponse>> GetListAsync()
        {
            var data = await _productDal.GetListAsync(
                include: p => p.Include(p => p.Category)
                );

            var result = _mapper.Map<Paginate<GetListedProductResponse>>(data);

            return result;
        }
        public async Task<DeletedProductResponse> Delete(DeleteProductRequest deleteProductRequest)
        {
            Product product = await _productDal.GetAsync(p => p.Id == deleteProductRequest.ProductId);
            await _productDal.DeleteAsync(product);

            return _mapper.Map<DeletedProductResponse>(product);
        }

        public async Task<UpdatedProductResponse> Update(UpdateProductRequest updateProductRequest)
        {
            Product product = await _productDal.GetAsync(p => p.Id == updateProductRequest.ProductId);
            _mapper.Map(updateProductRequest, product);
            product = await _productDal.UpdateAsync(product);
        
            return _mapper.Map<UpdatedProductResponse>(product);
        }

        public async Task<GetProductByIdResponse> GetById(GetProductByIdRequest getProductByIdRequest)
        {
            Product product = await _productDal.GetAsync(p => p.Id == getProductByIdRequest.Id, include: p => p.Include(p => p.Category));

            return _mapper.Map<GetProductByIdResponse>(product);

            
        }
    }
}
