using UnityEngine;
using UnityEditor;

namespace MalbersAnimations
{
    [CustomPropertyDrawer(typeof(InputRow))]
    public class InputRowDrawer : PropertyDrawer
    {

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            // EditorGUI.HelpBox(position, "",MessageType.None);

            EditorGUI.BeginProperty(position, label, property);

            var indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            property.FindPropertyRelative("name").stringValue = label.text;

            // Calculate rects
            var activeRect = new Rect(position.x, position.y, 15, position.height);
            var LabelRect = new Rect(position.x + 17, position.y, 100, position.height);



            // Draw fields - passs GUIContent.none to each so they are drawn without labels
            EditorGUI.PropertyField(activeRect, property.FindPropertyRelative("active"), GUIContent.none);
            EditorGUI.LabelField(LabelRect, label, EditorStyles.miniBoldLabel);

            //Set Rect to the Parameters Values
            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), new GUIContent(" "));

            // Calculate rects
            var typeRect = new Rect(position.x - 30, position.y, 44, position.height);
            var valueRect = new Rect(position.x - 30 + 45, position.y, position.width / 2 - 7, position.height);
            var ActionRect = new Rect(position.width / 2 + position.x - 30 + 40 - 1, position.y, position.width / 2 - 7, position.height);

            EditorGUI.PropertyField(typeRect, property.FindPropertyRelative("type"), GUIContent.none);

            InputType current = (InputType)property.FindPropertyRelative("type").enumValueIndex;
            switch (current)
            {
                case InputType.Input:
                    EditorGUI.PropertyField(valueRect, property.FindPropertyRelative("input"), GUIContent.none);
                    break;
                case InputType.Key:
                    EditorGUI.PropertyField(valueRect, property.FindPropertyRelative("key"), GUIContent.none);
                    break;
                default:
                    break;
            }

            EditorGUI.PropertyField(ActionRect, property.FindPropertyRelative("GetPressed"), GUIContent.none);

            // Set indent back to what it was
            EditorGUI.indentLevel = indent;

            EditorGUI.EndProperty();
        }

    }
    /*
    [CustomPropertyDrawer(typeof(MSpeed))]
    public class  MSpeedDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);
            EditorGUIUtility.labelWidth = 0;
            EditorGUI.indentLevel = 0;
            var indent = EditorGUI.indentLevel;

            var P = new Rect(position.x, position.y+8, position.width, 65);
            var P2 = new Rect(position.x+5, position.y, EditorGUIUtility.labelWidth-20, EditorGUIUtility.singleLineHeight);
            EditorGUI.LabelField(P, GUIContent.none, EditorStyles.helpBox);
            EditorGUI.LabelField(P2, GUIContent.none, EditorStyles.helpBox);
            EditorGUI.LabelField(P2, GUIContent.none, EditorStyles.helpBox);
            EditorGUI.LabelField(P2, GUIContent.none, EditorStyles.helpBox);
            EditorGUI.LabelField(position,"  "+ property.name, EditorStyles.boldLabel);


            var tempRect = position;
            tempRect.y += 18;

            var PosLabelRect = new Rect(tempRect.x+10, tempRect.y, (tempRect.width / 2) + 40, EditorGUIUtility.singleLineHeight);
            var PosSMoothRect = new Rect((tempRect.width / 2) + 70, tempRect.y, (tempRect.width / 2)-59, EditorGUIUtility.singleLineHeight);

            

            EditorGUIUtility.labelWidth = 120-10;
            EditorGUI.PropertyField(PosLabelRect, property.FindPropertyRelative("position"), new GUIContent("Position", "Additional Speed added to the position"));
            EditorGUIUtility.labelWidth = 30;
            EditorGUI.PropertyField(PosSMoothRect, property.FindPropertyRelative("lerpPosition"), new GUIContent("Lerp", "Position Lerp interpolation, higher value more Responsiveness"));


            PosLabelRect.y += EditorGUIUtility.singleLineHeight + 2;
            PosSMoothRect.y += EditorGUIUtility.singleLineHeight + 2;

            EditorGUIUtility.labelWidth = 120 - 10;
            EditorGUI.PropertyField(PosLabelRect, property.FindPropertyRelative("animator"), new GUIContent("Animator", "Additional Speed added to the Animator"));
            EditorGUIUtility.labelWidth = 30;
            EditorGUI.PropertyField(PosSMoothRect, property.FindPropertyRelative("lerpAnimator"), new GUIContent("Lerp", "Animator Lerp interpolation, higher value more Responsiveness"));

            PosLabelRect.y += EditorGUIUtility.singleLineHeight + 2;
            PosSMoothRect.y += EditorGUIUtility.singleLineHeight + 2;

            EditorGUIUtility.labelWidth = 120 - 10;
            EditorGUI.PropertyField(PosLabelRect, property.FindPropertyRelative("rotation"), new GUIContent("Turn", "Aditional Turn Speed"));
            EditorGUIUtility.labelWidth = 30;
            EditorGUI.PropertyField(PosSMoothRect, property.FindPropertyRelative("lerpRotation"), new GUIContent("Lerp", "Rotation Lerp interpolation, higher value more Responsiveness"));

            EditorGUIUtility.labelWidth = 0;
            // Set indent back to what it was
            EditorGUI.indentLevel = indent;

            EditorGUI.EndProperty();


     
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return base.GetPropertyHeight(property, label)+60;
        }
    }*/
}