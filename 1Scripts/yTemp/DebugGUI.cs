/*****************************************************************************
* Project: GunFactory
* File   : DebugGUIns.cs
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
/// Attempt at a debug gui.
/// </summary>
namespace DebugGUIns
{
    public class FloatRef
    {
        public float Value { get; set; }
        public string name { get; set; }
        public FloatRef(float _value, string _name)
        {
            Value = _value;
            name = _name;
        }
    }
    public class IntRef
    {
        public int Value { get; set; }
        public string name { get; set; }
        public IntRef(int _value, string _name)
        {
            Value = _value;
            name = _name;
        }
    }
    public class V3Ref
    {
        public Vector3 Value { get; set; }
        public string name { get; set; }
        public V3Ref(Vector3 _value, string _name)
        {
            Value = _value;
            name = _name;
        }
    }
    public class DebugGUI : MonoBehaviour
    {
        public GUIStyle style;
        public List<FloatRef> fList = new List<FloatRef>();
        public List<IntRef> iList = new List<IntRef>();
        public List<V3Ref> v3List = new List<V3Ref>();
        private void OnGUI()
        {
            int row = 0;
            foreach (FloatRef floatRef in fList)
            {
                GUI.Label(new Rect(300, row, 400, 100), floatRef.name + floatRef.Value, style);
                row += 15;
            }
            foreach (IntRef intRef in iList)
            {
                GUI.Label(new Rect(300, row, 400, 100), intRef.name + intRef.Value, style);
                row += 15;
            }
            foreach(V3Ref v3Ref in v3List)
            {
                GUI.Label(new Rect(300, row, 400, 100), v3Ref.name + v3Ref.Value, style);
                row += 15;
            }
        }
        public void AddGuiItem(FloatRef? _floatRef = null, 
            IntRef? _intRef = null, V3Ref? _v3Ref = null)
        {
            if (_floatRef != null) fList.Add(_floatRef);    
            else if(_intRef!= null) iList.Add(_intRef);
            else if (_v3Ref != null) v3List.Add(_v3Ref);
        }

    }
}
