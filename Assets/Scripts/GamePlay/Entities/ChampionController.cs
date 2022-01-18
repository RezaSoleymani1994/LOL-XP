using UnityEngine;

public sealed class ChampionController : Entity
{
    [field: SerializeField] public bool IsPlayer { get; private set; }

    public static ChampionController PlayerInstance { private set; get; }


    [ContextMenu("Die")]
    public void OnDie() => CalcXPDie();

    private void Awake()
    {
        if(IsPlayer)
            PlayerInstance = this;
    }
}
