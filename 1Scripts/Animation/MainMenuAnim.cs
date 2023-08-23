/*****************************************************************************
* Project: GunFactory
* File   : MainMenuAnim.cs
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

public class MainMenuAnim : MonoBehaviour
{
    [SerializeField] Animation mAnimation;
    [SerializeField] string[] mAnimStrings;
    bool isForward = true, isUp = true;
    int ranMin = 0, ranMax = 10;

    private void Start()
    {
        OffsetNewAnim();
    }
    public void AnimFinished(int anim)
    {
        switch(anim)
        {
            case 0: isForward = false;
                    break;
            case 1: isForward = true;
                    break;
            case 2: isUp = false;
                    break;
            case 3: isUp = true;
                    break;
        }
        OffsetNewAnim();
    }

    void OffsetNewAnim()
    {
        float ran = Random.value * 15;
        Invoke("StartAnim", ran);
        print(ran);
    }
    void StartAnim()
    {
        bool isHorizontal = Random.Range(0, 10) > 4 ? true : false;
        int next = isHorizontal ? isForward ? 0 : 1 : isUp ? 2 : 3; 
        mAnimation.Play(mAnimStrings[next]);
        if(isHorizontal)
        {
            ranMin = 0;
            ranMax--;
        }
        else
        {
            ranMin++;
            ranMax = 0;
        }
        print(ranMin + "+max" + ranMax);
    }
}
