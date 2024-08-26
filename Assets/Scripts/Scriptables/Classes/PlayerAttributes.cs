using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CircleBall
{
    [CreateAssetMenu(fileName = "PlayerAttribute", menuName = "Scriptables/New Player Attribute")]
    public class PlayerAttributes : ScriptableObject
    {
        // ok so what we need is first of all, 2 things
        public float Speed;
        public float Strength;
        public float Accuracy;
        public float Defense;
        public float Agility;
    }
}