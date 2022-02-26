using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreEticaret.Services.Abstract
{
    public interface IUserService
    {
        string GetUserId();
        bool IsAuthenticated();
    }
}
