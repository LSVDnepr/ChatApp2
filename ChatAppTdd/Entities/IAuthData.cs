using System;
using System.Collections.Generic;
using System.Text;

namespace ChatAppTdd.Entities
{
    public interface IAuthData
    {
        string Login { get; set; }
        string Password { get; set; }
        string UserId { get; set; }
    }
}
