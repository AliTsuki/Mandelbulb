/// http://answers.unity3d.com/questions/461958/generate-a-gradient-texture-from-editor-script.html
/// http://answers.unity3d.com/questions/436295/how-to-have-a-gradient-editor-in-an-editor-script.html
using System.IO;

using UnityEditor;

using UnityEngine;

public class GradientToTexture : EditorWindow
{

    int width;
    public Gradient gradient;
    [MenuItem("Window/GradientToTexture")]
    // Use this for initialization
    static void Init()
    {
        GradientToTexture window = (GradientToTexture)EditorWindow.GetWindow(typeof(GradientToTexture));
        window.maxSize = new Vector2(300, 200);
    }
    void OnGUI()
    {
        if(this.gradient == null)
        {
            this.gradient = new Gradient();
        }
        EditorGUI.BeginChangeCheck();
        SerializedObject serializedGradient = new SerializedObject(this);
        SerializedProperty colorGradient = serializedGradient.FindProperty("gradient");
        EditorGUILayout.PropertyField(colorGradient, true, null);
        //if(EditorGUI.EndChangeCheck()) {
        serializedGradient.ApplyModifiedProperties();
        //}
        this.width = Mathf.Clamp(EditorGUILayout.IntField("Width", this.width), 1, 4096);
        if(this.gradient != null)
        {
            Texture2D tex = new Texture2D(this.width, 1);
            for(int i = 0; i < this.width; i++)
            {
                tex.SetPixel(i, 0, this.gradient.Evaluate((float)i / (float)this.width));
            }
            if(GUILayout.Button("Gen"))
            {
                string path = EditorUtility.SaveFilePanel("Save texture as PNG", "", "foo.png", "png");
                if(path.Length != 0)
                {
                    this.GenTexture(tex, path);
                }
            }
        }


    }
    void GenTexture(Texture2D tex, string path)
    {
        byte[] pngData = tex.EncodeToPNG();
        if(pngData != null)
        {
            File.WriteAllBytes(path, pngData);
        }
    }

}
