using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor;

[CreateAssetMenu(menuName = "2D/Tiles/Advanced Rule Tile")]
public class AdvancedRuleTile : RuleTile<AdvancedRuleTile.Neighbor> {
    /// <summary>
    /// if set to true. then any tiles that Arent will be treated as if they arent there
    /// </summary>
    public bool onlyThisTile;
    public TileBase[] TilesToConnectTo;
    /// <summary>
    /// if set to false only these tiles will only check if the surround cells are occupied or not. if set to true then the surrounding cells have to be anything but this tile
    /// </summary>
    public bool CheckSelf;

    public class Neighbor : RuleTile.TilingRule.Neighbor {
        public const int Any = 3;
        public const int Specified = 4;
        public const int Nothing = 5;
    }

    public override bool RuleMatch(int neighbor, TileBase tile) {
        switch (neighbor) {
            case Neighbor.This: return CheckThis(tile);
            case Neighbor.NotThis: return CheckNotThis(tile);
            case Neighbor.Any: return CheckAny(tile);   
            case Neighbor.Specified: return CheckSpecified(tile);
            case Neighbor.Nothing: return CheckNothing(tile);
        }
        return base.RuleMatch(neighbor, tile);
    }

    private bool CheckThis(TileBase tile)
    {
        if(onlyThisTile) return tile == this;
        else return TilesToConnectTo.Contains(tile) || tile == this;
    }
    private bool CheckNotThis(TileBase tile)
    {
        return tile != this;
    }
    private bool CheckSpecified(TileBase tile)
    {
        return TilesToConnectTo.Contains(tile);
    }
    private bool CheckAny(TileBase tile)
    {
        if (CheckSelf) return tile != null;
        else return tile !=null && tile !=this;
    }
    private bool CheckNothing(TileBase tile)
    {
        return tile == null;
    }
}
