using Pazaak.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Pazaak.UserControls
{
    /// <summary>
    /// Interaction logic for HandControl.xaml
    /// </summary>
    public partial class HandControl : UserControl
    {

		public HandControl()
        {
            InitializeComponent();
        }

		private void CardControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			Player thisPlayer = (Player)this.DataContext;
			ICard thisCard = (ICard)((CardControl)sender).DataContext;

			//TODO Change Player.Hand.Cards into a List
			thisPlayer.Board.AddCard(thisCard);
			//thisPlayer.Hand.Cards.r

//			thisPlayer.Hand.AddToBoard(thisCard, thisPlayer.Board);		
		}
	}
}
