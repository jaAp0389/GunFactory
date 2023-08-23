/*****************************************************************************
* Project: GunFactory
* File   : BulletController.cs
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
*   15.08.2021	JA	Created
******************************************************************************/
using UnityEngine;

/// <summary>
/// Bullet controller class. Defines speed and handles collision damage transfer.
/// Spawns explosions at contact point.
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class BulletController : MonoBehaviour, IBullet
{
    [SerializeField] private float mLifeTime;
    [SerializeField] private float mSpeed;
    [SerializeField] private float damage;
    [SerializeField] private float health = 5;

    [SerializeField] private GameObject mExplosionPrefab;
    [SerializeField] private Rigidbody mRigidbody;

    //private void Awake()
    //{
    //    mRigidbody = GetComponent<Rigidbody>();
    //}

    private void Start()
    {
        mRigidbody.velocity = Vector3.zero;

        mRigidbody.AddForce(transform.forward * mSpeed, ForceMode.Impulse);

        Destroy(gameObject, mLifeTime);
    }

    public float Damage()
    {
        return damage;
    }

    private void OnCollisionEnter(Collision collision)
    {
        IBullet bullet = collision.gameObject.GetComponent<IBullet>();
        if(bullet!=null)
        {
            health += bullet.Damage();
            if (health > 0) return;
        }
        DamageTarget(collision.gameObject);

        ContactPoint contact = collision.GetContact(0); //collision.contacts[0];

        Quaternion rotation = 
            Quaternion.FromToRotation(Vector3.up, contact.normal);

        Vector3 position = contact.point;

        Instantiate(mExplosionPrefab, position, rotation);
        Destroy(gameObject);
    }
    private void DamageTarget(GameObject target)
    {
        IHealth targetIHealth = target.GetComponent<IHealth>();
        targetIHealth?.ChangeHealth(damage);

        IDMGFlash dMGFlash = target.GetComponent<IDMGFlash>();
        dMGFlash?.FlashEnemy();
    }
}

