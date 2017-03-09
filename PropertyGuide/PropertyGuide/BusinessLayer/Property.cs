using System;
using PropertyGuide.BusinessLayer.Contracts;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace PropertyGuide.BusinessLayer
{
    /// <summary>
    /// Represents a property
    /// </summary>
    public class Property : IBusinessEntity
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public bool Sold { get; set; }

        public DateTime DateAdded { get; set; }
        public DateTime? DateModified { get; set; }

        //https://bitbucket.org/twincoders/sqlite-net-extensions
        [ForeignKey(typeof(User))]
        public int SellerId { get; set; }

        [ForeignKey(typeof(User))]
        public int? BuyerId { get; set; }

        public override string ToString()
        {
            var propertySold = Sold ? "Yes" : "No";
            return $"ID: {ID}, Name: {Name}, Description: {Description}, Sold: {propertySold}, " +
                   $"DateCreated: {DateAdded}, SellerId: {SellerId}";
        }
    }
}
