/*****************************************************************************
* Project: GunFactory
* File   : DeactivateOnAwake.cs
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
/// For the areas so i don't have to disable them in the editor.
/// </summary>
public class DeactivateOnAwake : MonoBehaviour
{
    [SerializeField] bool mActive;
    private void Awake()
    {
        gameObject.SetActive(mActive);
    }
}
