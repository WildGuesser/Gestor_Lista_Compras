using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Gestor_Lista_Compras
{
    public class ModelSignUp
    {

        public List<Utilizador> utilizadores;
        public event MetodosCom1String registado;
        public event MetodosCom1String nao_registado;
        public ModelSignUp()
        {

            utilizadores = new List<Utilizador>();
            utilizadores.Add(new Utilizador("cenas1", "cenas1@mail.com", "cenas1", "pilha de cenas1"));
            utilizadores.Add(new Utilizador("cenas2", "cenas1@mail.com", "cenas2", "pilha de cenas2"));
            utilizadores.Add(new Utilizador("cenas3", "cenas3@mail.com", "cenas3", "pilha de cenas3"));

        }
        public void RegisterUser(string nomeUser, string email, string password, string pais)
        {
            foreach (Utilizador user in utilizadores)
            {
                if (nomeUser != user.NomeUser)
                {
                    utilizadores.Add(new Utilizador(nomeUser, email, password, pais));
                    registado("Registado com sucesso");
                }
                else
                    nao_registado("nome de User já está em uso");
            }
        }

        public void EscritaFicheiroXML(string ficheiro)
        {
            XDocument doc = new XDocument(new XDeclaration("1.0", Encoding.UTF8.ToString(), "yes"),
                            new XComment("Lista_Utilizadores"),
                            new XElement("Utilizadores"));
            foreach (Utilizador user in utilizadores)
            {
                //CRIAR ESTRUTURA DO XML
                XElement novo = new XElement("Utilizadores", new XAttribute("Username", user.NomeUser),
                    new XElement("Mail", user.Email),
                    new XElement("Pass", user.Password),
                    new XElement("Pais", user.Pais));

               
                    doc.Element("Utilizadores").Add(novo);
             

            }

            //guarda a estrutura de dados xml da memoria para ficheiro xml utilizando LINQ
            doc.Save(ficheiro);
        }

    }
}
