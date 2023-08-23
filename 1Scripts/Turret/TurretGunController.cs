/*****************************************************************************
* Project: GunFactory
* File   : TurretGunController.cs
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
*   17.08.2021	JA	Created
******************************************************************************/
using UnityEngine;

/// <summary>
/// Manages the turret gun. Plays the effects, recoil animation and 
/// instantiates the bullet. Has a branch for guns with several barrels which 
/// get shot in tandem.
/// </summary>
public class TurretGunController : MonoBehaviour, IGun
{
    [SerializeField] GameObject mBulletPrefab;
    [SerializeField] Transform[] mMuzzlePos;
    [SerializeField] Animation[] mRecoil;
    [SerializeField] ParticleSystem[] mParticle;
    [SerializeField] AudioSource[] mGunFireAudio;
    [SerializeField] float mBulletSway = 0.5f;
    [SerializeField] float mShootInterval = 0.5f;
    [SerializeField] bool mCheckAssignments = true, 
                          mAutoFire = false,
                          hasParticles = true, 
                          hasRecoil = true,
                          hasAudio = true;

    bool canShoot = true;
    bool isMultiGun = false;
    int mGunNum = 0;
    int mGunMax;

    void Awake()
    {
        CheckAssignment();
    }
    private void FixedUpdate()
    {
        if (mAutoFire) Shoot();
    }
    void CheckAssignment()
    {
        if (mMuzzlePos.Length > 1)
        {
            isMultiGun = true;
            mGunMax = mMuzzlePos.Length;
            if (mCheckAssignments)
                if (mMuzzlePos.Length != mGunMax ||
                    mRecoil.Length != mGunMax ||
                    mParticle.Length != mGunMax)
                    Debug.LogError("Assignment error at " + gameObject);
        }
    }

    public void Shoot()
    {
        if (!canShoot) return;

        if (!isMultiGun) ShootGunNum(0);
        else ShootGunNum(GetNextGun());
    }
    /// <summary>
    /// Shoots gun number[position in array].
    /// </summary>
    void ShootGunNum(int _gunNum)
    {
        canShoot = false;
        if(hasRecoil)mRecoil[_gunNum].Play();
        if(hasParticles)mParticle[_gunNum].Play();
        if(hasAudio) mGunFireAudio[_gunNum].Play();

         Quaternion bulletDir = mBulletSway <= 0f ? 
            mMuzzlePos[_gunNum].rotation : mMuzzlePos[_gunNum].rotation * 
            Quaternion.Euler((Vector3.up * (Random.value - 0.5f) + 
            Vector3.left * (Random.value - 0.5f)) * mBulletSway);

        Instantiate(mBulletPrefab, mMuzzlePos[_gunNum].position, bulletDir);

        Invoke("SetShootTrue", mShootInterval);
    }

    int GetNextGun()
    {
        mGunNum += 1;
        if (mGunNum >= mGunMax) mGunNum = 0;
        return mGunNum;
    }
    void SetShootTrue()
    {
        canShoot = true;
    }
}
