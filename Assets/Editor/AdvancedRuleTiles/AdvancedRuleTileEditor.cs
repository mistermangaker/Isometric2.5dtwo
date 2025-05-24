using UnityEngine;
using System.Linq;
using UnityEngine.Tilemaps;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

[CustomEditor(typeof(AdvancedRuleTile))]
[CanEditMultipleObjects]
public class AdvancedRuleTileEditor : RuleTileEditor
{
    public Texture2D any;
    public Texture2D Specified;
    public Texture2D Nothing;

    public override void RuleOnGUI(Rect rect, Vector3Int position, int neighbor)
    {
        switch (neighbor)
        {
            case 3:
                GUI.DrawTexture(rect, any);
                return;
            case 4:
                GUI.DrawTexture(rect, Specified);
                return;
            case 5:
                GUI.DrawTexture(rect, Nothing);
                return;
        }
        base.RuleOnGUI(rect, position, neighbor);
    }
}


