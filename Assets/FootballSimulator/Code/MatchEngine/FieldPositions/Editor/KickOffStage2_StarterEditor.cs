using UnityEditor;

namespace FStudio.MatchEngine.FieldPositions
{
    [CustomEditor(typeof(KickOffStage2_Starter))]
    public class KickOffStage2_StarterEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            var script = (KickOffStage2_Starter)target;

            BasePositionsDataEditor.OnInspectorGUI(script);

            Repaint();

            base.OnInspectorGUI();
        }
    }
}

