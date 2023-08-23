/*****************************************************************************
* Project: GunFactory
* File   : TextureMove.cs
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

/// <summary>
/// Class to move textures (materials) in a vector2 direction.
/// </summary>
public class TextureMove : MonoBehaviour
{
    [SerializeField] Vector2 mOffsetAdd;
    Vector2 mOffset;
    Material mMaterial;

    private void Awake()
    {
        mMaterial = gameObject.GetComponent<MeshRenderer>().material;
        StartCoroutine(MoveTexture());
    }

    IEnumerator MoveTexture()
    {
        while(true)
        {
            mOffset += mOffsetAdd * Time.deltaTime;

            mMaterial.mainTextureOffset = mOffset;

            yield return new WaitForFixedUpdate();
        }
    }
}
