using System;
using System.Collections.Generic;
using System.Text;
//using SQLite.Net.Attributes;
using SQLite;

namespace ListaTeste
{
    public class ListaBD
    {
        [PrimaryKey, AutoIncrement, Column("IdLista")]
        public int IdLista { get; set; }        
        [MaxLength(50)]        
        public string NomeLista { get; set; }
     
        public override string ToString()
        {

            return string.Format("{0} {1}", IdLista, NomeLista);
        }
      

    }
}
