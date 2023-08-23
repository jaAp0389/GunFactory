/*****************************************************************************
* Project: GunFactory
* File   : PauseMenu.cs
* Date   : 26.08.2021
* Author : Jan Apsel (JA)
*
* These coded instructions, statements, and computer programs contain
* proprietary information of the author and are protected by Federal
* copyright law. They may not be disclosed to third parties or copied
* or duplicated in any form, in whole or in part, without the prior
* written consent of the author.
*
* History:
*   26.08.2021	JA	Created
******************************************************************************/
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
/// <summary>
/// Manages pause menu
/// </summary>
public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject mPauseMenu, mSliderGO;
    [SerializeField] AudioListener mAudioListener;
    [SerializeField] Slider mSlider;
    bool isPause = true;
    bool isAudioSliderActivate = true;
    public bool isPauseOn { private get; set; } = true;
    private void Update()
    {
        if(isPauseOn)
            if(Input.GetButtonDown("Cancel"))
            {
                PauseGame();
            }
    }
    public void ContinueButton()
    {
        PauseGame();
    }
    public void ReturnToMenuButton()
    {
        SceneManager.LoadScene(0);
    }
    public void SwitchAudioButton()
    {
        mSliderGO.SetActive(isAudioSliderActivate);
        isAudioSliderActivate = !isAudioSliderActivate;
    }
    public void AudioSlider()
    {
        AudioListener.volume = mSlider.value;
    }
    void PauseGame()
    {
        mSliderGO.SetActive(false);
        isAudioSliderActivate = true;
        Cursor.lockState = isPause ? CursorLockMode.None : CursorLockMode.Locked;
        Time.timeScale = isPause ? 0 : 1;
        mAudioListener.enabled = !isPause; 
        mPauseMenu.SetActive(isPause);
        isPause = !isPause;
    }
}
