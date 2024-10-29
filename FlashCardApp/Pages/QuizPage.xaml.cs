using FlashCardApp.Models;
using System.Collections.ObjectModel;

namespace FlashCardApp.Pages;

public partial class QuizPage : ContentPage
{
    ObservableCollection<Card> CardList = new ObservableCollection<Card>
    {
        new Card {Front ="Question1", Back="answer1"},
        new Card {Front ="Question2", Back="answer2"},
        new Card {Front ="Question3", Back="answer3"},
    };
    public QuizPage()
	{
		InitializeComponent();
        CardsListView.ItemsSource = CardList;
    }

    private void addButton_Clicked(object sender, EventArgs e)
    {
        string newCardFront = FrontEntry.Text;
        string newCardBack = BackEntry.Text;
        CardList.Add(new Card { Front = newCardFront, Back = newCardBack });    
    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        //cast the sender as a type Frame cuz its type is Object rn\
        Frame frame = (Frame)sender;
        HorizontalStackLayout stack = (HorizontalStackLayout)frame.Content;
        var frontLbl = (Label)stack.Children[0];
        var backLbl = (Label)stack.Children[1];
        frontLbl.IsVisible = !frontLbl.IsVisible;
        backLbl.IsVisible = !backLbl.IsVisible;

        if (frame.BackgroundColor == Colors.Blue) {
            frame.BackgroundColor = Colors.Green;
        } else
        {
            frame.BackgroundColor = Colors.Blue;
        }
    }

    //!!! probably should've just used itemtapped on the listview and put the delete button there so i dont need the edit and delete button here, too late now i can't be asked
    private void DeleteButton_Clicked(object sender, EventArgs e)
    {
        //show usecase of var for future ref
        //the parent child hierachy is viewcell -> grid -> button, so we go back up two layers to get viewcell
        Button button = (Button) sender;
        var grid = button.Parent as Grid; //keyword "as" is fancy way of casting, same thing
        var viewCell = grid.Parent as ViewCell;
        //once we get viewcell we can get the whole card data cuz of that specific viewcell's
        //binding context so we dont needa get the label's value individually, also it's more scalable if we wanna add more property to Card class
        Card card = (Card) viewCell.BindingContext;

        // Remove the Card from the CardList
        CardList.Remove(card);
    }

    private async void EditButton_Clicked(object sender, EventArgs e)
    {
        //same logic to get the front and back card data from above:
        Button button = (Button)sender;
        var grid = button.Parent as Grid;
        var viewCell = grid.Parent as ViewCell;
        Card card = (Card)viewCell.BindingContext;
        // now pass that card data into the new edit page that we gon create
        EditPage editPage = new EditPage(card);
        await Navigation.PushAsync(editPage);
    }
}