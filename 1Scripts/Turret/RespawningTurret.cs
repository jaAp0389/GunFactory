/*****************************************************************************
* Project: GunFactory
* File   : RespawningTurret.cs
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
*   25.08.2021	JA	Created
******************************************************************************/
using UnityEngine;

/// <summary>
/// Respawns SideTurrets on BossTurret. Resets Health and Model.
/// </summary>
public class RespawningTurret : MonoBehaviour, IDeath
{
    [SerializeField] ChangeToCorpse mChangeToCorpse;
    [SerializeField] TurretController mTurretController;
    [SerializeField] Animator mAnimator;
    [SerializeField] HealthInfo mHealthInfo;
    [SerializeField] ExplodeOnDeath mExplodeOnDeath;
    [SerializeField] float mResetTime;
    float mStartHealth;
    IAction mTurretGateAction;
    bool mStopRespawning = false;

    private void Awake()
    {
        mStartHealth = mHealthInfo.MHealth;
        mTurretGateAction = GetComponent<IAction>();
        OnDeath(); //switch Turret Lift
    }
    public void OnDeath()
    {
        mTurretGateAction.ExecuteAction();
    }
    public void StartResetTimer()
    {
        if(!mStopRespawning) Invoke("RespawnTurret", mResetTime);
    }
    public void StopRespawning()
    {
        mStopRespawning = true;
    }

    void RespawnTurret()
    {
        mExplodeOnDeath.OnRevive();
        mHealthInfo.ChangeHealth(mStartHealth);
        mChangeToCorpse.Revive();
        mHealthInfo.isAlive = true;
        mTurretGateAction.ExecuteAction();
    }
}
