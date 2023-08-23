/*****************************************************************************
* Project: GunFactory
* File   : ExtensionMethods.cs
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
*   04.08.2021	JA	Created
******************************************************************************/
using UnityEngine;
/// <summary>
/// Class to rotate vectors by angle. Equations from wikipedia.
/// I abandoned this.
/// </summary>
public static class ExtensionMethods
{
    public static Vector2 RotateByAngle(this Vector2 _v2, float _angle)
    {
        _angle *= Mathf.Deg2Rad;
        float cosA = Mathf.Cos(_angle),
              sinA = Mathf.Sin(_angle),
              x = _v2.x * cosA - _v2.y * sinA,
              y = _v2.x * sinA + _v2.y * cosA;
        //_v2.x = x; _v2.y = y;
        return new Vector2(x, y);
    }
    public static Vector3 RotateAroundX(this Vector3 _v3, float _angle)
    {
        _angle *= Mathf.Deg2Rad;
        float cosA = Mathf.Cos(_angle),
              sinA = Mathf.Sin(_angle),
              y = _v3.y * cosA - _v3.z * sinA,
              z = _v3.y * sinA + _v3.z * cosA;
        return new Vector3(_v3.x, y, z);
    }
    public static Vector3 RotateAroundZ(this Vector3 _v3, float _angle)
    {
        _angle *= Mathf.Deg2Rad;
        float cosA = Mathf.Cos(_angle),
              sinA = Mathf.Sin(_angle),
              x = _v3.x * cosA + _v3.y * sinA,
              y = -_v3.x * sinA + _v3.y * cosA;
        return new Vector3(x, y, _v3.z);
    }
    public static Vector3 RotateAroundY(this Vector3 _v3, float _angle)
    {
        _angle *= Mathf.Deg2Rad;
        float cosA = Mathf.Cos(_angle),
              sinA = Mathf.Sin(_angle),
              x = _v3.x * cosA - _v3.z * sinA,
              z = _v3.x * sinA + _v3.z * cosA;
        return new Vector3(x, _v3.y, z);
    }
}
