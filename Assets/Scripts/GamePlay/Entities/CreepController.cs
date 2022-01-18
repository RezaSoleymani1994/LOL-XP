using UnityEngine;

public class CreepController : Entity
{

    [ContextMenu("Die")]
    public void OnDie() => CalcXPDie();

}
#if UNITY_EDITOR
[UnityEditor.CustomEditor(typeof(CreepController))]
public class XPDataEditor : UnityEditor.Editor
{
    public CreepController Creep;
    private void OnEnable()
    {
        Creep = (CreepController)target;
    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        GUILayout.Space(10);
        if (GUILayout.Button("Die"))
        {
            Creep.OnDie();
        }
    }
}
#endif
