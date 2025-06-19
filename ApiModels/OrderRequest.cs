using System.Collections.Generic;

namespace agros_repo.ApiModels
{
    public class OrderRequest
    {
        public required List<List<MenuItemDto>> Orders { get; set; }
    }
}
