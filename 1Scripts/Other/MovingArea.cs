/*****************************************************************************
* Project: GunFactory
* File   : MovingArea.cs
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
*   16.08.2021	JA	Created
******************************************************************************/
using UnityEngine;

/// <summary>
/// For the moving platforms to parent the player but it is still lagging with a 
/// character controller. I didn't use horizontal moving platforms because of 
/// this.
/// </summary>
public class MovingArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.transform.SetParent(transform);
    }
    private void OnTriggerExit(Collider other)
    {
        other.gameObject.transform.SetParent(null);
    }
}
