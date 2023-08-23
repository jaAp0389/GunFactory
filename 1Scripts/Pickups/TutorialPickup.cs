/*****************************************************************************
* Project: GunFactory
* File   : TutorialPickup.cs
* Date   : 27.08.2021
* Author : Jan Apsel (JA)
*
* These coded instructions, statements, and computer programs contain
* proprietary information of the author and are protected by Federal
* copyright law. They may not be disclosed to third parties or copied
* or duplicated in any form, in whole or in part, without the prior
* written consent of the author.
*
* History:
*   27.08.2021	JA	Created
******************************************************************************/
using UnityEngine;

public class TutorialPickup : MonoBehaviour, IPickupAction
{
    [TextArea(15, 20)]
    [SerializeField] string mTutorialMessage;
    [SerializeField] GameObject mTutorialModelGO;
    TMPro.TextMeshProUGUI mTutorialTextBox;
    GameObject mTutorialGO;
    TutorialContainer tutorialContainer;
    AudioListener mAudioListener;

    private void Awake()
    {
        tutorialContainer = gameObject.GetComponentInParent<TutorialContainer>();
        mAudioListener = tutorialContainer.MAudioListener;
        mTutorialGO = tutorialContainer.MTutorialGO;
        mTutorialTextBox = tutorialContainer.MTutorialTextBox;
    }
    public void OnPickup(GameObject target)
    {
        PauseGame();
        mTutorialModelGO.SetActive(false);
        Destroy(gameObject, 0.1f);
    }
    void PauseGame()
    {
        mTutorialTextBox.text = mTutorialMessage;
        mTutorialGO.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        tutorialContainer.IsTutorialTime = true;
        tutorialContainer.MAudioVolume = AudioListener.volume;
        Time.timeScale =  0;
        mAudioListener.enabled = false;
        //AudioListener.volume = 0;
    }
}
