using AutoMapper;
using Project12.Services.Base.Contracts;

namespace Project12.Services.Base
{
    public abstract class BaseService
    {
        protected readonly IMapper Mapper;
        protected readonly IUserData UserData;

        public BaseService(IUserData userData)
        {
            this.UserData = userData;
        }

        public BaseService(IMapper mapper, IUserData userData) 
            : this(userData)
        {
            this.Mapper = mapper;
        }
    }
}
