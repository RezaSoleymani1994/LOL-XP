using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// In area scanner we create all proccess about finding another entity around of a point
/// </summary>
/// 
namespace LOL.XP
{
    public static class AreaScanner
    {
        public static ChampionController[] KillEntity(Vector3 origin, TeamType team)
        {
            List<ChampionController> playerSelect = new List<ChampionController>();
            var champions = Physics.SphereCastAll(origin, .1f, Vector3.right, XPSystem.Data.Range, XPSystem.Data.championLayer.value);

            foreach (var champion in champions)
            {
                if (champion.collider.GetComponent<ChampionController>() != null)
                    if (champion.collider.GetComponent<ChampionController>().teamType != team)
                        playerSelect.Add(champion.collider.GetComponent<ChampionController>());
            }
            return playerSelect.ToArray();
        }
    }

}
