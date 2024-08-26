using UnityEngine;
using System;
using Cinemachine;


namespace CircleBall
{
    public class Court : MonoBehaviour
    {
        // use some settings like spawning point and other useful things for each court
        // each court will have its own camera, for the top view, near the goal nest

        public CinemachineVirtualCamera CourtTopViewCamera;
        public Transform PlayerPosition; // so we can set the player stand at this position
    }
}
