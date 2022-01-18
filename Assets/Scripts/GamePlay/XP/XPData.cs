using UnityEngine;

[CreateAssetMenu(fileName = "XP", menuName = "LOL/XP")]
public class XPData : ScriptableObject
{   
    [field: SerializeField]public int Creep { get;private set; } = 100;
    [Range(0,100)]
    public int creepLastHitPercent;

    [field: SerializeField] public int Champion { get; private set; } = 1000;
    [Range(0, 100)]
    public int championLastHitPercent;

    [field: SerializeField] public int Dragon { get; private set; } = 1000;
    [Range(0, 100)]
    public int dragonLastHitPercent;

    [Header("Setting")]
    public LayerMask championLayer;
    [field: SerializeField] public int Range { get; private set; } = 10;
    [Header("------------------------------------------------------------------------------------------------------------------------------------")]
    public int MaxLevel = 18;
    public Level[] level;
    [System.Serializable]
    public class Level
    {
        public int level;
        public int maxXP;
    }


}
