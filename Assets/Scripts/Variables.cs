using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class Variables : MonoBehaviour
    {
        Player player = new Player(1337, 10);
        void Start()
        {
            print($"Player attacks for {player.Attack()}");
            player.TakeDamage(20);
            player.ShowAllWeapons();

            player.AddWeapon("Bow");
            player.ShowAllWeapons();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }

    class Player
    {
        public int Health { get; private set; }
        private int BaseDamage { get; set; }
        private float Multiplier { get; set; }
        private List<string> Weapons { get; set; }

        public Player(int health = 100, int damage = 10, float multiplier = 3.14f, List<string> weapons = null)
        {
            Health = health;
            BaseDamage = damage;
            Multiplier = multiplier;
            Weapons = weapons ?? new List<string> { "Sword", "Axe" };
        }

        public void ShowAllWeapons()
        {
            foreach (var weapon in Weapons)
            {
                Debug.Log(weapon);
            }
        }

        public void AddWeapon(string weapon)
        {
            Weapons.Add(weapon);
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            Debug.Log($"Player took {damage}");
            Debug.Log($"Player health is {Health}");
            Debug.Log($"Is player alive? {IsAlive()}");
        }

        public float Attack()
        {
            return BaseDamage * Multiplier;
        }

        private bool IsAlive()
        {
            return Health > 0;
        }
    }
}