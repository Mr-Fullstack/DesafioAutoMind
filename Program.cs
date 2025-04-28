
using System;

namespace automind.selecao.estagio {
  class Program
  {
  
    static List<Usuario> usuarioLista = new List<Usuario>();
    static void Main()
    {
      Console.WriteLine("Seja bem vindo ao sistema de Cadastro de usuario da AutoMind.\n");
      MenuPrincipal();
    }

    static string CadastrarNovoUsuario(string usuarioNome, string usuarioEmail, string usuarioIdade )
    {
      bool ehNumeroValido = int.TryParse(usuarioIdade, out int resultado);
      if (ehNumeroValido)
      {
        Usuario usuario = new Usuario { Nome = usuarioNome, Email = usuarioEmail, Idade = resultado };
        usuarioLista.Add(usuario);
        return "Pessoa cadastrada no sistema com sucesso!";
      }
      else return $"Não foi possivel cadastrar pessoa no sistema. A idade '{usuarioIdade}' não é uma idade válida.";
    }
    static void MenuPrincipal()
    {
      Console.WriteLine(
        "Selecione as seguintes opções para continuar:\n" +
        "Digite 1 - para cadastrar novo usuario. \n" +
        "Digite 2 - para deletar usuario. \n" +
        "Digite 3 - para encontrar usuario. \n" +
        "Digite 0 - para sair do programa. \n"
       );
      string opcaoSelecionada = Console.ReadLine();
      if (opcaoSelecionada != null)
      {
        switch (opcaoSelecionada)
        {
          case "1":
            Cadastrando();
            break;
          case "2":
            Deletando();
            break;
          case "3":
            Encontrando();
            break;
          case "0":
            Environment.Exit(0);
            break;
          default:
            Console.WriteLine("Opção inválida.\n");
            MenuPrincipal();
            break;
        }
      }
    }
    static void Cadastrando()
    {
      Console.WriteLine("=============================================================================== \n");
      Console.WriteLine("Forneça algumas informações necessária.");
      Console.WriteLine("Nome da pessoa:");
      string nome = Console.ReadLine();
      Console.WriteLine("Email da pessoa:");
      string email = Console.ReadLine();
      Console.WriteLine("Idade da pessoa:");
      string idade = Console.ReadLine();
      Console.WriteLine("=============================================================================== \n");
      Console.WriteLine("Você quer continuar com essas informações?");
      Console.WriteLine( "\n");
      Console.WriteLine("Nome: " + nome + "\n" + "Email: " + email + "\n" + "Idade: " + idade);
      Console.WriteLine("\n");
      Console.WriteLine("Digite 1 - para CONTINUAR. \nDigite 2 - para CORRIGIR. \nDigite 3 - Para voltar ao menu principal.");
      string confirmacao = Console.ReadLine();
      if (confirmacao != null)
      {
        switch (confirmacao)
        {
          case "1":
            string resultado = CadastrarNovoUsuario(nome, email, idade);
            Console.WriteLine("=============================================================================== \n");
            Console.WriteLine("Resultado: " + resultado + "\n");
            Console.WriteLine("=============================================================================== \n");
            MenuPrincipal();
            break;
          case "2":
          default:
            Console.WriteLine("Opção inválida.\n");
            Cadastrando();
            break;
        }
      }
    }
    static void UsuarioNaoPodeSerEncontrado()
    {
      Console.WriteLine("Resultado: pessoa não existe no sistema.\n");
      MenuEncontrando();
    }
    static void MenuEncontrando()
    {
      string titulo = "Digite 1 - para buscar usuário. \nDigite 2 - Para voltar ao menu principal. \n";
      Console.WriteLine(titulo);
      string confirmacao = Console.ReadLine();
      if (confirmacao != null)
      {
        switch (confirmacao)
        {
          case "1":
            Encontrando();
            break;
          case "2":
            MenuPrincipal();
            break;
         default:
            Console.WriteLine("Opção inválida.\n");
            MenuEncontrando();
            break;
        }
      }
    }
    static void Encontrando()
    {
      Console.WriteLine("Digite nome da pessoa a ser encontrado(a):");
      string nomeUsuario =  Console.ReadLine();
      if (nomeUsuario == null) UsuarioNaoPodeSerEncontrado();
      string resultado = BuscarUsuarioNaLista(nomeUsuario);
      if (resultado == "Pessoa não existe no sistema.") UsuarioNaoPodeSerEncontrado();
      else
      {
        Console.WriteLine("==================================================================\n");
        Console.WriteLine(resultado + "\n");
        Console.WriteLine("==================================================================\n");
        MenuEncontrando();
      }
    }
    static string BuscarUsuarioNaLista(string nome)
    {
      Usuario usuarioEncontrado = usuarioLista.Find(usuario => usuario.Nome == nome);
      if(usuarioEncontrado == null) return "Pessoa não existe no sistema.";
      return "Dados de "+ nome + " foi encontrado no sistema: \n" + usuarioEncontrado.ToString();
    }
    static void Deletando()
    {
      Console.WriteLine("Digite nome da pessoa a ser deletado(a) do sistema:");
      string nomeUsuario = Console.ReadLine();
      if (nomeUsuario == null) UsuarioNaoPodeSerDeletado();
      string resultado = DeletarUsuarioNaLista(nomeUsuario);
      if (resultado == "Não foi possível deletar dados. Pessoa não existe no sistema.") UsuarioNaoPodeSerDeletado();
      else
      {
        Console.WriteLine("==================================================================\n");
        Console.WriteLine(resultado + "\n");
        Console.WriteLine("==================================================================\n");
        MenuDeletando();
      }
    }
    static void UsuarioNaoPodeSerDeletado()
    {
      Console.WriteLine("Resultado: pessoa não existe no sistema.\n");
      MenuDeletando();
    }
    static void MenuDeletando()
    {
      string titulo = "Digite 1 - para deletar usuário. \nDigite 2 - Para voltar ao menu principal. \n";
      Console.WriteLine(titulo);
      string confirmacao = Console.ReadLine();
      if (confirmacao != null)
      {
        switch (confirmacao)
        {
          case "1":
            Deletando();
            break;
          case "2":
            MenuPrincipal();
            break;
          default:
            Console.WriteLine("Opção inválida.\n");
            MenuDeletando();
            break;
        }
      }
    }
    static string DeletarUsuarioNaLista(string nome)
    {
      string mensagemErro = "Não foi possível deletar dados. Pessoa não existe no sistema.";
      Usuario usuarioEncontrado = usuarioLista.Find(usuario => usuario.Nome == nome);
      if(usuarioEncontrado == null) return mensagemErro;
      Console.WriteLine("Digite 1 - para CONTINUAR. \nDigite 2 - para CORRIGIR. \nDigite 3 - Para Cancelar.");
      string confirmacao = Console.ReadLine();
      if (confirmacao != null)
      {
        switch (confirmacao)
        {
          case "1":
            bool usuarioDeletado = usuarioLista.Remove(usuarioEncontrado);
            if (usuarioDeletado) return "Dados de " + nome + " foi deletado do sistema com sucesso.";
            else return mensagemErro;
          case "2":
            Deletando();
            break;
          case "3":
            MenuPrincipal();
            break;
          default:
            Console.WriteLine("Opção inválida.\n");
            Deletando();
            break;
        }
      }
      return mensagemErro;
    }
  }
}