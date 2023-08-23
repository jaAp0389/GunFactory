/*****************************************************************************
* Project: GunFactory
* File   : VectorRotationTest.cs
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
using UnityEngine;
using DebugGUIns;

/// <summary>
/// Another version of the rotater stuff.
/// </summary>
public class VectorRotationTest : MonoBehaviour
{
    public Vector2 _vec2;
    public float _angle;

    public Vector3 _vec3;
    public float _angleV3X, _angleV3Y, _angleV3Z;

    Vector3 v3Norm;

    void Awake()
    {
        CreateGUIlabels();
    }
    void FixedUpdate()
    {
        sinA = Mathf.DeltaAngle(_angleV3X, _angleV3Y);
        DrawGridRays();
        //DrawDebugRayV2(test, Color.white);
        //DrawDebugRayV2(RotateVector2(_vec2, _angle), Color.green);
        //DrawDebugRayV3(RotateV3aroundZ(RotateV3aroundX(RotateV3aroundY
        //    (_vec3, _angleV3Y), _angleV3X), _angleV3Z), Color.magenta);
        //DrawDebugRayV3(RotateV3aroundZ(RotateV3aroundX(RotateV3aroundY
        //    (_vec3.normalized, _angleV3Y), _angleV3X), _angleV3Z), Color.cyan);
        Vector3 v3;
        v3 = RotateV3aroundX(_vec3, _angleV3X);
        v3 = RotateV3aroundY(v3, _angleV3Y);
        v3 = RotateV3aroundZ(v3, _angleV3Z);
        DrawDebugRayV3(v3, Color.cyan);
        v3Norm = _vec3.normalized;
        UpdateGUIlabels();
    }
    Vector2 RotateVector2(Vector2 v2, float _angle)
    {
        float x, y;
        float cosA, sinA;
        _angle *= Mathf.Deg2Rad;
        cosA = Mathf.Cos(_angle);
        sinA = Mathf.Sin(_angle);
        x = v2.x * cosA - v2.y * sinA;
        y = v2.x * sinA + v2.y * cosA;
        return new Vector2(x, y);
    }
    void DrawDebugRayV2(Vector2 _rayV2, Color _color)
    {
        Debug.DrawRay(new Vector3(transform.position.x, transform.position.y, 
            transform.position.z-5), 
            new Vector3(_rayV2.x, 0, _rayV2.y), _color);
    }
    Vector3 RotateV3aroundX(Vector3 _v3, float _angle)
    {
        _angle *= Mathf.Deg2Rad;
        float cosA = Mathf.Cos(_angle),
              sinA = Mathf.Sin(_angle),
              y = _v3.y * cosA - _v3.z * sinA,
              z = _v3.y * sinA + _v3.z * cosA;
        return new Vector3(_v3.x, y, z);
    }
    Vector3 RotateV3aroundZ(Vector3 _v3, float _angle)
    {
        _angle *= Mathf.Deg2Rad;
        float cosA = Mathf.Cos(_angle),
              sinA = Mathf.Sin(_angle),
              x = _v3.x * cosA + _v3.y * sinA,
              y = -_v3.x * sinA + _v3.y * cosA;
        return new Vector3(x, y, _v3.z);
    }
    Vector3 RotateV3aroundY(Vector3 _v3, float _angle)
    {
        _angle *= Mathf.Deg2Rad;
        float cosA = Mathf.Cos(_angle),
              sinA = Mathf.Sin(_angle),
              x = _v3.x * cosA - _v3.z * sinA,
              z = _v3.x * sinA + _v3.z * cosA;
        return new Vector3(x, _v3.y, z);
    }
    void DrawDebugRayV3(Vector3 _rayV3, Color _color)
    {
        Debug.DrawRay(new Vector3(transform.position.x, transform.position.y,
        transform.position.z - 5), _rayV3, _color);
    }
    void DrawGridRays()
    {
        DrawDebugRayV2(new Vector2(2, 0), Color.red);
        DrawDebugRayV2(new Vector2(0, 2), Color.red);
        DrawDebugRayV2(new Vector2(-2, 0), Color.red);
        DrawDebugRayV2(new Vector2(0, -2), Color.red);
        DrawDebugRayV3(new Vector3(0, 2, 0), Color.blue);
        DrawDebugRayV3(new Vector3(0, -2, 0), Color.blue);
    }

    public DebugGUI debugGUI;
    FloatRef sin, cos;
    V3Ref v3Ref;
    float sinA;
    void CreateGUIlabels()
    {
        sin = new FloatRef(0f, "sin: ");
        debugGUI.AddGuiItem(_floatRef: sin);
        //cos = new FloatRef(0f, "cos: ");
        //debugGUI.AddGuiItem(_floatRef: cos);

        v3Ref = new V3Ref(v3Norm, "v3Norm: ");
        debugGUI.AddGuiItem(_v3Ref: v3Ref);
    }
    void UpdateGUIlabels()
    {
        //cos.Value = cosA;
        sin.Value = sinA;
        v3Ref.Value = v3Norm;
    }
}
