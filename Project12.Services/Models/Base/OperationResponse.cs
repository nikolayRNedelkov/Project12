using Project12.Repositories.Base.Models;
using Project12.Utilities.Mapper;

namespace Project12.Services.Models.Base
{
    public class OperationResponse : IMapFrom<SaveResult>
    {
        public bool IsSuccessful { get; set; }

        public string ErrorMessage { get; set; }
    }
}
