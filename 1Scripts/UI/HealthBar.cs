/*****************************************************************************
* Project: GunFactory
* File   : HealthBar.cs
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
*   26.08.2021	JA	Created
******************************************************************************/
using TMPro;
using UnityEngine;

/// <summary>
/// Manages Healthbar ui item.
/// </summary>
public class HealthBar : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI mPlayerHealthGreen, mPlayerHealthRed;
    float mMaxHealth = DataBaseStatic.sMaxHealth;
    float mHealthBarLength = 20;

    public void AdjustHealth(float _newHealth)
    {
        float healthPercentage = (_newHealth / mMaxHealth);
        float currentHealthBar = mHealthBarLength * healthPercentage;
        mPlayerHealthGreen.text = CreateIArray(currentHealthBar);
        mPlayerHealthRed.text = CreateIArray(mHealthBarLength - currentHealthBar);
    }

    string CreateIArray(float length)
    {
        string stringI = "";
        for (int i = 0; i < length; i++)
        {
            stringI += 'i';
        }
        return stringI;
    }
}
