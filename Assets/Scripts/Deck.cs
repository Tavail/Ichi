using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Types;

namespace Assets.Scripts
{
    public class Deck
    {
        // Will hold the deck of cards.
        public List<Card> DeckCards;
        // Will hold the cards that have been played.
        public List<Card> DiscardPile;

        public Deck()
        {
            // Construct the Deck from the CreateDeck method.
            CreateDeck();
        }

        /// <summary>
        /// Used to create the deck for the 
        /// first time the game is being set up.
        /// </summary>
        public void CreateDeck()
        {
            // Create the dictionary of the color cards.
            Dictionary<CardType, int> cardDic = new Dictionary<CardType, int>();

            cardDic.Add(CardType.Zero, 1);
            cardDic.Add(CardType.One, 2);
            cardDic.Add(CardType.Two, 2);
            cardDic.Add(CardType.Three, 2);
            cardDic.Add(CardType.Four, 2);
            cardDic.Add(CardType.Five, 2);
            cardDic.Add(CardType.Six, 2);
            cardDic.Add(CardType.Seven, 2);
            cardDic.Add(CardType.Eight, 2);
            cardDic.Add(CardType.Nine, 2);
            cardDic.Add(CardType.DrawTwo, 2);
            cardDic.Add(CardType.Skip, 2);
            cardDic.Add(CardType.Reverse, 2);

            List<Color> colors = Enum.GetValues(typeof(Color)).Cast<Color>().ToList();
            
            // Loop through each color
            foreach(Color color in colors)
            {
                // If its the wild color, set up the wilds.
                if (color == Color.None)
                {
                    // Create list of wild card types.
                    List<CardType> wildCards = new List<CardType>();
                    wildCards.Add(CardType.Wild);
                    wildCards.Add(CardType.WildDrawFour);

                    // Loop through the wild card typs.
                    foreach(CardType wildCard in wildCards)
                    {
                        // Each wild card gets four copies of itself.
                        for (int i = 4; i > 0; i--)
                        {
                            // Create the card from the type we're on.
                            Card tempCard = new Card(wildCard, Color.None);

                            // Add the card to the deck.
                            DeckCards.Add(tempCard);
                        }
                    }
                    
                }
                // If it isn't the wild color, set up other colors.
                else
                {
                    // Loop through each card type.
                    foreach (KeyValuePair<CardType, int> kvp in cardDic)
                    {
                        // Create a card for each number of cards needed in the value.
                        for (int i = kvp.Value; i > 0; i--)
                        {
                            // Create the card from the color we're on and type.
                            Card tempCard = new Card(kvp.Key, color);

                            // Add the card to the deck.
                            DeckCards.Add(tempCard);
                        }
                    }
                } 
            }
        }

        // Add Shuffle Method here.
    }
}
