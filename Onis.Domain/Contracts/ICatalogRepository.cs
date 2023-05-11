using Onis.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Onis.Domain.Contracts
{
    public interface ICatalogRepository :IAsyncDisposable 
    {
        IEnumerable<CatalogItem> GetItems();

    }
}
