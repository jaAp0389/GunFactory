/*****************************************************************************
* Project: GunFactory
* File   : ObjectSpawner.cs
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
using UnityEngine;

/// <summary>
/// Performance test on how many objects i can use until the framerate drops.
/// Around 1500.
/// </summary>
public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] mGameObjects;
    [SerializeField] Vector2 mRadius;
    [SerializeField] int mAmount;
    [SerializeField] int mSpawned = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
            SpawnMultipleObjects(mAmount);
    }

    void SpawnMultipleObjects(int _amount)
    {
        for (int i = 0; i < _amount; i++)
            SpawnObjects();
    }
    void SpawnObjects()
    {
        foreach(GameObject gObject in mGameObjects)
        {
            mSpawned++;
            Transform gPosition = transform;
            gPosition.position = new Vector3(Random.Range(0f, mRadius.x), 
                transform.position.y, Random.Range(0f, mRadius.y));
            Instantiate(gObject, gPosition);
            Random.InitState(mSpawned);
        }
    }
}
