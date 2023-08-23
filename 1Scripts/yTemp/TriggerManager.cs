/*****************************************************************************
* Project: GunFactory
* File   : TriggerManager.cs
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
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class to unify triggercalls. I mainly wrote this for triggercalls 
/// from another gameobject. 
/// </summary>
public class TriggerManager : MonoBehaviour
{
    [SerializeField]private GameObject[] mTriggerObjects;
    private ITrigger[] mITriggers;
    private List<ITrigger> mTriggerList = new List<ITrigger>();
    bool mIsTriggerListEmpty = true;

    /// <summary>
    /// Automatically collects all triggerables from the object it is on and
    /// from the objectlist because you can't assign interfaces in the inspector
    /// easily.
    /// </summary>
    private void Awake()
    {
        mITriggers = GetComponents<ITrigger>();
        foreach(GameObject triggerObject in mTriggerObjects)
        {
            ITrigger triggerTemp = triggerObject.GetComponent<ITrigger>();
            if (triggerTemp != null) mTriggerList.Add(triggerTemp);
        }
        if (mTriggerList.Count > 0) mIsTriggerListEmpty = false;

    }
    private void OnTriggerEnter(Collider other)
    {
        foreach(ITrigger trigger in mITriggers)
        {
            trigger.TriggerEnter(other);
        }
        foreach (ITrigger trigger in mTriggerList)
        {
            trigger.TriggerEnter(other);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        foreach (ITrigger trigger in mITriggers)
        {
            trigger.TriggerExit(other);
        }
        foreach (ITrigger trigger in mTriggerList)
        {
            trigger.TriggerExit(other);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        foreach (ITrigger trigger in mITriggers)
        {
            trigger.TriggerStay(other);
        }
        foreach (ITrigger trigger in mTriggerList)
        {
            trigger.TriggerStay(other);
        }
    }
}
