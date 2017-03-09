using System;
using System.Collections.Generic;
using System.Text;
using PropertyGuide.BusinessLayer.Contracts;
using SQLite;

namespace PropertyGuide.BusinessLayer
{
    public class UserType : IBusinessEntity
    {
        [PrimaryKey]
        public int ID { get; set; }

        public string Name { get; set; }
    }
}
