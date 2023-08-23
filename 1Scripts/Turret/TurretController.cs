/*****************************************************************************
* Project: GunFactory
* File   : TurretController.cs
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
/// Class to control turret targeting and rotation.
/// </summary>
public class TurretController : MonoBehaviour, IAction
{
    [SerializeField] Transform mBarrel, 
                               mBase, 
                               mMuzzle,
                               mRaycastOrigin;
    [SerializeField] float rotSpeedBase = 20, 
                           rotSpeedGun = 20, 
                           lowerClamp, 
                           upperClamp;

    [SerializeField] IGun mGun;
    [SerializeField] float shootRadius = 2f;
    [SerializeField] bool isTurretActive = true;
    [SerializeField] AudioSource mMetalGrind;
    bool metalGrindOff = false;

    float distanceTarget;
    bool isOnTargetV = false;
    bool isOnTargetH = false;

    private Transform mTarget;

    float mRaycastTimer;
    bool isTimeForRaycast = true;
    bool isTargetInCover = false;

    void Awake()
    {
        mTarget = FindObjectOfType<CharacterController>().transform;
        mRaycastTimer = Random.Range(0.2f, 0.4f);
        mGun = gameObject.GetComponent<IGun>();
        if (mMetalGrind == null) metalGrindOff = true;
    }
    void FixedUpdate()
    {
        if (isTurretActive) DoTurretLoop();
    }
    public void ExecuteAction()
    {
        SwitchTurretActive();
    }
    void SwitchTurretActive() => isTurretActive = !isTurretActive;
    /// <summary>
    /// The update loop of the turret class.
    /// </summary>
    void DoTurretLoop()
    {

        if (isTimeForRaycast)
        {
            isTargetInCover = CheckTargetInCover();
            isTimeForRaycast = false;
            Invoke("SetRaycastOnGo", mRaycastTimer);
        }

        if (isTargetInCover)
        {
            if(!metalGrindOff)
                if(mMetalGrind.isPlaying) mMetalGrind.Stop();
            return;
        }

        RotateTurret();
        
        if (isOnTargetH) RotateGun();

        if (CheckFire())
        {
            if (!metalGrindOff)
                if (mMetalGrind.isPlaying) mMetalGrind.Stop();
            mGun.Shoot();
        }
        else if (!metalGrindOff)
            if (!mMetalGrind.isPlaying) mMetalGrind.Play();
    }

    void SetRaycastOnGo() => isTimeForRaycast = true;
    /// <summary>
    /// Checks if the aim is on target both horizontal and vertical
    /// </summary>
    bool CheckFire()
    {
        return isOnTargetH && isOnTargetV;
    }
    /// <summary>
    /// Casts a ray to the target and checks if it hit the target or got 
    /// intersected by another object.
    /// </summary>
    /// <returns>Bool: Is target in cover?</returns>
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
    /// <summary>
    /// Rotates the turret horizontal towards the target. Checks angles just for
    /// the isOnTarget bool. Returns "is on target" when the angles differ slightly 
    /// so that the turret shoots (and misses) moving targets. The Turrets also 
    /// have bullet trajectory randomness and are to fill an area with bullets, 
    /// not pinpoint accuracy.
    /// </summary>
    void RotateTurret()
    {
        float targetAngleH = GetAngleToTargetH(mBase.position, mTarget.position);
        float ownAngle = GetAngleToTargetH(mBase.position, mMuzzle.position);
        float angleDifference = targetAngleH - ownAngle;
        if (Mathf.Abs(angleDifference) < shootRadius)
        { 
            isOnTargetH = true;
        }
        else isOnTargetH = false;

        Quaternion targetRot = Quaternion.LookRotation(new Vector3
            (mTarget.position.x, mBase.position.y, mTarget.position.z) 
            - mBase.position);

        if (targetRot == mBase.rotation) return;



        mBase.rotation = 
            Quaternion.RotateTowards(mBase.rotation, targetRot, 
            rotSpeedBase * Time.deltaTime);
    }

    /// <summary>
    /// Rotates the gun vertically. The function is different to the horizontal 
    /// one because i got confused by the gimbal system in vertical space. 
    /// There is a falloff for angle difference to target under 40 units 
    /// distance because otherwise the gun will wiggle overshooting the target  
    /// angle all the time. Above 40 units the player can't see this and shooting 
    /// accuratly becomes more important. Aim by angle would be exact but i 
    /// failed at that. At some point i thought i invested too much time into 
    /// this and it's good enough.
    /// </summary>
    void RotateGun()
    {
        float targetAngleV = GetAngleToTargetV (mBarrel.position, mTarget.position);

        if (targetAngleV > lowerClamp || targetAngleV < upperClamp)
        {
            isOnTargetV = false;
            return;
        }

        float ownAngle = GetAngleToTargetV (mBarrel.position, mMuzzle.position);
        float angleDiff = Mathf.Abs(ownAngle - targetAngleV);
        if (angleDiff < 1)
        {
            isOnTargetV = true;
        }
        else isOnTargetV = false;
        distanceTarget = Vector3.Distance(transform.position, mTarget.position);
        if(distanceTarget < 40)
            if(angleDiff < 0.4) return;

        bool isAbove = targetAngleV < ownAngle;

        Vector3 direction = 
            (isAbove ? Vector3.right : Vector3.left) * rotSpeedGun;

        mBarrel.Rotate( -direction * Time.deltaTime);

    }

    /// <summary>
    /// Returns the  vertical angle between 2 Vector3s. 
    /// Equation is from wikipedia.
    /// </summary>
    float GetAngleToTargetV(Vector3 _self, Vector3 _target)
    {
        Vector3 tarVec = new Vector3(_target.x, _self.y, _target.z);
        float dist = Vector3.Distance(_self, tarVec),
              distVert = _target.y - _self.y;
        return ConvertAngle(Mathf.Atan2(dist, distVert) * Mathf.Rad2Deg);
    }

    /// <summary>
    /// Returns the  horicontal angle between 2 Vector3s. 
    /// </summary>
    float GetAngleToTargetH(Vector3 _self, Vector3 _target)
    {
        Vector3 direction = _target - _self;
        return ConvertAngle(Mathf.Atan2(direction.x, direction.z)
            * Mathf.Rad2Deg);
    }
    /// <summary>
    /// Converts forthrunning angles to 360 angles.
    /// </summary>
    float ConvertAngle(float _angle)
    {
        return _angle < 0 ? 360 + _angle : _angle;
    }

}
