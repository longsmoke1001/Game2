using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "Ability",menuName = "ScriptableObjects/Ability")]
public class AbilityData : ScriptableObject
{
    public float attackPowerRatio =3;
    public float cooldownTime =10;
    public float lastCastTime = -999;
}
