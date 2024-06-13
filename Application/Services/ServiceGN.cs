using Application.DTOs;
using Application.Intrfraces;
using AutoMapper;
using Domain.Entites;
using Domain.IRepository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ServiceGN<T> : IGenericServices<T> where T : class
    {

        private readonly IBaseRepository<T> _baserepository;
        private readonly IMapper _mapper;

        public ServiceGN(IBaseRepository<T> baserepository, IMapper mapper)    {

            _baserepository=baserepository;
            _mapper=mapper;

                             }
        public  async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includes)
        {
            var entites =  await _baserepository.GetAllAsync(includes) ;
            return _mapper.Map<IEnumerable<T>>(entites);
            
        }
        

        public async Task<T?> GetAsync(int id, params Expression<Func<T, object>>[] includes)
        {
            var entity = await  _baserepository.GetAsync(id, includes);

            return _mapper.Map<T>(entity);

        }

        public async Task<bool> PostAsync(T entity)
        {
           return   await _baserepository.PostAsync(entity);
           
        }

        public async Task<T?> PutAsync(int id, T entity)
        {
           
            return await _baserepository.PutAsync(id, entity);
        }

        public async Task<bool> RemoveAsync(int id)
        {
           return   await _baserepository.RemoveAsync(id);
             
        }
}
}
