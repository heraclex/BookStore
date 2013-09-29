using System.Collections.Generic;

namespace WebApp.Models
{
    public class DemoLabModel
    {
        public List<int> Ids { get; set; }

        public List<string> Names { get; set; }

        public List<PersonModel> Persons { get; set; }

        public string Description { get; set; }
    }

    /// <summary>
    /// The person.
    /// </summary>
    public class PersonModel
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is selected.
        /// </summary>
        public bool IsSelected { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is deleted.
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}