//using UnityEngine;
//using UnityEditor;

//[CustomEditor(typeof(NavMeshSlope))]

//public class NavMeshSlope : Editor
//{
//    public override void OnInspectorGUI()
//    {
//        [MenuItem("NavMeshSlope")]

//        public static void BuildSlope90()
//        {
//            SerializedObject obj = new SerializedObject(NavMeshBuilder.navMeshSettingsObject);
//            SerializedProperty prop = obj.FindProperty("m_BuildSettings.agentSlope");
//            prop.floatValue = 90.0f;
//            obj.ApplyModifiedProperties();
//            NavMeshBuilder.BuildNavMesh();
//        }
//    }
//}
