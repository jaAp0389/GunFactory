/*****************************************************************************
* Project: GunFactory
* File   : RotationController.cs
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
*   25.07.2021	JA	Created
******************************************************************************/
using System;
using UnityEngine;
//using gun;
//using DebugGUIns;

namespace DebugGUIns
{
    //[CustomEditor(typeof(RotationRestricted))]
    //[CanEditMultipleObjects]
    //public class RotEditor : Editor
    //{
    //    OnInspectorGUI()
    //    {
    //        DrawDefaultInspector();
    //        RotationRestricted tar = (RotationRestricted)target;
    //        void OnValidate()
    //        {
            
    //        }
            
    //    }
    //}

    /// <summary>
    /// Earlier Attempt at turretrotation
    /// </summary>
    [Serializable]
    public class RotationRestricted
    {
        public Transform body;

        public bool isGun;
        public bool isHorizontal;
        public bool isVertical;
        public float rangeL = 0f;
        [Range(0f, 360f)] public float rangeR = 90f;
        [Range(0f, 360f)] public float rotationSet = 0f;
        [SerializeField] public float rotationSpeed = 0.5f;
        public bool isReturnToStart;
        [NonSerialized] public float rangeLfinal;
        [NonSerialized] public float rangeRfinal;
        [NonSerialized] public bool isClockwise;
        [NonSerialized] public bool isRotating;
        [NonSerialized] public bool isOnTarget;
        [NonSerialized] public float ownRotation;

        public bool isDebug = false;

        private void Awake()
        {
            ownRotation = rangeR / 2 + rotationSet;
        }
        void OnValidate()
        {
            rangeLfinal = rangeL + rotationSet % 360;
            rangeRfinal = rangeR + rotationSet % 360;
        }
    }

    public class RotationController : MonoBehaviour
    {
        public Transform mTarget;

       // public GunTurretController gun;

        public RotationRestricted[] parts;
        bool shoot;

