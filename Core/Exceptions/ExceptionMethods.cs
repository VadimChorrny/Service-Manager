using Core.Entities.UserEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Core.Exceptions
{
    public static class ExceptionMethods
    {
        public static void UserNullCheck(User user)
        {
            if (user == null)
            {
                throw new HttpException(
                    "User not found",
                    HttpStatusCode.NotFound);
            }
        }
    }
}
