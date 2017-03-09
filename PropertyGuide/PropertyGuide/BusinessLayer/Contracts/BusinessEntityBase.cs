using SQLite;

namespace PropertyGuide.BusinessLayer.Contracts
{
    /// <summary>
    /// Business Entity Base class, provides the ID prperty
    /// </summary>
    public class BusinessEntityBase : IBusinessEntity
    {

        /// <summary>
        /// Gets or sets the database ID
        /// </summary>
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
    }
}
