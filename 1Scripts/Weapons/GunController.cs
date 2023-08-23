/*****************************************************************************
* Project: GunFactory
* File   : GunController.cs
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
/// (Player)guncontroller. Handles gun firerate, plays effects and spawns 
/// bullets. 
/// </summary>
public class GunController : MonoBehaviour, IGun, IMouseTimer
{
    [SerializeField] GameObject mBulletPrefab;
    [SerializeField] Transform mMuzzlePos;
    [SerializeField] Animation mRecoil;
    [SerializeField] AudioSource mFireSound;
    [SerializeField] ParticleSystem mMuzzleFlash;
    [SerializeField] float bulletSway = 1;

    ExhaustController mExhaustController;
    MaterialTransparencyBurst mMaterialTransparencyBurst;

    bool isCanShoot = true;
    bool isAutoFire = false;
    bool isShooting = false;

    public float shootInterval = 0.5f;

    private void Awake()
    {
        mMaterialTransparencyBurst = 
            GetComponentInChildren<MaterialTransparencyBurst>();
        mExhaustController = GetComponentInChildren<ExhaustController>();
    }
    void FixedUpdate()
    {
        if (isShooting)
            FireGun();
        //if (isAutoFire && isCanShoot)
        //    Shoot();
        //if (Input.GetButtonDown("Fire3"))
        //    isAutoFire = !isAutoFire;
    }

    public void Shoot()
    {
        isShooting = true;
        mExhaustController?.StopParticle();
        mMaterialTransparencyBurst.DoColorBurst();
    }

    public void GetMouse1Time(float _mousePressedTime)
    {
        isShooting = false;
        mExhaustController?.PlayParticle(_mousePressedTime);
        mMaterialTransparencyBurst.EndColorBurst();
    }

    void FireGun()
    {
        if (!isCanShoot) return;
        isCanShoot = false;
        mFireSound?.Play();
        mRecoil.Play();
        mMuzzleFlash.Play();

        Quaternion bulletDir = bulletSway <= 0f ? mMuzzlePos.rotation :
            mMuzzlePos.rotation * Quaternion.Euler
            ((Vector3.up * (Random.value - 0.5f) + Vector3.left *
            (Random.value - 0.5f)) * bulletSway);

        GameObject bullet =
            Instantiate(mBulletPrefab, mMuzzlePos.position, bulletDir);
        Invoke("SetShootTrue", shootInterval);
    }

    void SetShootTrue()
    {
        isCanShoot = true;
    }
}

