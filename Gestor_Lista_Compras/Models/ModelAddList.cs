using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Gestor_Lista_Compras
{
    public class ModelAddList
    {
        public event MetodosSemParametros ListaAdiciona;


        //Classes
        public ItemDaLista Itemlista;
        public List<Lista> Listas { get; set; }

        public List<Categoria> Categorias { get; set; } 

        public string nomeLista { get; set; }
        public string Listas_Ficheiro = "Ficheiro";
        public string nomeAntigo { get; set; }
        
        public bool btn_flag { get; set; }

        public ModelAddList()
        {
            Listas = new List<Lista>();
            Categorias= new List<Categoria>();  

        }

        //Lista******************Lista**************************Lista******************************Lista****************************Lista************************Lista*****************************
        public void AddLista(string texto)
        {
            if (texto.Length > 0 && texto.Length <= 30)
            {


                //Armazenamento do texto válido (Atualização do estado da aplicação)
                Listas.Add(new Lista(texto));

                //3ªlançamento do evento (notificação da view da alteração do estado da aplicação)
                if (ListaAdiciona != null)
                    ListaAdiciona();


            }
            else
            {

                throw new TextoInvalidoExeption("Texto inválido!! [1-30] carateres");
            }
        }

        public void RemoveLista(string nome)
        {
            foreach (var li in Listas)
            {
                Console.WriteLine(li.NomeLista);
            }
            if (nome != null)
            {
                var result = (from li in Listas
                              where li.NomeLista == nome
                              select li).First();

                if (result != null)
                {
                    Listas.Remove(result);

                }
                else
                { throw new TextoInvalidoExeption("não está presente na lista!!"); }
            }
            else
            {

                throw new TextoInvalidoExeption("Texto inválido!!");
            }

        }


        public void EditLista(string nomeNovo)
        {
            if (nomeAntigo != null)
            {
                var result = (from user in Listas
                              where user.NomeLista == nomeAntigo
                              select user).FirstOrDefault();

                if (result != null)
                {
                    result.NomeLista = nomeNovo;
                }
                else
                { throw new TextoInvalidoExeption("não está presente na lista!!"); }
            }
            else
            {

                throw new TextoInvalidoExeption("Texto inválido!!");
            }
        }



        //Items*******************************Items*************************Items*********************Items********************Items*********************Items***************
        public void AdicionaItemList(string nomeLista, string nome, string quantidade, string categoria)
        {

            var result = (from user in Listas
                          where user.NomeLista == nomeLista
                          select user).FirstOrDefault();

            if (result != null)
            {
                result.itemDaListas.Add(new ItemDaLista(nome, quantidade, categoria));

            }
        }

        public void RemoveItemList(string nomeLista, string nomeItem)
        {
            var result = (from lista in Listas
                          where lista.NomeLista == nomeLista
                          select lista).FirstOrDefault();

            var rItem = (from item in result.itemDaListas
                         where item.NomeItem == nomeItem
                         select item).FirstOrDefault();

            if(rItem != null)
            {
                result.itemDaListas.Remove(rItem);
            }

        }

        public void EditarItemList (string nomeLista, string nomeItem, string quantidade, string categoria)
        {
            var result = (from user in Listas
                          where user.NomeLista == nomeLista
                          select user).FirstOrDefault();

            var rItem = (from item in result.itemDaListas
                         where item.NomeItem == nomeAntigo
                         select item).FirstOrDefault();

            if (rItem != null)
            {
                if(nomeItem.Length > 0 && quantidade.Length > 0 && categoria.Length > 0)
                {
                    rItem.NomeItem = nomeItem;
                    rItem.Quantidade = quantidade;
                    rItem.Categoria = categoria;
                }
                else
                    throw new TextoInvalidoExeption("Campos Invalidos");
            }
            else
                throw new TextoInvalidoExeption("Lista não encontrada");
        }

        public void SaveListaXML()
        {
            XDocument doc = new XDocument(new XDeclaration("1.0", Encoding.UTF8.ToString(), "yes"),
                      new XComment("Listagem de Listas"),
                      new XElement("ListasCompras",
                      new XElement("Listas")));

            foreach (var lista in Listas)
            {
                //CRIAR ESTRUTURA DO XML

                XElement novoL = new XElement("Lista", new XAttribute("Nome", lista.NomeLista));
               
                   
                
                foreach(var produto in lista.itemDaListas)
                {
                    XElement novoP = new XElement("Produto", new XAttribute("Nome", produto.NomeItem),
                       new XElement("Comprado", produto.Comprado),
                       new XElement("Categoria", produto.Categoria),
                       new XElement("Quantidade", produto.Quantidade));

                    novoL.Add(novoP);
                }
                doc.Element("ListasCompras").Element("Listas").Add(novoL);


            }

            //guarda a estrutura de dados xml da memoria para ficheiro xml utilizando LINQ
            doc.Save("Listas.xml");

        }

        public void LoadListaXML()
        {
          
                XDocument doc = XDocument.Load("Listas.xml");

         

                var listas = from lst in doc.Elements("ListasCompras").Elements("Listas").Descendants("Lista") select lst;

                foreach (var lista in listas)
                {
                    Lista nova = new Lista(lista.Attribute("Nome").Value);

                    var produtos = from al in lista.Descendants("Produto") select al;

                    foreach (var tmp in produtos)
                    {

                        nova.itemDaListas.Add (new ItemDaLista(tmp.Attribute("Nome").Value, tmp.Element("Quantidade").Value, tmp.Element("Categoria").Value));

                    }
                    Listas.Add(nova);
                }
            
           

        }


        //Categoria*******************************Categoria*******************************Categoria******************************* Categoria*******************************Categoria******************************* Categoria*******************************

        public void AddCategoria(string nomeC)
        {
            if (nomeC.Length > 0)
            {
                Categorias.Add ( new Categoria(nomeC) );
            }
            else
            {

                throw new TextoInvalidoExeption("Texto inválido!!");
            }
        }

        public void RemoveCategoria(string nomeC)
        {
            if (nomeC.Length > 0)
            {
                var result = (from lst in Categorias
                              where lst.Nome_Categoria == nomeC
                              select lst).FirstOrDefault();
                if( result.fixa == false)
                {
                    Categorias.Remove(result);
                }
                else
                {
                    throw new TextoInvalidoExeption("Não pode remover Categorias Fixas!!");
                }
            }
            else
            {

                throw new TextoInvalidoExeption("Nada selecionado!!");
            }
        }

        public void LoadCategoriasXML()
        {
           
                    //remover dados antigos da estrutura de dados (reset ao estado da aplicação)
                    Categorias.Clear();

                    //Carrega conteudo de ficheiro xml para a memoria
                    XDocument doc = XDocument.Load("Categorias.xml");

                //efetua expressão de consula relativa aos alunos inscritos utilizando o linq
                var registo = from cat in doc.Element("ListaCategorias").Element("Fixo").Descendants("Categoria")
                                  select cat;
                    //Percorre o xml na memoria dos alunos inscritos

                foreach (var campos in registo)
                {
                    //Cria objecto Aluno com os dados respectivos
                    Categoria novaCategoria = new Categoria(campos.Attribute("Nome").Value);


                    novaCategoria.fixa = true;
                    //Adiciona aluno à estrutura de dados(Dictionary)
                    Categorias.Add(novaCategoria);

                }

                registo = from cat in doc.Element("ListaCategorias").Element("NaoFixo").Descendants("Categoria")
                          select cat;
                //Percorre o xml na memoria dos alunos inscritos

                foreach (var campos in registo)
                {

                    //Cria objecto Aluno com os dados respectivos
                    Categoria novaCategoria = new Categoria(campos.Attribute("Nome").Value);


                    novaCategoria.fixa = false;
                    //Adiciona aluno à estrutura de dados(Dictionary)
                    Categorias.Add(novaCategoria);


                }
            
          
        }

        public void SaveCategoriasXML()
        {
            XDocument doc = new XDocument(new XDeclaration("1.0", Encoding.UTF8.ToString(), "yes"),
                      new XComment("ListagemdeCategorias"),
                      new XElement("ListaCategorias",
                      new XElement("Fixo"),
                      new XElement("NaoFixo")));
            foreach (var al in Categorias)
            {
                //CRIAR ESTRUTURA DO XML

                XElement novo = new XElement("Categoria", new XAttribute("Nome", al.Nome_Categoria));
                if (al.fixa == true)
                    doc.Element("ListaCategorias").Element("Fixo").Add(novo);
                else
                    doc.Element("ListaCategorias").Element("NaoFixo").Add(novo);

            }

            //guarda a estrutura de dados xml da memoria para ficheiro xml utilizando LINQ
            doc.Save("Categorias.xml");
        }

    }
}