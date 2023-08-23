/*****************************************************************************
* Project: GunFactory
* File   : CheckCover.cs
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
*   20.08.2021	JA	Created
******************************************************************************/
using UnityEngine;

/// <summary>
/// Extra CheckCover class. Copy from the Turret Controller. This class is for 
/// turrets that are lowered into ground to check if they could shoot the player
/// if they peek out. They will also duck back into the floor when they can't 
/// hit the player. I made this because you could shoot turrets in an angle 
/// where they couldn't shoot back. But it doesn't influence the gameplay much.
/// </summary>
public class CheckCover : MonoBehaviour, IAction
{
    [SerializeField] Transform mRaycastOrigin;
    [SerializeField] HealthInfo mHealthInfo;
    [SerializeField] GameObject mReceiver;
    [SerializeField] bool mAutoStart = false;

    IAction mAction;
    Transform mTarget;
    float mRaycastTimer;

    bool isTimeForRaycast = false, 
         isTargetInCover = true, 
         isTargetInCoverLast = true;

    void Awake()
    {
        mAction = mReceiver.GetComponent<IAction>();
        mTarget = FindObjectOfType<CharacterController>().transform;
        mRaycastTimer = Random.Range(0.2f, 0.4f);
        if (mAutoStart) SetRaycastOnGo();
    }
    private void FixedUpdate()
    {
        if (isTimeForRaycast)
        {
            if (mHealthInfo.isAlive == false) Destroy(gameObject); 
            isTargetInCover = CheckTargetInCover();
            isTimeForRaycast = false;

            Invoke("SetRaycastOnGo", mRaycastTimer);

            if (isTargetInCover != isTargetInCoverLast) 
            { 
                mAction.ExecuteAction();
                isTargetInCoverLast = isTargetInCover;
            }
        }
            

    }
    void SetRaycastOnGo() => isTimeForRaycast = true;
    public void ExecuteAction() => isTimeForRaycast = true;

    bool CheckTargetInCover()
    {
        mRaycastOrigin.LookAt(mTarget);

        if(Physics.Raycast(mRaycastOrigin.position, mRaycastOrigin.
            TransformDirection(Vector3.forward), out RaycastHit hit, 500f))
            if (hit.collider.transform == mTarget) return false;

        return true;
        //Debug.DrawRay(mRaycastOrigin.position, mRaycastOrigin.
        //  TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
    }
}
