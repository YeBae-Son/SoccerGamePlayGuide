using UnityEditor;

namespace FStudio.MatchEngine.FieldPositions
{
    [CustomEditor(typeof(KickOffStage2))]
    public class KickOffStage2Editor : Editor
    {
        public override void OnInspectorGUI()
        {
            var script = (KickOffStage2)target;

            BasePositionsDataEditor.OnInspectorGUI(script);

            Repaint();

            base.OnInspectorGUI();
        }
    }
}

