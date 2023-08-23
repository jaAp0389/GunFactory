/*****************************************************************************
* Project: GunFactory
* File   : RotationControllerNew.cs
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
*   05.08.2021	JA	Created
******************************************************************************/
using System;
using UnityEngine;

/// <summary>
/// I like serializable classes. I should use this more in the future. 
/// </summary>
[Serializable]
public class RotationData
{
    public Transform body;

    public bool isGun;
    public bool isHorizontal;
    public bool isVertical;
    public float rangeL = 0f;
    [Range(0f, 360f)] public float rangeR = 90f;
    [Range(0f, 360f)] public float rotationSet = 0f;
    public float rotationSpeed = 0.5f;
    public bool isReturnToStart;
    [NonSerialized] public float rangeLfinal;
    [NonSerialized] public float rangeRfinal;
    [NonSerialized] public bool isClockwise;
    [NonSerialized] public bool isRotating;
    [NonSerialized] public bool isOnTarget;
    [NonSerialized] public float ownRotation;

    //public bool isDebug = false;
}
/// <summary>
/// First try at turret rotation. For calculating direct rotations. I gave up 
/// after i couldn't get my head around it. It was eating too much time. 
/// It nearly worked. Sad.
/// </summary>
public class RotationControllerNew : MonoBehaviour
{

    //is target between borderangles-parent?
    //getdirection
    //rotate towards step
    //childrotation

    //state ontarget, moving, not in view

    public Transform mTarget;
    public Transform mSelfH, mSelfV;

    public RotationData[] parts;

    float angleV,
          angleH;

    float rangeHStart = 0f;
    [Range(0f, 360f)] public float rangeHEnd = 90f;
    [Range(0f, 360f)] public float rotationHSet = 0f;

    float rangeVStart = 0f;
    [Range(0f, 360f)] public float rangeVEnd = 90f;
    [Range(0f, 360f)] public float rotationVSet = 0f;
    //Get angle
    //lerp to angle
    //rotation
    float hAngleTarget, vAngleTarget, hAngleSelf = 0f, vAngleSelf = 0f,
          rotationSpeedH = 1f, rotationSpeedV = 0.2f, fallOffDist = 0.1f;
    Vector3 directionH = new Vector3(0, 0, 3), directionV;
    private void FixedUpdate()
    {
        RotationStep(mSelfH, mTarget);
    }
    void RotationStepB(Transform _self, Transform _target)
    {
        hAngleTarget = ConvertAngle
            (-GetAngleToTargetH(_self.position, _target.position));
        vAngleTarget = (GetAngleToTargetV(_self.position, _target.position)-90);
        Vector3 newDirection = new Vector3(0, 0, 3);
        newDirection = newDirection.RotateAroundX(vAngleTarget);
        newDirection = newDirection.RotateAroundY(hAngleTarget);
        RotateByVector(_self, newDirection);
        DrawDebugRayV3(newDirection, Color.blue);
    }
    /// <summary>
    /// It had some off angles. The negative GetAngle was a problem i think.
    /// I'd just have to calculate trough it some time.
    /// The problem was that everytime i solved some bug with this 2 new 
    /// ones showed up. Poorly planned.
    /// Not sure if this is the best solution. I just think if a few floats get 
    /// thrown around until a vector3 comes out it should be fast. Unity does 
    /// the same in build in functions but i can do checks with the angles. 
    /// Not even sure this is needed.
    /// </summary>
    void RotationStep(Transform _self, Transform _target)
    {
        hAngleTarget = ConvertAngle(-GetAngleToTargetH
            (mSelfH.position, mTarget.position));
        vAngleTarget = (GetAngleToTargetV
            (mSelfV.position, mTarget.position) - 90);
        float distTargetH = GetAngleDistance(hAngleSelf, hAngleTarget),
              distTargetV = GetAngleDistance(vAngleSelf, vAngleTarget);
        bool isOnTargetH = isOnTarget(distTargetH),
             isOnTargetV = isOnTarget(distTargetV);

        DrawDebugRayV3(directionH, Color.red);
        DrawDebugRayV3(directionV, Color.blue);

        if (isOnTargetH && isOnTargetV)
        {
            Fire();
            return;
        }
        if (!isOnTargetV)
        {
            float rotAngleTemp = GetNextRotationStep(rangeVStart, rangeVEnd,
                vAngleSelf, vAngleTarget, rotationSpeedV, distTargetV);
            directionV = directionH.RotateAroundX(rotAngleTemp);
            RotateByVector(mSelfV, directionV);
            vAngleSelf = LoopAngle(vAngleSelf+ rotAngleTemp);
        }

        if (!isOnTargetH)
        {
            float rotAngleTemp = GetNextRotationStep(rangeHStart, rangeHEnd,
                hAngleSelf, hAngleTarget, rotationSpeedH, distTargetH);
            directionH = new Vector3(0, 0, 3).RotateAroundY(rotAngleTemp);
            RotateByVector(mSelfH, directionH);
            hAngleSelf = LoopAngle(hAngleSelf + rotAngleTemp);
        }
        
    }
    void Fire()
    {

    }

