using System.Collections.Generic;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace TpExam.Models
{
    public class Categorie
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [NotNull]
        public string Nom { get; set; }
    }

    public class Produit
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [NotNull]
        public string Nom { get; set; }

        public string Description { get; set; }

        [NotNull]
        public decimal Prix { get; set; }

        public string UrlImage { get; set; }

        [ForeignKey(typeof(Categorie))]
        public int IdCategorie { get; set; }
    }

    public class LigneCommande
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [ForeignKey(typeof(Produit))]
        public int IdProduit { get; set; }

        public int Quantite { get; set; }
        [Ignore]
        public dynamic Produit { get; set; }
        public decimal TotalProduit { get; set; }
        [ForeignKey(typeof(Commande))]
        public int IdCommande { get; set; }
    }

    public class Commande
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [NotNull]
        public string NomClient { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<LigneCommande> LignesCommande { get; set; }
    }

}
