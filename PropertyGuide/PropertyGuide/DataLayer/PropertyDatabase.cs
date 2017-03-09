using System;
using PropertyGuide.BusinessLayer;
using PropertyGuide.DataLayer.Contracts;

namespace PropertyGuide.DataLayer
{
    public class PropertyDatabase : AppDatabase, IPropertyDatabase
    {
        public PropertyDatabase(string path) : base(path)
        {
            //create the tables
            CreateTable<Property>();
        }        
    }
}