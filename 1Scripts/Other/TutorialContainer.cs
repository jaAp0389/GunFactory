/*****************************************************************************
* Project: GunFactory
* File   : TutorialContainer.cs
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

public class TutorialContainer : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI mTutorialTextBox;
    [SerializeField] GameObject mTutorialTextBoxGO;
    [SerializeField] AudioListener mAudioListener;
    float mAudioVolume = 1;
    bool isTutorialTime = true;
    public AudioListener MAudioListener { get { return mAudioListener; } private set { } }
    public float MAudioVolume { private get { return mAudioVolume; } set { mAudioVolume = value; } }
    public bool IsTutorialTime { private get { return isTutorialTime; } set { isTutorialTime = value; } }
    public TMPro.TextMeshProUGUI MTutorialTextBox { get { return mTutorialTextBox; } private set { } }
    public GameObject MTutorialGO { get { return mTutorialTextBoxGO; } private set { } }

    private void Update()
    {
        if (!isTutorialTime) return;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isTutorialTime = false;
                mTutorialTextBoxGO.SetActive(false);
                Time.timeScale = 1;
                //AudioListener.volume = mAudioVolume;
                mAudioListener.enabled = true;
                Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
