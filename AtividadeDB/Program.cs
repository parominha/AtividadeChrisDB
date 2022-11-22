using System;
using System.Data;

namespace AtividadeDB
{
    class Program
    {
        static void Main(string[] args)
        {

            PesquisaDB.Cliente Pesquisa = new PesquisaDB.Cliente();

        Inicio:
            Console.WriteLine("-- BANCO DE DADOS --");
            Console.WriteLine("1- LISTAR");
            Console.WriteLine("2- CADASTRAR");
            Console.WriteLine("3- ALTERAR");
            Console.WriteLine("4- DELETAR");
            Console.WriteLine("5- SAIR");
            Console.Write("-> ");
            string opcao = Console.ReadLine();
            Console.WriteLine(" ");

            switch (opcao)
            {
                case "1":
                    Console.WriteLine("P- Produto");
                    Console.WriteLine("G- Grupo");
                    Console.Write("-> ");
                    string opcaoPG1 = Console.ReadLine();
                    Console.WriteLine(" ");
                    if (opcaoPG1.ToUpper() == "P")
                    {
                        Console.WriteLine("Digite o nome do produto que deseja pesquisar:");
                        Console.Write("-> ");
                        string nomeProduto1 = Console.ReadLine();
                        DataSet DataSetCliente = new DataSet();
                        DataSetCliente = Pesquisa.Listar_Produto(nomeProduto1);
                        foreach (DataRow linha in DataSetCliente.Tables[0].Rows)
                        {
                            Console.WriteLine(linha["Nome_Produto"]);
                        }
                    }
                    else if (opcaoPG1.ToUpper() == "G")
                    {
                        Console.WriteLine("Digite o nome do grupo que deseja pesquisar:");
                        Console.Write("-> ");
                        string nomeGrupo1 = Console.ReadLine();
                        DataSet DataSetCliente = new DataSet();
                        DataSetCliente = Pesquisa.Listar_Produto(nomeGrupo1);
                        foreach (DataRow linha in DataSetCliente.Tables[0].Rows)
                        {
                            Console.WriteLine(linha["Nome_Produto"]);
                        }
                    }
                    break;

                case "2":
                    Console.WriteLine("Digite o nome do produto que deseja cadastrar:");
                    Console.Write("-> ");
                    string nomeProduto2 = Console.ReadLine();
                    Console.WriteLine("Digite o ID do grupo:");
                    Console.Write("-> ");
                    string idGrupo = Console.ReadLine();
                    int produtoCadastrado = 0;
                    
                    try
                    {
                        produtoCadastrado = Pesquisa.Cadastrar_Produto(nomeProduto2, idGrupo);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error:" + ex.Message.ToString());
                    }

                    if (produtoCadastrado == 1)
                    {
                        Console.WriteLine("Produto cadastrado com sucesso!");
                        Console.WriteLine("");
                        Console.WriteLine("Pressione qualquer tecla para voltar ao menu");
                        Console.ReadKey();
                        Console.Clear();
                        goto Inicio;
                    }
                    else if (produtoCadastrado == 0)
                    {
                        Console.Write("Este grupo não consta no Banco de Dados. Deseja criar um novo? S/N: ");
                        string resposta = Console.ReadLine();
                        if (resposta.ToUpper() == "S")
                        {
                            Console.Write("Informe o nome do grupo: ");
                            string nomedoGrupo = Console.ReadLine();
                            string novoIdGrupo = Pesquisa.Gerar_IdGrupo();
                            Pesquisa.Cadastrar_Grupo(nomedoGrupo, novoIdGrupo);
                            Pesquisa.Cadastrar_Produto(nomeProduto2, novoIdGrupo);
                            Console.WriteLine("Grupo gerado com o ID: " + novoIdGrupo);
                            Console.WriteLine("");
                            Console.WriteLine("Pressione qualquer tecla para voltar ao menu");
                            Console.ReadKey();
                            Console.Clear();
                            goto Inicio;
                        }
                        else
                        {
                            Console.WriteLine("Pressione qualquer tecla para voltar ao menu");
                            Console.ReadKey();
                            Console.Clear();
                            goto Inicio;
                        }
                    }
                    break;

                case "3":
                    Console.WriteLine("Digite o nome do produto que deseja alterar:");
                    Console.Write("-> ");
                    string nomeProdutoAlterar = Console.ReadLine();                    
                    Console.Write("Digite o novo nome do produto:");
                    Console.Write("-> ");                   
                    string nomeProdutoAlterado = Console.ReadLine();
                    int produtosAlterados = Pesquisa.Alterar_Produto(nomeProdutoAlterar, nomeProdutoAlterado);
                    if (produtosAlterados == 0)
                    {
                        Console.WriteLine("Nenhum registro alterado.");
                        Console.WriteLine("Pressione qualquer tecla para voltar ao menu");
                        Console.ReadKey();
                        Console.Clear();
                        goto Inicio;
                    }
                    else
                    {
                        Console.WriteLine("Produto alterado com sucesso!");
                        Console.WriteLine("Foram alterados " + produtosAlterados + " registros.");
                        Console.WriteLine("");
                        Console.WriteLine("Pressione qualquer tecla para voltar ao menu");
                        Console.ReadKey();
                        Console.Clear();
                        goto Inicio;
                    }


                case "4":
                    Console.WriteLine("Deseja deletar por:");
                    Console.WriteLine("1- NOME DO PRODUTO");
                    Console.WriteLine("2- ID DO PRODUTO");
                    Console.Write("-> ");
                    string tipoDeletar = Console.ReadLine();
                    Console.WriteLine("");

                    if (tipoDeletar == "1")
                    {
                        Console.WriteLine("Digite o nome do produto que deseja deletar:");
                        Console.Write("-> ");
                        string nomeProdutoDeletar = Console.ReadLine();
                        Console.Write("Confirma a exclusão do produto " + nomeProdutoDeletar + "? S/N: ");
                        string confirmacaoDeletar = Console.ReadLine();
                        if (confirmacaoDeletar.ToUpper() == "S")
                        {
                            int produtos = Pesquisa.Apagar_ProdutoNome(nomeProdutoDeletar);
                            if (produtos == 0)
                            {
                                Console.WriteLine("Nenhum registro deletado.");
                                Console.WriteLine("Pressione qualquer tecla para voltar ao menu");
                                Console.ReadKey();
                                Console.Clear();
                                goto Inicio;
                            }
                            else
                            {
                                Console.WriteLine(nomeProdutoDeletar + " deletado com sucesso!");
                                Console.WriteLine("Foram deletados " + produtos + " registros.");
                                Console.WriteLine("");
                                Console.WriteLine("Pressione qualquer tecla para voltar ao menu");
                                Console.ReadKey();
                                Console.Clear();
                                goto Inicio;
                            }
                        }
                        else if (confirmacaoDeletar.ToUpper() == "N")
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Pressione qualquer tecla para voltar ao menu");
                            Console.ReadKey();
                            Console.Clear();
                            goto Inicio;
                        }
                        else
                        {
                            Console.WriteLine("Opção não encontrada.");
                            Console.WriteLine("");
                            Console.WriteLine("Pressione qualquer tecla para voltar ao menu");
                            Console.ReadKey();
                            Console.Clear();
                            goto Inicio;

                        }
                    }

                    else if (tipoDeletar == "2")
                    {
                        Console.WriteLine("Digite o ID do produto que deseja deletar:");
                        Console.Write("-> ");
                        string idProdutoDeletar = Console.ReadLine();
                        Console.Write("Confirma a exclusão do produto " + idProdutoDeletar + "? S/N: ");
                        string idConfirmacaoDeletar = Console.ReadLine();
                        if (idConfirmacaoDeletar.ToUpper() == "S")
                        {
                            int produtos = Pesquisa.Apagar_ProdutoId(idProdutoDeletar);
                            if (produtos == 0)
                            {
                                Console.WriteLine("Nenhum registro deletado.");
                                Console.WriteLine("Pressione qualquer tecla para voltar ao menu");
                                Console.ReadKey();
                                Console.Clear();
                                goto Inicio;
                            }
                            else
                            {
                                Console.WriteLine(idProdutoDeletar + " deletado com sucesso!");
                                Console.WriteLine("Foram deletados " + produtos + " registros.");
                                Console.WriteLine("");
                                Console.WriteLine("Pressione qualquer tecla para voltar ao menu");
                                Console.ReadKey();
                                Console.Clear();
                                goto Inicio;
                            }
                        }
                        else if (idConfirmacaoDeletar.ToUpper() == "N")
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Pressione qualquer tecla para voltar ao menu");
                            Console.ReadKey();
                            Console.Clear();
                            goto Inicio;
                        }
                        else
                        {
                            Console.WriteLine("Opção não encontrada.");
                            Console.WriteLine("");
                            Console.WriteLine("Pressione qualquer tecla para voltar ao menu");
                            Console.ReadKey();
                            Console.Clear();
                            goto Inicio;
                        }
                    }                       
                    break;


                case "5":
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
