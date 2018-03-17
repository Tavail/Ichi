using System;
using Assets.Scripts.Types;

namespace Assets.Scripts
{
    public class Card
    {
        private Guid iD;
        private CardType cardType;
        private Color colorType;

        public Card(CardType card, Color color)
        {
            iD = Guid.NewGuid();
            cardType = card;
            colorType = color;
        }

        public Guid ID
        {
            get
            {
                return iD;
            }
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
}