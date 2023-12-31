//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RegistrationPageAsp
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserDetails
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UserDetails()
        {
            this.IdsOfRolesAndUsers = new HashSet<IdsOfRolesAndUsers>();
            this.UserNotes = new HashSet<UserNotes>();
            this.UsersDocuments = new HashSet<UsersDocuments>();
        }
    
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Dob { get; set; }
        public string Gender { get; set; }
        public string PermanentAddressLine1 { get; set; }
        public string PermanentAddressLine2 { get; set; }
        public string PermanentPostalCode { get; set; }
        public int PermanentCountryId { get; set; }
        public int PermanentStateId { get; set; }
        public string PermanentCity { get; set; }
        public string PresentAddressLine1 { get; set; }
        public string PresentAddressLine2 { get; set; }
        public string PresentPostalCode { get; set; }
        public int PresentCountryId { get; set; }
        public int PresentStateId { get; set; }
        public string PresentCity { get; set; }
        public string Subscribed { get; set; }
        public string ImageUrl { get; set; }
        public string Password { get; set; }
    
        public virtual Country Country { get; set; }
        public virtual Country Country1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IdsOfRolesAndUsers> IdsOfRolesAndUsers { get; set; }
        public virtual States States { get; set; }
        public virtual States States1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserNotes> UserNotes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UsersDocuments> UsersDocuments { get; set; }
    }
}
