/*****************************************************************************
* Project: GunFactory
* File   : BoolToggleDuo.cs
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
*   25.08.2021	JA	Created
******************************************************************************/
using UnityEngine;
/// <summary>
/// Manages the Triggerzones for the AreaToggle class. Toggles the Bools.
/// </summary>
public class BoolToggleDuo : MonoBehaviour
{
    [SerializeField] bool mSwitch0, 
                          mSwitch1;
    AreaToggle mAreaToggle;

    private void Awake()
    {
        mAreaToggle = GetComponentInParent<AreaToggle>();
    }
    private void OnTriggerEnter(Collider other)
    {
        mAreaToggle.isTrigger0 = mSwitch0;
        mAreaToggle.isTrigger1 = mSwitch1;
        mAreaToggle.SwitchAreas();
    }

}
