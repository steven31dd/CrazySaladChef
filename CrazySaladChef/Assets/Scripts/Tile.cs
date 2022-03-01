using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Tile properties
public class Tile : MonoBehaviour
{
    private bool _isFree = false;
    private Sprite _tileSprite;
    
    public bool IsFree { get { return _isFree; } set { _isFree = value; } }
    public Sprite TileSprite { get { return _tileSprite; }}
    public void SetTileImage(Image image)
    {
        _tileSprite.texture = image.;
    }

}
