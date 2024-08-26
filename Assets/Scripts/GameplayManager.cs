using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

namespace CircleBall
{
    /// <summary>
    /// handles most of the gameplay things
    /// </summary>
    public class GameplayManager : Singleton<GameplayManager>
    {
        [SerializeField] CourtStyle m_courtStyle;
        [SerializeField] Transform m_courtSpawnPoint;
        [SerializeField] GameObject PlayerPrefab;  // Later on players will have a different script
        [SerializeField] CinemachineVirtualCamera m_mainVcam;
        [SerializeField] bool m_spawnPlayer = false;

        void Start()
        {

            Invoke(nameof(SetupCourt), .5f);
            //SetupCourt();
        }

        void SetupCourt()
        {
            m_mainVcam.Priority = 9;

            var court = m_courtStyle.Courts[0];
            var spawnedCourt = Instantiate(court, this.m_courtSpawnPoint.position, Quaternion.identity);
            var spawnedPlayer = Instantiate(PlayerPrefab, spawnedCourt.PlayerPosition.position, Quaternion.identity);
            spawnedPlayer.transform.SetParent(spawnedCourt.PlayerPosition);
            spawnedPlayer.transform.localPosition = Vector3.zero;

            // set the rotation of the player as well
            var direction = spawnedCourt.PlayerPosition.transform.forward.normalized;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            spawnedPlayer.transform.rotation = lookRotation;

            spawnedPlayer.SetActive(m_spawnPlayer);
        }
    }

}