        private void Awake()
        {
            CreateGUIlabels();



        }
        void FixedUpdate()
        {
            foreach(RotationRestricted part in parts)
            {
                SetRotation(part);
                if (part.isDebug) DrawDebugRays(part);
                DoRotationStep(part);
                shoot = part.isOnTarget;
            }
            if (shoot) ShootGun();
            else StopGun();
            UpdateGUIlabels();
        }
        void SetRotation(RotationRestricted part)
        {
            part.rangeLfinal = LoopAngle(part.rangeL + part.rotationSet);
            part.rangeRfinal = LoopAngle(part.rangeR + part.rotationSet);
        }
        void DrawDebugRays(RotationRestricted part)
        {
            Vector3 forw = new Vector3(0, 0, 1);
            var lRotation = Quaternion.AngleAxis(part.rangeLfinal, Vector3.up);
            var rRotation = Quaternion.AngleAxis(part.rangeRfinal, Vector3.up);
            Debug.DrawRay(part.body.position, lRotation * forw, Color.blue);
            Debug.DrawRay(part.body.position, rRotation * forw, Color.red);
            Debug.DrawRay(part.body.position, part.body.forward *3, Color.magenta);
        }
        void DoRotationStep(RotationRestricted part)
        {
            float targetAngle = GetTargetAngle(mTarget, part.body, part.isVertical);
            if (isBetween(part.rangeLfinal, part.rangeRfinal, targetAngle))
                RotateTowardsDirection(part, targetAngle);
            else if (part.isRotating)
                part.isRotating = false;
            else part.isOnTarget = false;
        }
        float yvalue;
        float GetTargetAngle(Transform _target, Transform _self, bool isVertical)
        {
            Vector3 targetDirection = _target.position - _self.position;
            //targetDirection = targetDirection.normalized;
            if(isVertical)yvalue = targetDirection.y;
            if(isVertical) return yvalue;//ConvertAngle(Mathf.Atan2(targetDirection.y, targetDirection.z) * Mathf.Rad2Deg);
            return ConvertAngle(Mathf.Atan2(targetDirection.x,
                targetDirection.z) * Mathf.Rad2Deg);
        }
        float ConvertAngle(float _angle)
        {
            return _angle < 0 ? 360 + _angle : _angle;
        }
        /// <summary>
        /// stolen from:
        /// https://math.stackexchange.com/questions/1044905/simple-angle-between-two-angles-of-circle
        /// </summary>
        bool isBetween(float start, float end, float mid)
        {
            end = (end - start) < 0.0f ? end - start + 360.0f : end - start;
            mid = (mid - start) < 0.0f ? mid - start + 360.0f : mid - start;
            return (mid < end);
        }
        /// <summary>
        /// 
        /// </summary>
        float GetDistanceBetweenAngles(float _angleA, float _angleB)
        {
            //float dist = Mathf.Abs(_angleB - _angleA) % 360;
            //return dist > 180 ? 360 - dist : dist;
            float distance = (Mathf.DeltaAngle(_angleA, _angleB));
            return distance < 0 ? distance + 360 : distance;
        }
        void RotateTowardsDirection(RotationRestricted part, float _target)
        {
            float distanceTarget = GetDistanceBetweenAngles(part.ownRotation, _target);
            if (!part.isRotating && distanceTarget > 1)
            {
                part.isClockwise = GetDirectionToTarget(part.rangeLfinal, 
                        part.rangeRfinal, part.ownRotation, _target);
                part.isRotating = true;
            }
            if (distanceTarget > 1)
            {
                float rot = part.isClockwise ? part.rotationSpeed : -part.rotationSpeed;
                if (!part.isVertical) hMov = rot;
                part.ownRotation = part.ownRotation + (part.isClockwise ?
                        part.rotationSpeed : -part.rotationSpeed);
                part.ownRotation = LoopAngle(part.ownRotation);
                if (part.ownRotation < 0) 
                    part.ownRotation = 360 + part.ownRotation;
                RotateByDegree(part.body,  rot, part.isVertical);
                if (part.isGun) 
                    part.isOnTarget = false;
                return;
            }
            else { 
                part.isRotating = false;
                if (part.isGun) part.isOnTarget = true;
                } 
        }
        bool GetDirectionToTarget(float _angleA, float _angleB, 
            float _ownRotation, float _target)
        {
            float distanceA = GetDistanceBetweenAngles(_ownRotation, _angleA);
            float distanceB = GetDistanceBetweenAngles(_ownRotation, _angleB);
            float targetA = GetDistanceBetweenAngles(_target, _angleA);
            float targetB = GetDistanceBetweenAngles(_target, _angleB);
            bool isBorderA = targetA < targetB;
            return (isBorderA ? distanceA : targetB) <
                   (isBorderA ? targetA : distanceB);
        }
        float LoopAngle(float _angle)
        {
            return _angle % 360;
        }
        float hMov =0;

        void RotateByDegree(Transform _body, float _degree, bool isVertical)
        {
            //if (isVertical) vangle = _degree;
            //_body.transform.Rotate(isVertical? -_degree : 0, isVertical? 0 : _degree, 0, Space.Self);
            _body.transform.Rotate(isVertical? Vector3.right: Vector3.up, _degree);
        }
        void RotateToAngle(Transform _transform, float _angle, bool _isVertical)
        {
            if(_isVertical)_transform.rotation = Quaternion.Euler((yvalue * -50), transform.eulerAngles.y, transform.eulerAngles.z);
            else _transform.rotation = Quaternion.Euler(0,_angle, 0);
        }
        void ShootGun()
        {
            //gun.shoot = true;
        }
        void StopGun()
        {
            //gun.shoot = false;
        }
    



        public DebugGUI debugGUI;

        FloatRef yValueAngle;
        void CreateGUIlabels()
        {
            yValueAngle = new FloatRef(0f, "yValueP: ");
            debugGUI.AddGuiItem(_floatRef: yValueAngle);
        }
        void UpdateGUIlabels()
        {
            yValueAngle.Value = yvalue * -50;
        }
    }
}


