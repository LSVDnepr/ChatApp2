using System;
using System.Collections.Generic;
using System.Text;

namespace ChatAppTdd.Entities
{
    public interface IUserData
    {

       string UserID { get; set; }
       string SessionID { get; set; }
       string Title { get; set; }
      

    }
}
