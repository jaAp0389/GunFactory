/*****************************************************************************
* Project: GunFactory
* File   : PushArea.cs
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
using UnityEngine;//abstract 

/// <summary>
/// Class for player pushing areas. Pushes in vector3 direction and force.
/// </summary>
public class PushArea : MonoBehaviour,ITrigger
{
    [SerializeField] private CharacterController mCharController;
    [SerializeField] private GameObject mInsideField;
    [SerializeField] ScreenColor mScreenColor;
    [SerializeField] private Vector3 mPush;

    private MeshRenderer meshRenderer;
    private void Awake()
    {
        meshRenderer = gameObject.GetComponent<MeshRenderer>();
    }
    public void TriggerEnter(Collider other)
    {
        meshRenderer.enabled = false;
        mInsideField.SetActive(true);
    }
    public void TriggerExit(Collider other)
    {

        meshRenderer.enabled = true;
        mInsideField.SetActive(false);

    }
    public void TriggerStay(Collider other)
    {
        mCharController.SimpleMove(mPush);
    }
}
