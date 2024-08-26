using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CircleBall
{
    /// <summary>
    /// Main scriptable object for managing different courts with their
    /// scritps attached to them
    /// </summary>
    /// 
    [CreateAssetMenu(fileName = "CourtStyle", menuName = "Scriptables/NewCourtStyle")]
    public class CourtStyle : ScriptableObject
    {
        // Use some prfabs
        public Court[] Courts;
        public Court CourtToUse { get; private set; }

        public void SetCourt(int courtIndex)
        {
            //return;
            CourtToUse = Courts[courtIndex];
        }
    }
}