    bool isOnTarget(float _distTarget)
    {
        if (_distTarget < fallOffDist) return true;
        return false;
    }

    float GetNextRotationStep(float _borderAngleA, float _borderAngleB, 
        float _ownAngle, float _targetAngle, float _rotationSpeed, 
        float _distTarget)
    {
        bool isTargetPlus = DirectionToTarget(_borderAngleA, _borderAngleB,
            _ownAngle, _targetAngle);
        bool isClose = _distTarget < _rotationSpeed;
        return LoopAngle(_ownAngle + (isClose ?_distTarget : _rotationSpeed 
            * (isTargetPlus ? 1 : -1)));
    }

    bool DirectionToTarget(float _borderAngleA, float _borderAngleB,
    float _ownAngle, float _targetAngle)
    {
        float distanceA = GetAngleDistance(_ownAngle, _borderAngleA);
        float distanceB = GetAngleDistance(_ownAngle, _borderAngleB);
        float targetA = GetAngleDistance(_targetAngle, _borderAngleA);
        float targetB = GetAngleDistance(_targetAngle, _borderAngleB);
        bool isBorderA = targetA < targetB;
        return (isBorderA ? distanceA : targetB) <
               (isBorderA ? targetA : distanceB);
    }

    /////////////////////

    float GetAngleToTargetH(Vector3 _self, Vector3 _target)
    {
        Vector3 direction = _target - _self;
        return ConvertAngle(Mathf.Atan2(direction.x, direction.z) 
            * Mathf.Rad2Deg);
    }

    float GetAngleToTargetV(Vector3 _self, Vector3 _target)
    {
        Vector3 tarVec = new Vector3(_target.x, _self.y, _target.z);
        float dist = Vector3.Distance(_self, tarVec),
              distVert = _target.y - _self.y;
        return ConvertAngle(Mathf.Atan2(dist, distVert)* Mathf.Rad2Deg);
    }

    void RotateByVector(Transform _self, Vector3 _direction)
    {
        _self.rotation = Quaternion.LookRotation(_direction);
    }

    /// <summary>
    /// liberated from:
    /// https://math.stackexchange.com/questions/1044905/simple-angle-between-two-angles-of-circle
    /// </summary>
    bool isBetweenAngles(float start, float end, float mid)
    {
        end = (end - start) < 0.0f ? end - start + 360.0f : end - start;
        mid = (mid - start) < 0.0f ? mid - start + 360.0f : mid - start;
        return (mid < end);
    }

    float ConvertAngle(float _angle)
    {
        return _angle < 0 ? 360 + _angle : _angle;
    }

    float LoopAngle(float _angle)
    {
        return _angle % 360;
    }

    float GetAngleDistance(float _angleA, float _angleB)
    {
        return Mathf.DeltaAngle(_angleA, _angleB);
    }

    //------



    //------
    void DrawDebugRayV3(Vector3 _rayV3, Color _color)
    {
        Debug.DrawRay(new Vector3(transform.position.x, transform.position.y,
        transform.position.z), _rayV3, _color);
    }

    public GUIStyle style;
    void OnGUI()
    {
        GUI.Label(new Rect(300, 30, 400, 100), "hori:" + hAngleTarget, style);
        GUI.Label(new Rect(300, 45, 400, 100), "ver:" + vAngleTarget, style);
    }
}

//https://github.com/brihernandez/GunTurrets/tree/master/Assets/GunTurrets/Scripts
