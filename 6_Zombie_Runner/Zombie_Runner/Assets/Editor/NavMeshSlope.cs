//using UnityEngine;
//using UnityEditor;
//using UnityEngine.AI;


//[CustomEditor(typeof(NavMeshSlope))]

//public class NavMeshSlope : Editor
//{
//    public override void OnInspectorGUI()
//    {
//        [MenuItem("NavMesh/Build With Slope 90")]

//        public static void BuildSlope90()
//        {
//            SerializedObject obj = new SerializedObject(NavMeshBuilder.navMeshSettingsObject);
//            SerializedProperty prop = obj.FindProperty("m_BuildSettings.agentSlope");
//            prop.floatValue = 90.0f;
//            obj.ApplyModifiedProperties();
//            NavMeshBuilder.BuildNavMeshData();
//        }
//    }
//}
