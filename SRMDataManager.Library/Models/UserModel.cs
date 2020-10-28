using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRMDataManager.Library.Models
{
    public class UserModel
    {
        /// <summary>
        /// The unique identifier for the individual users.
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// The First name of the user.
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// The last name of the user.
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// The Email Address of the user.
        /// </summary>
        public string EmailAddress { get; set; }
        /// <summary>
        /// The Created date and time of the user, default to UTC.
        /// </summary>
        public DateTime CreatedDate { get; set; }
    }
}
