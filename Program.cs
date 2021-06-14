using System;

namespace Games
{
    class Program
    {
        static GameRepository repository = new GameRepository();
        static void Main(string[] args)
        {
          string option = userOption();

          while(option.ToUpper() != "X")
          {
          switch (option)
          {
            case "1":
              ListGames();
              break;
            case "2":
              InsertGame();
              break;  
            case "3":
              UpdateGame();
              break;  
            case "4":
              RemoveGame();
              break;
            case "5":
              ViewGame();
              break;    
            case "C":
              Console.Clear();
              break; 
            default:
              throw new ArgumentOutOfRangeException();
            }

            option = userOption();
          }    
        }  
        
        private static void ListGames(){
          Console.WriteLine("Listagem de games");

          var list = repository.List();

          if(list.Count == 0){
            Console.WriteLine("Nenhum game cadastrado");
          }

          foreach(var game in list){
            Console.WriteLine("#ID {0}: - {1} - {2}", game.getId(), game.getTitle(), (game.isExcluded() ? "*Excluído*" : ""));
          }
        }

        private static void InsertGame(){
          Console.WriteLine("Inserir novo game");

          foreach(int i in Enum.GetValues(typeof(Genre))){
            Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genre), i));
          }
          Console.Write("Digite o gênero dentre as opções acima: ");
          int genreInput = int.Parse(Console.ReadLine());
          
          Console.Write("Digite o título do game: ");
          string titleInput = Console.ReadLine();

          Console.Write("Digite a descrição do game: ");
          string descriptionInput = Console.ReadLine();

          Console.Write("Digite o ano de lançamento: ");
          int yearInput = int.Parse(Console.ReadLine());

          Console.Write("Digite o nome da produtora: ");
          string companyInput = Console.ReadLine();

          Game game = new Game(id: repository.NextId(),
                               genre: (Genre)genreInput,
                               title: titleInput,
                               description: descriptionInput,
                               year: yearInput,
                               company: companyInput);

          repository.Insert(game);                     
        }

        private static void UpdateGame(){
          Console.Write("Digite o id do game: ");
          int gameIndex = int.Parse(Console.ReadLine());

          foreach(int i in Enum.GetValues(typeof(Genre))){
            Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genre), i));
          }
          Console.Write("Digite o gênero dentre as opções acima: ");
          int genreInput = int.Parse(Console.ReadLine());
          
          Console.Write("Digite o título do game: ");
          string titleInput = Console.ReadLine();

          Console.Write("Digite a descrição do game: ");
          string descriptionInput = Console.ReadLine();

          Console.Write("Digite o ano de lançamento: ");
          int yearInput = int.Parse(Console.ReadLine());

          Console.Write("Digite o nome da produtora: ");
          string companyInput = Console.ReadLine();

          Game game = new Game(id: gameIndex,
                               genre: (Genre)genreInput,
                               title: titleInput,
                               description: descriptionInput,
                               year: yearInput,
                               company: companyInput);

          repository.Update(gameIndex, game);                   
        }
        private static void RemoveGame(){
          Console.Write("Digite o id do game: ");
          int gameIndex = int.Parse(Console.ReadLine());

          Console.Write("Tem certeza que deseja excluir o game de id {0}?[S/N] ", gameIndex);
          string option = Console.ReadLine();
          if(option.ToUpper() == "S"){
            repository.Remove(gameIndex);
          }
          else if(option.ToUpper() == "N"){
            Console.Write("Exclusão cancelada com sucesso");
          }
          else{
            Console.Write("Opção inválida");
          }

          Console.WriteLine();

        }

        private static void ViewGame(){
          Console.Write("Digite o id do game: ");
          int gameIndex = int.Parse(Console.ReadLine());

          var game = repository.ReturnById(gameIndex);
          Console.WriteLine(game);
        }

        private static string userOption()
        {
          Console.WriteLine();
          Console.WriteLine("DIO Games a seu dispor!");
          Console.WriteLine("Informe a opção desejada:");
          Console.WriteLine("1- Listar games");
          Console.WriteLine("2- Inserir novo game");
          Console.WriteLine("3- Atualizar game");
          Console.WriteLine("4- Excluir game");
          Console.WriteLine("5- Visualizar game");
          Console.WriteLine("C- Limpar Tela");
          Console.WriteLine("X- Sair");
          Console.WriteLine();

          string option = Console.ReadLine();
          return option;
        }
    }
}


