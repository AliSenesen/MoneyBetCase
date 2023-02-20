using System.Collections;
using System.Collections.Generic;
using Datas.ValueObject;
using UnityEngine;

namespace Datas.UnityObject
{
    [CreateAssetMenu(fileName = "CD_Movement", menuName = "MoneyBet/CD_Movement", order = 0)]
    public class CD_Player : ScriptableObject
    {
        public PlayerData Data;

    }
}

