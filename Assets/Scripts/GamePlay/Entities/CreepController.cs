using UnityEngine;

public class CreepController : Entity
{

    [ContextMenu("Die")]
    public void OnDie() => CalcXPDie();

}
