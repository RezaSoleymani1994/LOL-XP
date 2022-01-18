
using UnityEngine;

public abstract class Entity : MonoBehaviour, IXPDieEvent
{
    [field: SerializeField] public EntityType type { get; private set; } = EntityType.Creep;
    [field: SerializeField] public TeamType teamType { get; private set; } = TeamType.Team_A;

    [field: SerializeField] internal ChampionController? championsKiler;


    public virtual void CalcXPDie()
    {
        var champions = LOL.XP.AreaScanner.KillEntity(transform.position, teamType);
        if (champions?.Length > 0)
        {
            var resualtXP = LOL.XP.CalculateXP.Get(champions, ChampionController.PlayerInstance, type, championsKiler);
            XPSystem.GiveXP(resualtXP);
        }
    }
}

public enum TeamType
{
    Team_A,
    Team_B
}
public enum EntityType
{
    Creep, Dragon, Champion
}

#region Interface
public interface IXPDieEvent
{
    public void CalcXPDie();
}
#endregion