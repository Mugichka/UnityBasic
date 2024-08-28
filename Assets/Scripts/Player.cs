using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public enum Team
    {
        Red,
        Blue,
        None
    }

    public class Player : MonoBehaviour
    {
        [SerializeField] private Team team;
        [SerializeField] private Material playerMaterial;
        [SerializeField] private Material playerEnemy;
        [SerializeField] private Material playerAlly;

        public Team Team
        {
            get => team;
            set
            {
                team = value;
                SetColor();
            }
        }

        public int Health { get; private set; }
        public bool IsDead => !CheckIfAlive();
        private int BaseDamage { get; set; }
        private float Multiplier { get; set; }
        private List<string> Weapons { get; set; }

        private void Start()
        {
            SetColor();
        }

        private void SetColor()
        {
            MeshRenderer meshRenderer = gameObject.GetComponent<MeshRenderer>();
            if (meshRenderer != null)
            {
                switch (Team)
                {
                    case Team.Red:
                        meshRenderer.material = playerEnemy;
                        break;
                    case Team.Blue:
                        meshRenderer.material = playerAlly;
                        break;
                    default:
                        meshRenderer.material = playerMaterial;
                        break;
                }
            }
            else
            {
                Debug.LogWarning("MeshRenderer component not found on the GameObject.");
            }
        }

        private void OnValidate()
        {
            SetColor();
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
            if (Health < 0)
            {
                Health = 0;
            }
            Debug.Log($"Player took {damage}");
            Debug.Log($"Player health is {Health}");
            Debug.Log($"Is player alive? {CheckIfAlive()}");
        }

        public float Attack()
        {
            return BaseDamage * Multiplier;
        }

        private bool CheckIfAlive()
        {
            return Health > 0;
        }
    }
}