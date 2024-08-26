using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

namespace CircleBall
{
    public class ChoosePlayerTeamButton : MonoBehaviour
    {
        // as there will be total of 3 animations where we will stop
        // so for first 2, we need the plus sign and don't need it when we reach the 3rd one

        public int PlayerTypeCompleted;
        public static readonly int TotalPlayerTypes = 3;

        [Tooltip("As thre will be total of 3 player types per team so we need to animate them, make sure to assign them in a proper order with sequence")]
        [SerializeField] TMP_Text[] _textAnimators;
        [Tooltip("To separate the player types which are written and populated when the player keeps on clicking the buttons")]
        [SerializeField] TMP_Text[] _plusTextAnimations;
        [Tooltip("Delay between each animation")]
        [SerializeField] float _delay;
        [SerializeField] GameObject ConfirmScreen;
        [SerializeField] TMP_Text _selectedTeamText;
        [SerializeField] Image _darkBackgroundImage;
        [SerializeField] TMP_Text TeamDescriptionText;
        [SerializeField] Button StartBtnWhenTeamIsconfirmed;
        [SerializeField] Button NextButton;

        private bool Done = false;
        private string _selectedTeam = string.Empty;

        private void Awake()
        {
            NextButton.gameObject.SetActive(true);
            StartBtnWhenTeamIsconfirmed.gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            _darkBackgroundImage.enabled = false;
        }

        public void OnClick_PlayerType(string playerType)
        {
            if (Done) return;
            StartCoroutine(AnimationCoroutine(playerType));
        }

        IEnumerator AnimationCoroutine(string playerType)
        {

            _textAnimators[PlayerTypeCompleted].GetComponent<Animator>().CrossFade("Appear", .1f);
            _textAnimators[PlayerTypeCompleted].text = playerType;
            yield return new WaitForSeconds(_delay);
            if (PlayerTypeCompleted <= 1)
            {
                _plusTextAnimations[PlayerTypeCompleted].GetComponent<Animator>().CrossFade("Appear", .1f);
            }
            PlayerTypeCompleted++;

            // update the team as well
            if (PlayerTypeCompleted <= 2) _selectedTeam += playerType + " + ";
            else _selectedTeam += playerType;

            Done = PlayerTypeCompleted == 3 ? true : false;
        }


        public void OnClick_Next()
        {
            // Clicked when the player has confirmed all his team members
            if (Done == false) return; // can't open the confirm screen until we're not done with all the team members

            _darkBackgroundImage.enabled = true;

            ConfirmScreen.SetActive(true);

            _selectedTeamText.text = _selectedTeam;

            //TeamDescriptionText.text = GetTeamDescriptionText(); 


        }

        public void OnClick_Confirm()
        {
            NextButton.gameObject.SetActive(false);
            StartBtnWhenTeamIsconfirmed.gameObject.SetActive(true);
        }

        string GetTeamDescriptionText()
        {
            return "This combination focuses on fast gameplay with quick ball handling and mobility. It sacrifices strength for speed and agility.";
        }
    }

}