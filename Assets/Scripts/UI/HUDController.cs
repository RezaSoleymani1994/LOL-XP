using UnityEngine;
using UnityEngine.UI;
public class HUDController : MonoBehaviour
{
    [SerializeField] private Text _xp ,_level;

    private void Awake() => XPSystem.OnUserXp += SetData;

    public void SetData(int xp,int level)
    {
        _xp.text = $" XP : {xp}";
        _level.text = $" Level : {level}";
    }

    public void ResetData()
    {
        XPSystem.ResetData();
    }
}


#if UNITY_EDITOR
[UnityEditor.CustomEditor(typeof(HUDController))]
public class XPSystemEditor : UnityEditor.Editor
{
    public HUDController hud;
    private void OnEnable()
    {
        hud = (HUDController)target;
    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        GUILayout.Space(10);
        if (GUILayout.Button("Reset Data"))
        {
            Debug.Log("Reset");
           // hud.ResetData();
        }
    }
}
#endif
