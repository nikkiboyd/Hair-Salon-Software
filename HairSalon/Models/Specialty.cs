using System;
namespace HairSalon.Models
{
    public class Specialty
    {
        public int SpecialtyId { get; set; }
        public string SpecialtyType { get; set; }

        public Specialty(string specialtyType, int specialtyId = 0)
        {
            SpecialtyType = specialtyType;
            SpecialtyId = specialtyId;
        }

        public override bool Equals(System.Object otherSpecialty)
        {
            if (!(otherSpecialty is Specialty))
            {
                return false;
            }
            else
            {
                Specialty newSpecialty = (Specialty)otherSpecialty;
                bool specialtyIdEquality = (this.SpecialtyId == newSpecialty.SpecialtyId);
                bool specialtyTypeEquality = (this.SpecialtyType == newSpecialty.SpecialtyType);

                return (specialtyIdEquality && specialtyTypeEquality);
            }
        }

        public override int GetHashCode()
        {
            return this.SpecialtyType.GetHashCode();
        }

    }
}
