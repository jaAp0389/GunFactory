/*****************************************************************************
* Project: GunFactory
* File   : ActionTrigger.cs
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
*   17.08.2021	JA	Created
******************************************************************************/
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Triggers Iactions on list of objects
/// </summary>
public class ActionTrigger : MonoBehaviour
{
    [SerializeField] GameObject[] mTarget;
    [SerializeField] bool triggerOnce = true;
    List<IAction> mActions = new List<IAction>();
    
    private void Awake()
    {
        foreach(GameObject target in mTarget)
            mActions.AddRange(target.GetComponents<IAction>());
    }
    private void OnTriggerEnter(Collider other)
    {
        foreach (IAction action in mActions)
            action.ExecuteAction();
        if (triggerOnce) Destroy(gameObject);
    }
}
