/*****************************************************************************
* Project: GunFactory
* File   : DataBaseStatic.cs
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
/// <summary>
/// Global variables class. Just has one variable.
/// </summary>
public static class DataBaseStatic
{
    public static float sMaxHealth { get; private set; } = 200;
    public static bool isTutorialOn = false;
}
