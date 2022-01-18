using UnityEngine;
using System.Linq;
public class XPSystem : MonoBehaviour
{

    private const string resourceAddress = "ConfigXP/XP";

    public delegate void del_UserXp(int xp ,int level);
    internal static event del_UserXp OnUserXp;

    [field: SerializeField] internal static int _currentXP { get; set; } = 0;
    [field: SerializeField] internal static int _currentLevel { get; set; } = 1;


    private static XPData _data;
    public static XPData Data => _data ?? (_data = Resources.Load<XPData>(resourceAddress));



    internal static void GiveXP(int xp)
    {
        _currentXP += xp;
        var levels = Data.level.Where<XPData.Level>(a => (a.level == _currentLevel)).ToArray()[0];

        if (levels.maxXP <= _currentXP)
        {
            _currentLevel++;
            _currentXP = _currentXP - levels.maxXP;
        }

        print($"_currentXP : {_currentXP}  _currentLevel : {_currentLevel}");
        OnUserXp?.Invoke(_currentXP, _currentLevel);
    }



}
