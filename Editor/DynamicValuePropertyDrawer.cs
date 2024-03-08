// Developed With Love by Ryan Boyer http://ryanjboyer.com <3

#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

namespace NativeColorScheme.Editor {
	[CustomPropertyDrawer(typeof(DynamicValue<>))]
	internal sealed class DynamicValuePropertyDrawer : PropertyDrawer {
		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
			=> base.GetPropertyHeight(property, label);

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
			using (var scope = new EditorGUI.PropertyScope(position, label, property)) {
				using (new EditorGUILayout.HorizontalScope()) {
					label = scope.content;
					position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
					float propertyWidth = (position.width - SPACING) * 0.5f;

					float initialLabelWidth = EditorGUIUtility.labelWidth;
					int initialIndentLevel = EditorGUI.indentLevel;

					EditorGUIUtility.labelWidth = LABEL_WIDTH;
					EditorGUI.indentLevel = 0;

					SerializedProperty light = property.FindPropertyRelative("light");
					SerializedProperty dark = property.FindPropertyRelative("dark");

					position.width = propertyWidth;

					EditorGUI.PropertyField(position, light);

					position.x += propertyWidth + SPACING;
					EditorGUI.PropertyField(position, dark);

					EditorGUIUtility.labelWidth = initialLabelWidth;
					EditorGUI.indentLevel = initialIndentLevel;
				}
			}
		}

		// MARK: - Constants

		private const float SPACING = 8;
		private const float LABEL_WIDTH = 30;
	}
}
#endif