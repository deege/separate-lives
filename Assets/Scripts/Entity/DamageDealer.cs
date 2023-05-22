using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Deege.Game.Entity
{
    public class DamageDealer : MonoBehaviour
    {
        [SerializeField] public int damage = 10;

        public int GetDamage()
        {
            return damage;
        }
    }

}