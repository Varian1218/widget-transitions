using System;
using UnityEditor;
using UnityEngine;

namespace Transitions.Unity.Editors
{
    [CustomEditor(typeof(MoveTransition))]
    public class MoveTransitionEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            var aProps = serializedObject.FindProperty("a");
            var bProps = serializedObject.FindProperty("b");
            var directionProp = serializedObject.FindProperty("direction");
            var rectTransformProp = serializedObject.FindProperty("rectTransform");
            var rectTransform = rectTransformProp.objectReferenceValue as RectTransform;
            EditorGUILayout.PropertyField(directionProp);
            EditorGUILayout.PropertyField(rectTransformProp);

            if (rectTransform)
            {
                var position = rectTransform.position;
                aProps.vector3Value = GetPos((MoveTransition.Direction)directionProp.enumValueIndex, position);
                bProps.vector3Value = position;
            }

            serializedObject.ApplyModifiedProperties();
        }

        private static Vector3 GetPos(MoveTransition.Direction dir, Vector3 pos)
        {
            switch (dir)
            {
                case MoveTransition.Direction.Down:
                    pos.y -= Screen.height;
                    break;
                case MoveTransition.Direction.Left:
                    pos.x -= Screen.width;
                    break;
                case MoveTransition.Direction.Right:
                    pos.x += Screen.width;
                    break;
                case MoveTransition.Direction.Up:
                    pos.y += Screen.height;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(dir), dir, null);
            }

            return pos;
        }
    }
}