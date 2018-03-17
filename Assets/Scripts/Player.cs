using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts
{
    public class Player : MonoBehaviour
    {
        private Guid id;
        private string name;
        private int wins;
        private List<Card> cardsInHand;

        public Player(string playerName)
        {
            id = Guid.NewGuid();
            name = playerName;
        }

        public List<Card> GetCardsInHand()
        {
            return cardsInHand;
        }

        public void AddCardToHand(Card card)
        {
            cardsInHand.Add(card);
        }

        public void RemoveCardFromHand(Card card)
        {
            Card cardToRemove = cardsInHand.FirstOrDefault(x => x.ID == card.ID);

            if (cardToRemove != null)
            {
                cardsInHand.Remove(cardToRemove);
            }
            else
            {
                throw new Exception("Couldn't remove card from hand. Doesn't exist in hand.");
            }
        }

        public bool HasIchi()
        {
            return cardsInHand.Count() == 1;
        }

    }
}