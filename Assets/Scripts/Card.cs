using System;
using Assets.Scripts.Types;

public class Card
{
    private Guid iD;
    private CardType cardType;
    private Color colorType;

    public Card(CardType card, Color color)
    {
        iD = new Guid();
        cardType = card;
        colorType = color;
    }

    public CardType CardType
    {
        get
        {
            return cardType;
        }
    }
     
    public Color Color
    {
        get
        {
            return colorType;
        }
    }
}

