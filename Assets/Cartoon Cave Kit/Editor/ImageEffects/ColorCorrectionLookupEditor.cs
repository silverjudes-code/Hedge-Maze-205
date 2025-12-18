using UnityEditor;
using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
    [CustomEditor(typeof(ColorCorrectionLookup))]
    public class ColorCorrectionLookupEditor : Editor
    {
        private SerializedObject serObj;
        private Texture2D tempClutTex2D;

        private void OnEnable()
        {
            serObj = new SerializedObject(target);
        }

        public override void OnInspectorGUI()
        {
            serObj.Update();

            ColorCorrectionLookup ccl = target as ColorCorrectionLookup;
            if (ccl == null) return;

            EditorGUILayout.LabelField("Converts textures into color lookup volumes (for grading)", EditorStyles.miniLabel);

            // LUT assignment
            tempClutTex2D = EditorGUILayout.ObjectField("Based On", tempClutTex2D, typeof(Texture2D), false) as Texture2D;
            if (tempClutTex2D == null && !string.IsNullOrEmpty(ccl.basedOnTempTex))
            {
                Texture2D t = AssetDatabase.LoadMainAssetAtPath(ccl.basedOnTempTex) as Texture2D;
                if (t) tempClutTex2D = t;
            }

            // Process conversion if new LUT assigned
            if (tempClutTex2D != null && ccl.basedOnTempTex != AssetDatabase.GetAssetPath(tempClutTex2D))
            {
                EditorGUILayout.Space();
                if (!ccl.ValidDimensions(tempClutTex2D))
                {
                    EditorGUILayout.HelpBox("Invalid texture dimensions! Pick another texture or use e.g. 256x16.", MessageType.Warning);
                }
                else if (GUILayout.Button("Convert and Apply"))
                {
                    string path = AssetDatabase.GetAssetPath(tempClutTex2D);
                    TextureImporter textureImporter = AssetImporter.GetAtPath(path) as TextureImporter;

                    bool doImport = false;
                    if (!textureImporter.isReadable) doImport = true;
                    if (textureImporter.mipmapEnabled) doImport = true;
                    if (textureImporter.textureCompression != TextureImporterCompression.Uncompressed) doImport = true;

                    if (doImport)
                    {
                        textureImporter.isReadable = true;
                        textureImporter.mipmapEnabled = false;
                        textureImporter.textureCompression = TextureImporterCompression.Uncompressed;
                        AssetDatabase.ImportAsset(path, ImportAssetOptions.ForceUpdate);
                    }

                    ccl.Convert(tempClutTex2D, path);
                }
            }

            // Display currently used LUT
            if (!string.IsNullOrEmpty(ccl.basedOnTempTex))
            {
                EditorGUILayout.HelpBox("Using " + ccl.basedOnTempTex, MessageType.Info);
                Texture2D t = AssetDatabase.LoadMainAssetAtPath(ccl.basedOnTempTex) as Texture2D;
                if (t)
                {
                    Rect r = GUILayoutUtility.GetRect(100, 20, GUILayout.ExpandWidth(true));
                    GUI.DrawTexture(r, t, ScaleMode.ScaleToFit);
                    GUILayoutUtility.GetRect(0, 4); // spacing
                }
            }

            serObj.ApplyModifiedProperties();
        }
    }
}