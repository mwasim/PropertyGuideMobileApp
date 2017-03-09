using System;
using PropertyGuide.BusinessLayer.Contracts;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace PropertyGuide.BusinessLayer
{
    public class User : IBusinessEntity
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        //public bool IsSeller { get; set; } //TRUE = YES, False = NO (is buyer)

        //https://bitbucket.org/twincoders/sqlite-net-extensions
        [ForeignKey(typeof(UserType))]
        public int UserTypeId { get; set; }

        public DateTime DateCreated { get; set; }

        public override string ToString()
        {
            //var userType = IsSeller ? "Seller" : "Buyer";
            return $"ID: {ID}, Name: {Name}, Email: {Email}, Password: {Password}, " +
                   $"User Type: N/A, Date Created: {DateCreated}";
        }
    }
}
