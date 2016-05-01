using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Domain.Entities 
{
    public enum Sex { Female, Male};

    public class Character
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [ScaffoldColumn(false)]
        public string PicturePath { get; set; }

        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        [Column("FirstName")]
        public string Name { get; set; }

        [Column("Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public decimal Cost { get; set; }

        public LifeStatus LifeStatus { get; set; }

        public Sex Sex { get; set; }


    }
}
