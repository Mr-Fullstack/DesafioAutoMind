using System;
using System.Reflection.Metadata.Ecma335;


namespace automind.selecao.estagio
{
  public class Usuario
  {
    public string Nome { get;  set; }
    public string Email { get;  set; }
    public int Idade { get;  set ; }


    public override string ToString()
    {
      return "Nome: " + Nome + "\nEmail: " + Email + "\nIdade: " + Idade;
    }
  }



}