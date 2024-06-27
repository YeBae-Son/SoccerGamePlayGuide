using UnityEditor;

namespace FStudio.MatchEngine.FieldPositions
{
    [CustomEditor(typeof(KickOffStage1_Starter))]
    public class KickOffStage1_StarterEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            var script = (KickOffStage1_Starter)target;

            BasePositionsDataEditor.OnInspectorGUI(script);

            Repaint();

            base.OnInspectorGUI();
        }
    }
}

