using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcMusicStore.Models
{
    [Bind(Exclude = "AlbumId")]  //Bind – Lists fields to exclude or include when binding parameter or form values to model properties
    public class Album
    {
        [ScaffoldColumn(false)]  //ScaffoldColumn – Allows hiding fields from editor forms
        public int AlbumId { get; set; }

        [DisplayName("Genre")]  //DisplayName – Defines the text we want used on form fields and validation messages
        public int GenreId { get; set; }

        [DisplayName("Artist")]
        public int ArtistId { get; set; }

        [Required(ErrorMessage = "An Album Title is required")] //Required – Indicates that the property is a required field
        [StringLength(160)]     //StringLength – Defines a maximum length for a string field
        public string Title { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, 100.00,    //Range – Gives a maximum and minimum value for a numeric field
            ErrorMessage = "Price must be between 0.01 and 100.00")]
        public decimal Price { get; set; }

        [DisplayName("Album Art URL")]
        [StringLength(1024)]
        public string AlbumArtUrl { get; set; }

        public virtual Genre Genre { get; set; }
        public virtual Artist Artist { get; set; }//While we’re there, we’ve also changed the Genre and Artist to virtual properties. This allows Entity Framework to lazy-load them as necessary.
    }
}