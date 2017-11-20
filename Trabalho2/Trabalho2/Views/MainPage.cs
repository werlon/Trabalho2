using System;
using Trabalho2.Views;
using Xamarin.Forms;

namespace Trabalho2
{
    public class MainPage : TabbedPage
    {
        public MainPage()
        {
            Page listaProdutosPage, listaComprasPage, aboutPage = null;

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    aboutPage = new NavigationPage(new AboutPage())
                    {
                        Title = "Trabalho 2"
                    };

                    listaProdutosPage = new NavigationPage(new ListaProdutosPage())
                    {
                        Title = "Produtos"
                    };

                    listaComprasPage = new NavigationPage(new ListaComprasPage())
                    {
                        Title = "Compras"
                    };

                    aboutPage.Icon = "tab_about.png";
                    listaProdutosPage.Icon = "tab_feed.png";
                    listaComprasPage.Icon = "tab_feed.png";
                    break;
                default:
                    aboutPage = new AboutPage()
                    {
                        Title = "Trabalho 2"
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
