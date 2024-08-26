using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CircleBall
{
    /// <summary>
    /// This class most likely represents the role of each player that has been selected
    /// i.e either Offense or Defense
    /// </summary>
    /// 
    [CreateAssetMenu(fileName = "PlayerRole", menuName = "Scriptables/New Player Role")]
    public class PlayerRole : ScriptableObject
    {
        public enum PlayerRoleType
        {
            Offense, Defense, None
        }
        public PlayerRoleType M_PlayerRoleType;

        [Tooltip("So when the player role is offense, it can have different attributes like speed and strength and when its defense, it can have different.")]
        public PlayerAttributes M_PlayerAttributesOffense;
        public PlayerAttributes M_PlayerAttributesDefense;

        /// <summary>
        /// So based on the player role whether offense or defense, this main attribute will be used, work with the enum to change the player role, defined above
        /// </summary>
        public PlayerAttributes _playerMainAttributes;

        // validating the object
        private void OnValidate()
        {
            _playerMainAttributes = M_PlayerRoleType == PlayerRoleType.Offense ? M_PlayerAttributesOffense : M_PlayerAttributesDefense;
        }
    }
}
