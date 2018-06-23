using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;
using UnityEditor;
using UnityEngine.UI;

public static class AutoUICodeEditor
{
    [MenuItem("Editor/AutoUICode")]
    public static void AutoUICode()
    {
        CreateCSharp();
    }

    private static void CreateCSharp()
    {
        foreach(GameObject activeGO in Selection.gameObjects )
        {
            string filePath = AssetDatabase.GetAssetOrScenePath(activeGO);
            filePath = filePath.Substring(0, filePath.LastIndexOf('/'));
            filePath += '/' + activeGO.name + ".cs";
            using (FileStream fs = File.Create(filePath))
            {
                using (StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.UTF8))
                {
                    WriteHead(sw,activeGO.name);
                    WriteValue(sw,activeGO);
                    sw.Flush();
                }
            }
            AssetDatabase.Refresh();
        }
    }

    private static void WriteHead(StreamWriter sw,string selectName)
    {
        string head = @"using System.Collections;
        using System.Collections.Generic;
        using UnityEngine;
        using UnityEngine.UI;
        public class " + selectName + " : MonoBehaviour{";

        sw.WriteLine(head);
    }

    private static void WriteValue(StreamWriter sw,GameObject root)
    {
        StringBuilder sb = new StringBuilder();

        var sprites = _WriteProperty<Image>(sb, root, "Sprite");
        var labels = _WriteProperty<Text>(sb, root, "Text");
        var buttons = _WriteProperty<Button>(sb, root, "Button");
        var sliders = _WriteProperty<Slider>(sb, root, "Slider");
        sw.WriteLine(sb.ToString());

        sw.WriteLine(@"private void Awake (){");
        sw.WriteLine(@"Transform root = transform;");

        sb.Length = 0;
        _WriteAwake(sb, sprites, root);
        _WriteAwake(sb, labels, root);
        _WriteAwake(sb, buttons, root);
        _WriteAwake(sb, sliders, root);
        sw.WriteLine(sb.ToString());

        sw.WriteLine(@"}}");
    }

    private static List<T> _WriteProperty<T>(StringBuilder _sb, GameObject _root
        , string _indexOf) where T : MonoBehaviour
    {
        T[] array = _root.GetComponentsInChildren<T>();
        List<T> list = new List<T>();
        foreach (var item in array)
        {
            if (item.name.Length != _indexOf.Length && item.name.IndexOf(_indexOf) >= 0)
            {
                string typeName = typeof(T).ToString();
                typeName = typeName.Substring(typeName.LastIndexOf('.')+1);
                _sb.AppendFormat("private {0} {1};", typeName
                    , GetName(item.name)).AppendLine();
                list.Add(item);
            }
        }
        return list;
    }

    private static void _WriteAwake<T>(StringBuilder _sb, List<T> _list,GameObject root)
        where T : MonoBehaviour
    {
        Transform rootTS = root.transform;
        string formatStr = "{0} = root.Find(\"{1}\").GetComponent<{2}>();";
        foreach (var item in _list)
        {
            string typeName = typeof(T).ToString();
            typeName = typeName.Substring(typeName.LastIndexOf('.') + 1);
            _sb.AppendFormat(formatStr, GetName(item.name), FindParent(item.transform, rootTS), typeName)
                .AppendLine();
        }
    }

    private static string GetName(string _name)
    {
        string itemName = _name;
        char ch = itemName[0];
        itemName = itemName.Remove(0, 1);
        itemName = itemName.Insert(0, char.ToLower(ch).ToString());
        return itemName;
    }


    private static string FindParent(Transform _item,Transform rootTS)
    {
        string path = null;
        for (int i = 0; i < 1000; i++)//这里不用while 防止死循环
        {
            if (_item != rootTS.transform)
            {
                if (string.IsNullOrEmpty(path))
                {
                    path = _item.name;
                }
                else
                {
                    path = _item.name + "/" + path;
                }
                _item = _item.parent;
            }
            else
            {
                break;
            }
        }
        return path;
    }
}