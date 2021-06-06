﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhotoAlbum.BLL.Interfaces
{
    public interface IService<T> where T : class
    {
        IEnumerable<T> GetAll();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T dto);
        Task UpdateAsync(T dto);
        Task DeleteByIdAsync(int id);
    }
}
