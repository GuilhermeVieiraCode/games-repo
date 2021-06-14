using System;

namespace Games
{
    public class Game : BaseEntity
    {
        private Genre Genre { get; set; }
        private string Title { get; set; }
        private string Description { get; set; }
        private int ReleaseYear { get; set; }
        private string ProductionCompany { get; set; }
        private bool Excluded { get; set; }
        
        public Game(int id, Genre genre, string title, string description, int year, string company){
          this.Id = id;
          this.Genre = genre;
          this.Title = title;
          this.Description = description;
          this.ReleaseYear = year;
          this.ProductionCompany = company;
          this.Excluded = false;
        }

        public override string ToString(){
          string result = "";
          result += "Gênero: " + this.Genre + Environment.NewLine;
          result += "Título: " + this.Title + Environment.NewLine;
          result += "Descrição: " + this.Description + Environment.NewLine;
          result += "Ano de Lançamento: " + this.ReleaseYear + Environment.NewLine;
          result += "Produtora: " + this.ProductionCompany + Environment.NewLine;
          result += "Excluido: " + this.Excluded;
          return result;
        }

        public string getTitle(){
          return this.Title;
        }
        public int getId(){
          return this.Id;
        }
        public void Exclude(){
          this.Excluded = true;
        }

        public bool isExcluded(){
          return this.Excluded;
        }

    }
}