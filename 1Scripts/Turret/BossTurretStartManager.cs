/*****************************************************************************
* Project: GunFactory
* File   : BossTurretStartManager.cs
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

/// <summary>
/// BossHelperClass. Needs to turn on turrets after it finished 
/// the rasing animation.
/// </summary>
public class BossTurretStartManager : MonoBehaviour
{
    [SerializeField] TurretController mTurretController;
    [SerializeField] GameObject[] mGameObjects;

    public void TurnOnTurret()
    {
        mTurretController.ExecuteAction();
        foreach(GameObject gObject in mGameObjects)
        {
            gObject.SetActive(true);
        }
    }

}
