using UnityEngine;

/// <summary>
/// From https://answers.unity.com/questions/924502/unity-5-giving-errors-on-older-project-do-not-use.html
/// Antwort "dizzy2003" 
/// </summary>
public class ShowNullMeshFiltersClass : MonoBehaviour
{
    private void Awake()
    {
        ShowNullMeshFilters();
    }
    static void ShowNullMeshFilters()
    {
        var res = GameObject.FindObjectsOfType<MeshFilter>();
        //dreaded Do not use ReadObjectThreaded on scene objects!
        foreach (var nmo in res)
        {
            if (nmo.sharedMesh == null)
            {
                Debug.LogError("null meshfilter in " + nmo.transform.name , nmo.gameObject);
                Transform t = nmo.transform;
                GameObject.DestroyImmediate(t.GetComponent<MeshRenderer>());
                GameObject.DestroyImmediate(nmo);

            }
        }
        res = null;
    }
}
