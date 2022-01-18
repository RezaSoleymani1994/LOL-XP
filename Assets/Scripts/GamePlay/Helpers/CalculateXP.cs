namespace LOL.XP
{
    public static class CalculateXP
    {
        public static int Get(ChampionController[] champion, ChampionController myChampion, EntityType enameType, ChampionController? championsKiler)
        {
            #region Entity method
            (int? total, int? LastHitPercent) EntityData(EntityType enameType)
            {
                switch (enameType)
                {
                    case EntityType.Creep:
                        return (XPSystem.Data.Creep, XPSystem.Data.creepLastHitPercent);
                    case EntityType.Dragon:
                        return (XPSystem.Data.Dragon, XPSystem.Data.dragonLastHitPercent);
                    case EntityType.Champion:
                        return (XPSystem.Data.Champion, XPSystem.Data.championLastHitPercent);
                }
                return (null, null);
            }
            #endregion

            int currnt = 0;
            var entityData = EntityData(enameType);
            // kill by Champion
            if (championsKiler != null)
            {
                // Last hit by my Champion
                if (championsKiler == myChampion)
                {
                    currnt += (int)(((float)entityData.LastHitPercent / (float)100) * entityData.total);
                    var remainingXp = entityData.total - currnt;
                    currnt += (int)(remainingXp / champion.Length);
                }
                // Last hit by other Champion
                else
                {
                    int catchXP = 0;
                    catchXP = (int)(((float)entityData.LastHitPercent / (float)100) * entityData.total);
                    var remainingXp = entityData.total - catchXP;
                    currnt += (int)(remainingXp / champion.Length);
                }
            }
            // kill by creep
            else
                currnt += (int)(entityData.total / champion.Length);

            return currnt;
        }
    }
}
