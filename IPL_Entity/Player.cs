//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IPL_Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Player
    {
        public int PlayerId { get; set; }
        public Nullable<int> TeamId { get; set; }
        public string PlayerName { get; set; }
        public Nullable<int> Age { get; set; }
        public Nullable<int> SpecialityId { get; set; }
        public string Role { get; set; }
        public string BattingStyle { get; set; }
        public string BowlingStyle { get; set; }
        public string BirthPlace { get; set; }
        public string TeamName { get; set; }
    
        public virtual Speciality Speciality { get; set; }
        public virtual Team Team { get; set; }
    }
}
