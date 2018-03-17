using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerScript : MonoBehaviour
    {
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
}
