using UnityEngine;
using UnityEditor;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

public class RuleTileGenerator : EditorWindow
{

    public static void ShowWindow()
    {
        GetWindow<RuleTileGenerator>("Rule tile Generator");
    }
    Vector2 scrollpos;
    private void OnGUI()
    {
        scrollpos = GUILayout.BeginScrollView(scrollpos);
        if (templ_neighbors.Count == 0)
        {
            EditorGUILayout.Space();
            GUILayout.Label("template Setup", EditorStyles.boldLabel);
            EditorGUILayout.Space();

            ScriptableObject target = this;
            SerializedObject so = new SerializedObject(target);
            SerializedProperty prp = so.FindProperty("templateSprites");
            EditorGUILayout.PropertyField(prp, true);
            so.ApplyModifiedProperties();

            GUILayout.Box("Shift select all of the sprites and drag them here", EditorStyles.helpBox);
            EditorGUILayout.Space();

            if (GUILayout.Button("LoadTemplate"))
            {
                LoadTemplate();
            }

        }
        if (templ_neighbors.Count > 0)
        {
            EditorGUILayout.Space();
            GUILayout.Label("Prieview", EditorStyles.boldLabel);
            EditorGUILayout.Space();

            collumns = EditorGUILayout.IntField("Number Of Collumns", collumns);
        }

        GUILayout.EndScrollView();
    }
    int collumns = 6;
    public Sprite[] templateSprites = new Sprite[0];
    public List<List<int>> templ_neighbors = new List<List<int>>();

    int defaultIndex = 0;
    bool SetDefaultIndex;
    public List<Vector3Int> neighborPositions = new List<Vector3Int>()
    {
        new Vector3Int(-1,1,0), 
        new Vector3Int(0,1,0),
        new Vector3Int(1,1,0),

        new Vector3Int(-1,0,0),
        new Vector3Int(1,0,0),

        new Vector3Int(-1,-1,0),
        new Vector3Int(0,-1,0),
        new Vector3Int(1,-1,0),
       

    };
     void LoadTemplate()
    {
        templ_neighbors = new List<List<int>>();
        int i = 0;
        foreach(var item in templateSprites)
        {
            List<int> neighborRule = new List<int>();
            Rect slice =item.rect;

            Color[] colors = item.texture.GetPixels((int)slice.x,(int)slice.y,(int)slice.width,(int)slice.height);
            Texture2D texture = new Texture2D((int) slice.width,(int)slice.y, TextureFormat.ARGB32, false);
            texture.SetPixels(0, 0, (int)slice.width, (int)slice.height, colors);
            texture.filterMode = FilterMode.Point;
            texture.Apply();

            Vector2Int size = new Vector2Int(texture.width, texture.height);   
            
            bool def =true;

            foreach(var neighbor in neighborPositions)
            {
                int xpos = 0;
                int ypos = 0;
                switch(neighbor.x)
                {
                    case 0:
                        xpos = size.x/2; break;
                    case 1:
                        xpos = size.x -1;
                        break;
                }
                switch (neighbor.y)
                {
                    case 0:
                        ypos = size.y / 2; break;
                    case 1:
                        ypos = size.y - 1;
                        break;
                }

                Color c = texture.GetPixel(xpos, ypos);
                if(c == Color.white)
                {
                    neighborRule.Add(0);
                }else if(c == Color.green)
                {
                    neighborRule.Add(RuleTile.TilingRule.Neighbor.This);   
                    def = false;
                }
                else if(c == Color.red)
                {
                    neighborRule.Add(RuleTile.TilingRule.Neighbor.NotThis);
                }
            }

            if (def)
            {
                defaultIndex = i;
                SetDefaultIndex = true;
            }
            if (SetDefaultIndex)
            {

            }
            templ_neighbors.Add(neighborRule);
            i++;
        }
       
    }
}
