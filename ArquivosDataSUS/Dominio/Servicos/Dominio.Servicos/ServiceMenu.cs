using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Entity;
using Domain.Interfaces;

namespace Domain.Service
{
    public class ServiceMenu : IServiceMenu
    {
        public List<ModuloMenu> ObtemMenus()
        {
            List<ModuloMenu> lstMenus = new List<ModuloMenu>();
            ModuloMenu menu1 = new ModuloMenu();
            menu1.CodigoMenu = 1;
            menu1.Codigo = 1;
            menu1.NomeModulo = "Cadastros";
            menu1.Sequencia = 1;
            menu1.Privilegio = 99;
            menu1.CodigoPai = null;
            lstMenus.Add(menu1);

            ModuloMenu menuClientes = new ModuloMenu();
            menuClientes.CodigoMenu = 10;
            menuClientes.Codigo = 10;
            menuClientes.Privilegio = 99;
            menuClientes.CodigoPai = "1";
            menuClientes.NomeModulo = "Cadastro de Moradores";
            menuClientes.UrlAcesso = "~/Cliente/Default.aspx";
            lstMenus.Add(menuClientes);

            ModuloMenu menuUsuarios = new ModuloMenu();
            menuUsuarios.CodigoMenu = 2;
            menuUsuarios.Codigo = 2;
            menuUsuarios.Privilegio = 0;
            menuUsuarios.CodigoPai = "1";
            menuUsuarios.NomeModulo = "Cadastro de Usuarios";
            menuUsuarios.UrlAcesso = "~/Usuario/Default.aspx";
            lstMenus.Add(menuUsuarios);

            ModuloMenu menuDemanda = new ModuloMenu();
            menuDemanda.CodigoMenu = 3;
            menuDemanda.Codigo = 3;
            menuDemanda.Privilegio = 99;
            menuDemanda.CodigoPai = "1";
            menuDemanda.NomeModulo = "Cadastro de Demandas";
            menuDemanda.UrlAcesso = "~/Demanda/Default.aspx";
            lstMenus.Add(menuDemanda);

            ModuloMenu menuVisitas = new ModuloMenu();
            menuVisitas.CodigoMenu = 4;
            menuVisitas.Codigo = 4;
            menuVisitas.Privilegio = 0;
            menuVisitas.CodigoPai = "1";
            menuVisitas.NomeModulo = "Cadastro de Visitas";
            menuVisitas.UrlAcesso = "~/Visita/Default.aspx";
            lstMenus.Add(menuVisitas);

            ModuloMenu menu2 = new ModuloMenu();
            menu2.CodigoMenu = 20;
            menu2.Codigo = 20;
            menu2.NomeModulo = "Mapas";
            menu2.Sequencia = 2;
            menu2.CodigoPai = null;
            lstMenus.Add(menu2);

            ModuloMenu menuMapa = new ModuloMenu();
            menuMapa.CodigoMenu = 21;
            menuMapa.Codigo = 21;
            menuMapa.Privilegio = 0;
            menuMapa.CodigoPai = "20";
            menuMapa.NomeModulo = "Mapa de Localização dos Agentes";
            menuMapa.UrlAcesso = "~/Mapas/MapaLocalizacaoAgentes.aspx";
            lstMenus.Add(menuMapa);

            ModuloMenu menuMapaCampanha = new ModuloMenu();
            menuMapaCampanha.CodigoMenu = 23;
            menuMapaCampanha.Codigo = 23;
            menuMapaCampanha.Privilegio = 0;
            menuMapaCampanha.CodigoPai = "20";
            menuMapaCampanha.NomeModulo = "Mapa Eleitoral";
            menuMapaCampanha.UrlAcesso = "~/Mapas/MapaLocalizacaoAgentes.aspx";
            lstMenus.Add(menuMapaCampanha);


            ModuloMenu menu3 = new ModuloMenu();
            menu3.CodigoMenu = 30;
            menu3.Codigo = 30;
            menu3.NomeModulo = "Campanhas";
            menu3.Sequencia = 3;
            menu3.CodigoPai = null;
            lstMenus.Add(menu3);

            ModuloMenu menu4 = new ModuloMenu();
            menu4.CodigoMenu = 40;
            menu4.Codigo = 40;
            menu4.NomeModulo = "Relatórios";
            menu4.Sequencia = 4;
            menu4.CodigoPai = null;
            lstMenus.Add(menu4);

            //ModuloMenu menuFuncionarios = new ModuloMenu();
            //menuFuncionarios.CodigoMenu = 3;
            //menuFuncionarios.Codigo = 3;
            //menuFuncionarios.Privilegio = 1;
            //menuFuncionarios.CodigoPai = "1";
            //menuFuncionarios.NomeModulo = "Cadastro de Funcionarios";
            //menuFuncionarios.UrlAcesso = "~/Funcionario/Default.aspx";
            //lstMenus.Add(menuFuncionarios);

            //ModuloMenu menuSupervisores = new ModuloMenu();
            //menuSupervisores.CodigoMenu = 5;
            //menuSupervisores.Codigo = 5;
            //menuSupervisores.Privilegio = 1;
            //menuSupervisores.CodigoPai = "1";
            //menuSupervisores.NomeModulo = "Cadastro de Supervisores";
            //menuSupervisores.UrlAcesso = "~/Supervisor/Default.aspx";
            //lstMenus.Add(menuSupervisores);

            //ModuloMenu menuFuncao = new ModuloMenu();
            //menuFuncao.CodigoMenu = 12;
            //menuFuncao.Codigo = 12;
            //menuFuncao.Privilegio = 1;
            //menuFuncao.CodigoPai = "1";
            //menuFuncao.NomeModulo = "Cadastro de Função";
            //menuFuncao.UrlAcesso = "~/Funcao/Default.aspx";
            //lstMenus.Add(menuFuncao);

            //ModuloMenu menuSecao = new ModuloMenu();
            //menuSecao.CodigoMenu = 6;
            //menuSecao.Codigo = 6;
            //menuSecao.Privilegio = 1;
            //menuSecao.CodigoPai = "1";
            //menuSecao.NomeModulo = "Cadastro de Seções";
            //menuSecao.UrlAcesso = "~/Secao/Default.aspx";
            //lstMenus.Add(menuSecao);

            //ModuloMenu menuBairros = new ModuloMenu();
            //menuBairros.CodigoMenu = 11;
            //menuBairros.Codigo = 11;
            //menuBairros.Privilegio = 1;
            //menuBairros.CodigoPai = "1";
            //menuBairros.NomeModulo = "Cadastro de Bairros";
            //menuBairros.UrlAcesso = "~/Bairro/Default.aspx";
            //lstMenus.Add(menuBairros);

            //ModuloMenu menuTurmas = new ModuloMenu();
            //menuTurmas.CodigoMenu = 9;
            //menuTurmas.Codigo = 9;
            //menuTurmas.Privilegio = 1;
            //menuTurmas.CodigoPai = "1";
            //menuTurmas.NomeModulo = "Cadastro de Turmas";
            //menuTurmas.UrlAcesso = "~/Turma/Default.aspx";
            //lstMenus.Add(menuTurmas);

            //ModuloMenu menuGeoposicionadas = new ModuloMenu();
            //menuGeoposicionadas.CodigoMenu = 7;
            //menuGeoposicionadas.Codigo = 7;
            //menuGeoposicionadas.Privilegio = 1;
            //menuGeoposicionadas.CodigoPai = "1";
            //menuGeoposicionadas.NomeModulo = "Cadastro de Tarefas Geoposicionadas";
            //menuGeoposicionadas.UrlAcesso = "~/Tarefa/Default.aspx";
            //lstMenus.Add(menuGeoposicionadas);

            //ModuloMenu menuAlocarTarefas = new ModuloMenu();
            //menuAlocarTarefas.CodigoMenu = 8;
            //menuAlocarTarefas.Codigo = 8;
            //menuAlocarTarefas.Privilegio = 1;
            //menuAlocarTarefas.CodigoPai = "1";
            //menuAlocarTarefas.NomeModulo = "Alocar Turmas em Tarefas";
            //menuAlocarTarefas.UrlAcesso = "~/Tarefa/AlocaTurma.aspx";
            //lstMenus.Add(menuAlocarTarefas);

            //ModuloMenu menu4 = new ModuloMenu();
            //menu4.CodigoMenu = 4;
            //menu4.Codigo = 4;
            //menu4.Sequencia = 2;
            //menu4.NomeModulo = "Consultas";
            //menu4.Privilegio = 99;
            //menu4.CodigoPai = null;
            //lstMenus.Add(menu4);

            //ModuloMenu menuRelatorioFuncionarios = new ModuloMenu();
            //menuRelatorioFuncionarios.CodigoMenu = 13;
            //menuRelatorioFuncionarios.Codigo = 13;
            //menuRelatorioFuncionarios.CodigoPai = "4";
            //menuRelatorioFuncionarios.Privilegio = 99;
            //menuRelatorioFuncionarios.NomeModulo = "Relatório de Funcionários";
            //menuRelatorioFuncionarios.UrlAcesso = "~/Funcionario/Relatorio.aspx";
            //lstMenus.Add(menuRelatorioFuncionarios);

            return lstMenus;

        }
    }
}
