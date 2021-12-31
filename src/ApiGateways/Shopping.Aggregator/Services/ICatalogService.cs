﻿using Shopping.Aggregator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Aggregator.Services
{
    public interface ICatalogService
    {
        Task<IEnumerable<CatalogModel>> GetCatalogs();
        Task<IEnumerable<CatalogModel>> GetCatalogByCategory(string category);
        Task<CatalogModel> GetCatalog(string id);
    }
}
