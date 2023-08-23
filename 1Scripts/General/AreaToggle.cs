/*****************************************************************************
* Project: GunFactory
* File   : AreaToggle.cs
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

/// <summary>
/// De/activates areas by triggerzones in between them. 2  triggerzone pairs to 
/// check which direction the play is walking trough.
/// </summary>
public class AreaToggle : MonoBehaviour
{
    [SerializeField]
    GameObject mArea01,
               mArea10;
    public bool isTrigger0 { private get; set; } = true;
    public bool isTrigger1 { private get; set; } = true;
    public void SwitchAreas()
    {
        if(isTrigger0 && !isTrigger1)
        {
            mArea01.SetActive(true);
            mArea10.SetActive(false);
        }
        if (isTrigger0 && isTrigger1)
        {
            mArea01.SetActive(true);
            mArea10.SetActive(true);
        }
        if (!isTrigger0 && isTrigger1)
        {
            mArea01.SetActive(false);
            mArea10.SetActive(true);
        }
    }
}
