/*****************************************************************************
* Project: GunFactory
* File   : BangScript.cs
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
*   22.08.2021	JA	Created
******************************************************************************/
using UnityEngine;

public class BangScript : MonoBehaviour
{
    //[SerializeField] private TextMesh tMesh;
    [SerializeField] ParticleSystem mExplosion;
    [SerializeField] float mLifetime = 0.1f;
    private void Awake()
    {
        mExplosion.Play();
        Destroy(gameObject, mLifetime);
    }
    //private void Update()
    //{
    //    tMesh.characterSize += 2f * Time.deltaTime;
    //}
}
