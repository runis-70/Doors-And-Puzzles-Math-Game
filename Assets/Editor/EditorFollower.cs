 using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CustomCamera))]
public class EditorFollower : Editor
{
    CustomCamera customCamera;

    private void OnEnable()
    {
        customCamera = (CustomCamera)target;
    }

    public override void OnInspectorGUI() // Переопределяем метод который рисует испектор
    {
        EditorGUILayout.BeginVertical(); // Это чтобы элементы были вертикально друг за другом


        if (customCamera.limitCameraZone)
        {
            customCamera.speed = EditorGUILayout.FloatField("Скорость", customCamera.speed);
            customCamera.target = (Transform)EditorGUILayout.ObjectField("Цель", customCamera.target, typeof(Transform), true);
            customCamera.clamp = EditorGUILayout.Vector2Field("Ограничения", customCamera.clamp, null);
            customCamera.limitCameraZone = EditorGUILayout.Toggle("Включить лимит камеры", customCamera.limitCameraZone);
            customCamera.leftCornerLimit = (Transform)EditorGUILayout.ObjectField("Нижний лимит", customCamera.leftCornerLimit, typeof(Transform), true);
            customCamera.rightCornerLimit = (Transform)EditorGUILayout.ObjectField("Верхний лимит", customCamera.rightCornerLimit, typeof(Transform), true);
        }
        else
        {
            customCamera.speed = EditorGUILayout.FloatField("Скорость", customCamera.speed);
            customCamera.target = (Transform)EditorGUILayout.ObjectField("Цель", customCamera.target, typeof(Transform), true);
            customCamera.clamp = EditorGUILayout.Vector2Field("Ограничения", customCamera.clamp, null);
            customCamera.limitCameraZone = EditorGUILayout.Toggle("Включить лимит камеры", customCamera.limitCameraZone);
        }

            EditorGUILayout.EndVertical();
        }
}
