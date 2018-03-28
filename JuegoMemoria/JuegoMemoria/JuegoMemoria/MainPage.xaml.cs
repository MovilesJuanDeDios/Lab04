using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace JuegoMemoria
{
	public partial class MainPage : ContentPage
	{
        /* ********************************************* INICIO DE LA CLASE **********************************************/

        /* *************** VARIABLES GLOOBALES DEL JUEGO *************** */
        List<Button> list = new List<Button>(); // Contiene todos los botones aleatoriamente ordenados  del grid
        List<string> letters; // Lista con las letras que se mostraran en el grid
        List<Button> buttons; // Contiene todos los botones aleatoriamente ordenados  del grid

        String firstChosen="";// Primer letra elegida
        String secondChosen = "";// Segunda letra elegida

        // Color que indica la casilla seleccionada
        Style selected = new Style(typeof(Button))
        {
            Setters = {
                  new Setter { Property = Button.BackgroundColorProperty, Value = Color.FromHex ("#E8AD00") },
                  new Setter { Property = Button.TextColorProperty, Value = Color.White },
                  new Setter { Property = Button.FontSizeProperty, Value = 30 }
                }
        };
        // Boton show
        Style darkerButton = new Style(typeof(Button))
        {
            Setters = {
                  new Setter { Property = Button.BackgroundColorProperty, Value = Color.FromHex ("#3399ff") },
                  new Setter { Property = Button.TextColorProperty, Value = Color.White },
                  new Setter { Property = Button.FontSizeProperty, Value = 25 }
                }
        };
        // Color de todos los botones escondidos
        Style hide = new Style(typeof(Button))
        {
            Setters = {
                  new Setter { Property = Button.BackgroundColorProperty, Value = Color.FromHex ("#ddd") },
                  new Setter { Property = Button.TextColorProperty, Value = Color.FromHex ("#ddd") },
                  new Setter { Property = Button.FontSizeProperty, Value = 30 }
                }
        };
        // Color de las casillas correctas
        Style correct = new Style(typeof(Button))
        {
            Setters = {
                  new Setter { Property = Button.BackgroundColorProperty, Value = Color.FromHex ("#009900") },
                  new Setter { Property = Button.TextColorProperty, Value = Color.White },
                  new Setter { Property = Button.FontSizeProperty, Value = 30 }
                }
        };
        // Color del boton restart 
        Style restart = new Style(typeof(Button))
        {
            Setters = {
                  new Setter { Property = Button.BackgroundColorProperty, Value = Color.FromHex ("#800000") },
                  new Setter { Property = Button.TextColorProperty, Value = Color.White },
                  new Setter { Property = Button.FontSizeProperty, Value = 30 }
                }
        };
        /* *************** Logica del juego *************** */
        public MainPage()
        {
            //Carga los componenetes y el juego
            Title = "Juego-Memoria";
            BackgroundColor = Color.FromHex("#404040");
            letters = RandomList(Letters());
            buttons = ButtonList(letters);
            Content = RandomAssignment(buttons);
        }
        // Lista de letras
        private List<string> Letters()
        {
            List<string> list = new List<string>();
            list.Add("T"); list.Add("A"); list.Add("C"); list.Add("M"); list.Add("V");
            list.Add("K"); list.Add("G"); list.Add("F"); list.Add("Y"); list.Add("P");
            list.Add("S"); list.Add("J"); list.Add("T"); list.Add("A"); list.Add("C");
            list.Add("M"); list.Add("V"); list.Add("K"); list.Add("G"); list.Add("F");
            list.Add("Y"); list.Add("P"); list.Add("S"); list.Add("J");

            return list;
        }
        // Desordenar la lista de letras aleatoriamente
        private List<string> RandomList(List<string> input)
        {
            List<string> arr = input;
            List<string> arrDes = new List<string>();
            Random randNum = new Random();
            while (arr.Count > 0)
            {
                int val = randNum.Next(0, arr.Count - 1);
                arrDes.Add(arr[val]);
                arr.RemoveAt(val);
            }
            return arrDes;
        }
        // Lista de botones
        private List<Button> ButtonList(List<string> input)
        {                     
            list.Add(new Button { Text = input.ElementAt(0), Style = hide }); list.Add(new Button { Text = input.ElementAt(1), Style = hide });
            list.Add(new Button { Text = input.ElementAt(2), Style = hide }); list.Add(new Button { Text = input.ElementAt(3), Style = hide });
            list.Add(new Button { Text = input.ElementAt(4), Style = hide }); list.Add(new Button { Text = input.ElementAt(5), Style = hide });
            list.Add(new Button { Text = input.ElementAt(6), Style = hide }); list.Add(new Button { Text = input.ElementAt(7), Style = hide });
            list.Add(new Button { Text = input.ElementAt(8), Style = hide }); list.Add(new Button { Text = input.ElementAt(9), Style = hide });
            list.Add(new Button { Text = input.ElementAt(10), Style = hide }); list.Add(new Button { Text = input.ElementAt(11), Style = hide });
            list.Add(new Button { Text = input.ElementAt(12), Style = hide }); list.Add(new Button { Text = input.ElementAt(13), Style = hide });
            list.Add(new Button { Text = input.ElementAt(14), Style = hide }); list.Add(new Button { Text = input.ElementAt(15), Style = hide });
            list.Add(new Button { Text = input.ElementAt(16), Style = hide }); list.Add(new Button { Text = input.ElementAt(17), Style = hide });
            list.Add(new Button { Text = input.ElementAt(18), Style = hide }); list.Add(new Button { Text = input.ElementAt(19), Style = hide });
            list.Add(new Button { Text = input.ElementAt(20), Style = hide }); list.Add(new Button { Text = input.ElementAt(21), Style = hide });
            list.Add(new Button { Text = input.ElementAt(22), Style = hide }); list.Add(new Button { Text = input.ElementAt(23), Style = hide });
            

            foreach (Button element in list)
            {
                element.Clicked += BtnClicked;
            }

            return list;
        }
        // Relleno de la matriz aleatoriamente
        private Grid RandomAssignment(List<Button> input)
        {                 
            var controlGrid = new Grid { RowSpacing = 1, ColumnSpacing = 1 };
            controlGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            controlGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            controlGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            controlGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            controlGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            controlGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });

            controlGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            controlGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            controlGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            controlGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            controlGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            var show = new Button { Text = "Show board", Style = darkerButton };
          
            controlGrid.Children.Add(show, 0, 0);
            Grid.SetColumnSpan(show, 5);

            show.Clicked += BtnShow_Clicked;

            int x = 0;
            for(int i =1;i<6;i++)
                for(int j = 0; j < 5; j++)
                {
                    if(x==24)
                        break;
                    controlGrid.Children.Add(input.ElementAt(x), j, i);
                    x++;
                }

            var restartBtn = new Button { Text = "R", Style = restart };

            controlGrid.Children.Add(restartBtn, 4, 5);
            restartBtn.Clicked += BtnRestart_Clicked;

            return controlGrid;
        }
        // Accion del boton Show grid
        private void BtnShow_Clicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            foreach (Button element in list){
                element.Style = selected;
                element.IsEnabled = false;
            }
                                   
        }
        // Accion del boton restart
        private void BtnRestart_Clicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            foreach (Button element in list)
            {
                element.Style = hide;
                element.IsEnabled = true;
            }

        }
        // Accion de los botones al ser clickeado
        private void BtnClicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.Style = selected;
            if (firstChosen == "" && secondChosen == "")
            {
                firstChosen = btn.Text;
                btn.IsEnabled = false;
                return;
            }
                
            if (firstChosen != "" && secondChosen == "")
            {
                secondChosen = btn.Text;
                Compare(firstChosen, secondChosen);
            }
            firstChosen = "";
            secondChosen = "";
        }
        // Compara el resultado de los dos botones seleccionados
        private void Compare(string text1, string text2)
        {
            if (text1 == text2)
            {
                Match(text1);
                return;
            }
            else
            {
                Failed(text1, text2);
                return;
            }
        }
        // Marca los botones si estos fueron elegidos correctamente
        private void Match(string text1)
        {
            foreach (Button element in list)
            {
                if (element.Text == text1)
                {
                    element.Style = correct;
                    element.IsEnabled = false;
                }                
            }
        }
        // Esconde los botones si estos han sido elegidos erroneamente
        private void Failed(string text1, string text2)
        {
            foreach (Button element in list)
            {
                if (element.Text == text1 || element.Text == text2)
                {
                    element.Style = hide;
                    element.IsEnabled = true;
                }
            }
        }

        /* ********************************************* FIN DE LA CLASE **********************************************/
    }
}
