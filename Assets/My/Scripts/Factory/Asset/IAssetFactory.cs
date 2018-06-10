using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAssetFactory
{
    GameObject LoadSoldier(string _name);
    GameObject LoadEnemy(string _name);
    GameObject LoadWeapon(string _name);
    GameObject LoadEffect(string _name);
    AudioClip LoadAudioClip(string _name);
    Sprite LoadSprite(string _name);
}
