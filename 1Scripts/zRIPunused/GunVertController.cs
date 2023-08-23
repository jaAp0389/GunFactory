/*****************************************************************************
* Project: GunFactory
* File   : GunVertController.cs
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
*   04.08.2021	JA	Created
******************************************************************************/
using UnityEngine;

/// <summary>
/// Attempt at vertical gun rotation.
/// </summary>
public class GunVertController : MonoBehaviour
{
    public Transform mTarget;
    public Transform rotationHelper;
    public float damping = 0.5f;

    private void FixedUpdate()
    {
        RotateGunToTarget();
    }
    void RotateGunToTarget()
    {
        var lookPos = 
            (mTarget.position - transform.position);
        var lookPosH = 
            (rotationHelper.position - transform.position).normalized;
        var lpos = new Vector3(lookPos.x, lookPos.y, lookPos.z);
        var rotation = Quaternion.LookRotation
            (lookPos);
        transform.rotation = Quaternion.Slerp
            (transform.rotation, rotation, Time.deltaTime * damping);
    }
}
