using FlashCardApp.Models;

namespace FlashCardApp.Pages;

public partial class EditPage : ContentPage
{
    //make a new Card card with the same values as the card that was pass down thur the constructor
    //so we can access it outside of the constructor
	public Card Card { get; set; }
	public EditPage(Card card)
	{
		InitializeComponent();
		Card = card;
		FrontEntry.Text = Card.Front; 
        //btw, card.Front works here too cuz we have access to card from inside the constructor
		BackEntry.Text = Card.Back;
	}

    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        // update the card with the new values
        // i have no idea why we can change the values of a card inside the ObservableCollection<Card> CardList directly from inside this event handler
        // i think it's cuz it's an ObservableCollection Object so it auto updates, idk why it works, it just does, i'm not gonna touch it
        Card.Front = FrontEntry.Text;
        Card.Back = BackEntry.Text;
        //pop it off the navigation page stack so we go back to the previous page (quiz page)
        await Navigation.PopAsync();
    }
}