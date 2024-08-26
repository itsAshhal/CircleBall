using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


namespace CircleBall
{
    public class UI_AnimationWithWait : MonoBehaviour
    {
        [Tooltip("So when the first animation ends, the next will start after this time")]
        public float NextAnimationWaitTime;

        public bool IsFirstApproach = true;  // so we can come back to the same position
        [SerializeField] string[] AnimationStateNamesFirstApproach;
        [SerializeField] string[] AnimationStateNamesSecondApproach;
        public Animator ReferenceAnimator;
        Button btn;

        private void OnEnable()
        {
            //ReferenceAnimator = GetComponent<Animator>();
            TryGetComponent<Button>(out Button btn);
            if (btn == null) return;

            btn.onClick.AddListener(OnButtonClick);
            this.btn = btn;
        }

        public void OnButtonClick()
        {
            StartCoroutine(AnimationCoroutine());
        }

        IEnumerator AnimationCoroutine()
        {
            this.btn.interactable = false;

            if (IsFirstApproach)
            {
                foreach (var state in AnimationStateNamesFirstApproach)
                {
                    ReferenceAnimator.CrossFade(state, .1f);
                    yield return new WaitForSeconds(NextAnimationWaitTime);
                }

            }
            else
            {
                foreach (var state in AnimationStateNamesSecondApproach)
                {
                    ReferenceAnimator.CrossFade(state, .1f);
                    yield return new WaitForSeconds(NextAnimationWaitTime);
                }
            }
            IsFirstApproach = !IsFirstApproach;
            this.btn.interactable = true;
        }
    }

}