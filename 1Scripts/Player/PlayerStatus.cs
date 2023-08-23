/*****************************************************************************
* Project: GunFactory
* File   : PlayerStatus.cs
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
/// All the player stats.
/// </summary>
public class PlayerStatus : MonoBehaviour, IHealth, IMoney, IExperience
{
    [SerializeField] private float mXp;
    [SerializeField] private float mHealth;
    [SerializeField] private int mMoney;
    [SerializeField] private HealthBar mHealthBar;
    [SerializeField] AudioClipPlayer mAudioClipPlayer;
    [SerializeField] PlayerDeath mPlayerDeath;
    IBurstColor mBurstColor;
    float mMaxHealth = DataBaseStatic.sMaxHealth;
    bool isAlive = true;

    void Awake()
    {
        mBurstColor = gameObject.GetComponent<IBurstColor>();
        mHealthBar.AdjustHealth(mHealth);
    }
    public void ChangeHealth(float cHealth)
    {
        if (!isAlive) return;
        if(cHealth<0) mAudioClipPlayer.PlayRandomAudioClip(0.6f/-cHealth);
        mHealth = Mathf.Clamp(mHealth + cHealth, 0f, mMaxHealth);
        mHealthBar.AdjustHealth(mHealth);
        if (mHealth <= 0)
        {
            Die();
            isAlive = false;
        }
        if(cHealth<0 && isAlive) mBurstColor.DoColorBurst(cHealth<-5? .4f:.2f);
    }
    public void ChangeMoney(int money) => mMoney += money;
    public void ChangeExperience(float xp) => mXp += xp;
    void Die()
    {
        mPlayerDeath.Death();
    }

    ///#######################
    //public GUIStyle style;
    //private void OnGUI()
    //{
    //    style.fontSize = 40;
    //    GUI.Label(new Rect(10, 200, 400, 100), "HEALTH:"+ mHealth, style);
    //}
}
