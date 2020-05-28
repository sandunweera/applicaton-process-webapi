using System.Text.Json.Serialization;

namespace Hahn.ApplicationProcess.May2020.Data.Models
{
    /// <summary>
    ///     Model for the applicant.
    /// </summary>
    public class Applicant
    {
        /// <summary>
        ///     The applicant's Id.
        /// </summary>
        [JsonIgnore]
        public int Id { get; set; }

        /// <summary>
        ///     The applicant's name.
        /// </summary>
        /// <example>Sandun</example>
        public string Name { get; set; }

        /// <summary>
        ///     The applicant's family name.
        /// </summary>
        /// <example>Weerasinghe</example>
        public string FamilyName { get; set; }

        /// <summary>
        ///     The applicant's address.
        /// </summary>
        /// <example>440, Batagama South, Kandana</example>
        public string Address { get; set; }

        /// <summary>
        ///     The applicant's country of origin.
        /// </summary>
        /// <example>Sri Lanka</example>
        public string CountryOfOrigin { get; set; }

        /// <summary>
        ///     The applicant's email address.
        /// </summary>
        /// <example>sandunweera@gmail.com</example>
        public string EmailAddress { get; set; }

        /// <summary>
        ///     The applicant's age.
        /// </summary>
        /// <example>36</example>
        public int Age { get; set; }

        /// <summary>
        ///     Whether the applicant is hired or not.
        /// </summary>
        /// <example>true</example>
        public bool Hired { get; set; }
    }
}