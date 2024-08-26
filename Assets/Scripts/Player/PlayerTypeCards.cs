using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;
using UnityEngine.UI;

namespace CircleBall.Player
{
    public class PlayerTypeCards : MonoBehaviour
    {
        [SerializeField] GameObject[] m_toHide;
        [SerializeField] GameObject[] m_toShow;


        private Button m_button;
        private Image m_image;
        private AudioSource m_clickSound;

        void Start()
        {
            m_button = GetComponent<Button>();
            m_image = GetComponent<Image>();

            m_button.onClick.AddListener(OnClick);

            m_clickSound = FindObjectOfType<AudioSource>();
        }

        public void OnClick()
        {
            if (m_clickSound != null) m_clickSound.Play();

            // Pop-up animation
            Sequence popupSequence = DOTween.Sequence();

            // Scale up to 1.2 times the original size
            popupSequence.Append(m_image.transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 0.2f));

            // Scale back to original size
            popupSequence.Append(m_image.transform.DOScale(Vector3.one, 0.2f));

            // Add a callback to show the objects after the animation completes
            popupSequence.OnComplete(() =>
            {
                // Hide objects
                foreach (GameObject obj in m_toHide)
                {
                    obj.SetActive(false);
                }

                // Show objects
                foreach (GameObject obj in m_toShow)
                {
                    obj.SetActive(true);
                }
            });
        }
    }
}
