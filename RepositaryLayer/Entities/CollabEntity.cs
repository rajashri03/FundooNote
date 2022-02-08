﻿namespace RepositaryLayer.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;
    public class CollabEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long CollabId { get; set; }
        public string CollabEmail { get; set; }
        [ForeignKey("Users")]
        public long Userid { get; set; }
        [ForeignKey("Notes")]
        public long Noteid { get; set; }
        public virtual UserEntity user { get; set; }
        public virtual NoteEntity notes { get; set; }
    }
}
