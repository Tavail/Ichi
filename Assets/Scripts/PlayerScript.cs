using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // Create the player class Cause Unity is a cunt
    public class Player
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

    private Player player;
    public string playerName;

    // Use this for initialization
    void Start()
    {
        Player Player = new Player(playerName);
    }

    // Update is called once per frame
    void Update()
    {
        

    }
}
