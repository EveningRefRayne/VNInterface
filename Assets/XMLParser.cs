using UnityEngine;
using System.Collections;
using System.Xml;
using System.Collections.Generic;

public class XMLParser : MonoBehaviour
{
    private string path;
    private XmlDocument xmlDoc;
    private string xmlFile;


    void Awake()
    {
        xmlFile = "VNXML.xml";
    }

    void Start()
    {
        loadXMLFromAsset();
        readXml();
    }
    // Following method load xml file from resouces folder under Assets
    private void loadXMLFromAsset()
    {
        xmlDoc = new XmlDocument();
        if (System.IO.File.Exists(getPath()))
        {
            xmlDoc.LoadXml(System.IO.File.ReadAllText(getPath()));
            Debug.Log("Loaded xml into xmlDoc");
        }
        else
        {
            Debug.LogError("Could not find file: \"" + xmlFile + "\""+" in "+getPath());
            return;
        }
    }

    // Following method reads the xml file and display its content
    private void readXml()
    {
        Debug.Log("Reading XML");
        foreach (XmlElement node in xmlDoc.SelectNodes("Conversations/Conversation"))
        {
            Debug.Log("Node value: "+node.Value);
            string name;
            string speech;
            name = node.SelectSingleNode("Name").InnerText;
            speech = node.SelectSingleNode("Text").InnerText;

            Debug.Log("Name= " + name + " Text= " + speech);
        }
    }


    private string getPath()
    {
        Debug.Log(Application.dataPath + "/" + xmlFile);
        return Application.dataPath + "/" + xmlFile;
    }

}