using System;
using Trabalho2.Views;
using Xamarin.Forms;

namespace Trabalho2
{
    public class MainPage : TabbedPage
    {
        public MainPage()
        {
            Page itemsPage, listaProdutosPage, listaComprasPage, aboutPage = null;

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    itemsPage = new NavigationPage(new ItemsPage())
                    {
                        Title = "Browse"
                    };

                    aboutPage = new NavigationPage(new AboutPage())
                    {
                        Title = "About"
                    };

                    listaProdutosPage = new NavigationPage(new ListaProdutosPage())
                    {
                        Title = "Produtos"
                    };

                    listaComprasPage = new NavigationPage(new ListaComprasPage())
                    {
                        Title = "Compras"
                    };

                    itemsPage.Icon = "tab_feed.png";
                    aboutPage.Icon = "tab_about.png";
                    listaProdutosPage.Icon = "tab_feed.png";
                    listaComprasPage.Icon = "tab_feed.png";
                    break;
                default:
                    itemsPage = new ItemsPage()
                    {
                        Title = "Browse"
                    };

                    aboutPage = new AboutPage()
                    {
                        Title = "About"
                    };

                    listaProdutosPage = new ListaProdutosPage()
                    {
                        Title = "Produtos"
                    };

                    listaComprasPage = new ListaComprasPage()
                    {
                        Title = "Compras"
                    };
                    break;
            }

            Children.Add(itemsPage);
            Children.Add(aboutPage);
            Children.Add(listaProdutosPage);
            Children.Add(listaComprasPage);

            Title = Children[0].Title;
        }

        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();
            Title = CurrentPage?.Title ?? string.Empty;
        }
    }
}
