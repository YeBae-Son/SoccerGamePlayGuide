using UnityEditor;

namespace FStudio.MatchEngine.FieldPositions
{
    [CustomEditor(typeof(KickOffStage1))]
    public class KickOffStage1Editor : Editor
    {
        public override void OnInspectorGUI()
        {
            var script = (KickOffStage1)target;

            BasePositionsDataEditor.OnInspectorGUI(script);

            Repaint();

            base.OnInspectorGUI();
        }
    }
}

