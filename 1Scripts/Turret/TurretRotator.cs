/*****************************************************************************
* Project: GunFactory
* File   : TurretRotator.cs
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
using System.Collections;
using UnityEngine;

public class TurretRotator : MonoBehaviour
{
    [SerializeField] Transform mTurret;
    [SerializeField] float mSpeed;
    [SerializeField] bool aroundRight, rotateOnAwake;
    Vector3 direction;

    private void Start()
    {
        direction = (aroundRight ? Vector3.up : Vector3.down) * mSpeed;
        if (rotateOnAwake)
            StartRotate();
    }
    public void StartRotate()
    {
        StartCoroutine(RotateTurret());
    }
    public void EndRotate()
    {
        StopAllCoroutines();
    }
    IEnumerator RotateTurret()
    {
        while(true)
        {
            mTurret.Rotate(-direction * Time.deltaTime);
            yield return new WaitForFixedUpdate();
        }
    }
}
