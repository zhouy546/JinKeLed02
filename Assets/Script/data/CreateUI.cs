﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateUI : MonoBehaviour {
    public GameObject[] Parents;

    public GameObject NodeL_Default;
    public GameObject NodeR_Default;
    public GameObject NodeL_Style00;
    public GameObject NodeR_Style00;
    public GameObject NodeL_Style01;
    public GameObject NodeR_Style01;
    public GameObject SunNode_Gongyi;
    public GameObject SunNode_ECO;


    public static List<GameObject> NodeObject = new List<GameObject>();

    public static List<GameObject> ECO_NodeObject = new List<GameObject>();

    public static List<GameObject> Gongyi_NodeObject = new List<GameObject>();

    public void initialization() {


        CreateDefault(ReadJson.NodeList, NodeL_Default, NodeR_Default, ValueSheet.ID_Node_keyValuePairs, NodeObject, Parents[0], ValueSheet.nodeCtrs);

        //CreateDefault(ReadJson.ECO_NodeList, NodeL_Default, NodeR_Default, ValueSheet.ID_ECO_Node_keyValuePairs, ECO_NodeObject, Parents[1], ValueSheet.ECO_nodeCtrs);

        //CreateDefault(ReadJson.Gongyi_NodeList, NodeL_Default, NodeR_Default, ValueSheet.ID_Gongyi_Node_keyValuePairs, Gongyi_NodeObject,Parents[2], ValueSheet.Gongyi_nodeCtrs);


        CreateSubNode(SunNode_ECO, new Vector3(10, 33, 0), ECO_NodeObject, Parents[1], ValueSheet.ECO_nodeCtrs);
        CreateSubNode(SunNode_Gongyi, new Vector3(10, 33, 0), Gongyi_NodeObject, Parents[2], ValueSheet.Gongyi_nodeCtrs);

        //for (int i = 0; i < ReadJson.NodeList.Count; i++)
        //{
        //   // Debug.Log(i);
        //    if (i % 2 == 0)
        //    {
        //        Vector3 pos = new Vector3(-50,16.3f, i * ValueSheet.NodeDistance);


        //            CreateObject<NodeCtr>(NodeL_Default, i, pos, NodeObject, Parents[0], ValueSheet.nodeCtrs);

        //    }
        //    else {

        //        Vector3 pos = new Vector3(50, 16.3f, i * ValueSheet.NodeDistance);


        //            CreateObject<NodeCtr>(NodeR_Default, i, pos, NodeObject, Parents[0], ValueSheet.nodeCtrs);
        //    }
        //    ValueSheet.ID_Node_keyValuePairs.Add(ReadJson.NodeList[i].ID, NodeObject[i]);
        //}
    }



    void CreateSubNode(GameObject SubNodeGameobject, Vector3 pos,List<GameObject> nodeObj, GameObject parent, List <SubNodeCTR> nodeCtr) {
        CreateObject<SubNodeCTR>(SubNodeGameobject, 0, pos, nodeObj, parent, nodeCtr);
    }



    void CreateDefault<T>(List<Node> nodes, GameObject Prefabs_L, GameObject Prefabs_R, Dictionary<int, GameObject> keyValuePairs,List<GameObject> nodeObj,GameObject parent, List<T> nodeCtr)
    {
        for (int j = 0; j < nodes.Count; j++)
        {
            if (j % 2 == 0)
            {
                Vector3 pos = new Vector3(-20, 16.3f, j * ValueSheet.NodeDistance);
                CreateObject<T>(Prefabs_L, j, pos, nodeObj, parent, nodeCtr);
            }
            else
            {
                Vector3 pos = new Vector3(20, 16.3f, j * ValueSheet.NodeDistance);
                CreateObject<T>(Prefabs_R, j, pos, nodeObj, parent, nodeCtr);
            }
            keyValuePairs.Add(nodes[j].ID, nodeObj[j]);
        }
    }

    private void CreateObject<t>(GameObject g,int i , Vector3 pos,List<GameObject> nodeobj,GameObject parent,List<t> nodeCtr) {

         g = Instantiate(g, pos, Quaternion.identity);

        g.name = i.ToString();

        nodeCtr.Add(g.GetComponent<t>());

       // g.GetComponent<NodeCtr>().FloatingAniamtion();

        g.transform.SetParent(parent.transform);

        nodeobj.Add(g);

    }
}
