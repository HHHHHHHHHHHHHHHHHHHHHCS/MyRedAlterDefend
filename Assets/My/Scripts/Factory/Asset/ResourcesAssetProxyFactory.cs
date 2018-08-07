using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesAssetProxyFactory : IAssetFactory
{
    private ResourcesFactory factory = new ResourcesFactory();
    private Dictionary<string, GameObject> soldiers = new Dictionary<string, GameObject>();
    private Dictionary<string, GameObject> enemys = new Dictionary<string, GameObject>();
    private Dictionary<string, GameObject> weapons = new Dictionary<string, GameObject>();
    private Dictionary<string, GameObject> effects = new Dictionary<string, GameObject>();
    private Dictionary<string, AudioClip> audioClips = new Dictionary<string, AudioClip>();
    private Dictionary<string, Sprite> sprites = new Dictionary<string, Sprite>();


    public AudioClip LoadAudioClip(string _name)
    {
        AudioClip result;
        if (!audioClips.TryGetValue(_name, out result))
        {
            result = factory.LoadAudioClip(_name);
            audioClips.Add(_name, result);
        }
        return result;
    }

    public GameObject LoadEffect(string _name)
    {
        GameObject result;
        if (!effects.TryGetValue(_name, out result))
        {
            result = factory.LoadEffect(_name);
            effects.Add(_name, result);
            return result;
        }
        return InstantiateGameObject(result);
    }

    public GameObject LoadEnemy(string _name)
    {
        GameObject result;
        if (!enemys.TryGetValue(_name, out result))
        {
            result = factory.LoadEnemy(_name);
            enemys.Add(_name, result);
            return result;
        }
        return InstantiateGameObject(result);
    }

    public GameObject LoadSoldier(string _name)
    {
        GameObject result;
        if (!soldiers.TryGetValue(_name, out result))
        {
            result = factory.LoadSoldier(_name);
            soldiers.Add(_name, result);
            return result;
        }
        return InstantiateGameObject(result);
    }

    public Sprite LoadSprite(string _name)
    {
        Sprite result;
        if (!sprites.TryGetValue(_name, out result))
        {
            result = factory.LoadSprite(_name);
            sprites.Add(_name, result);
        }
        return result;
    }

    public GameObject LoadWeapon(string _name)
    {
        GameObject result;
        if (!weapons.TryGetValue(_name, out result))
        {
            result = factory.LoadWeapon(_name);
            weapons.Add(_name, result);
            return result;
        }
        return InstantiateGameObject(result);
    }

    public GameObject InstantiateGameObject(GameObject prefab)
    {
        if (prefab == null)
        {
            Debug.Log("InstantiateGameObject failing! prefab is null!");
            return null;
        }
        return Object.Instantiate(prefab);
    }
}
