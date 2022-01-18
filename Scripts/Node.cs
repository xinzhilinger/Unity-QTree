using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node 
{
    public Bounds bound;
    public int layer;
    public Tree belongTree;
    public Node[] childList;
    public List<ObjData> objList;

    public Node(Bounds bound,int layer,Tree belongTree)
    {
        this.bound = bound;
        this.layer = layer;
        this.belongTree = belongTree;

    }

    public void Insert(ObjData obj)
    {

        if (objList == null)
        {
            objList = new List<ObjData>();  
            objList.Add(obj);
            return;
        }
        if (childList == null&& layer+1 < belongTree.maxLayer)
        {
            CreateChildNode();
            for (int i = 0; i < childList.Length; i++)
            {
                if (childList[i].bound.Contains(objList[0].transform.position))
                {
                    childList[i].Insert(objList[0]);
                }
            }
        }
        if (layer+1 == belongTree.maxLayer)
        {
            objList.Add(obj);
            return;
        }
        for (int i = 0; i < childList.Length; i++)
        {
            if (childList[i].bound.Contains(obj.transform.position))
            {
                childList[i].Insert(obj);
            }

            

        }


    }

    public void Hind()
    {
        
    }
    //创建子节点
    public void CreateChildNode()
    {
        childList=new Node[4];
        int index = 0;
        for (int i = -1; i <= 1; i+=2)
        {
            for (int j = -1; j <= 1; j+=2)
            {
                Vector3 centerOffset = new Vector3(bound.size.x / 4 * i, 0, bound.size.z / 4 * j);
                Vector3 cSize = new Vector3(bound.size.x / 2, bound.size.y, bound.size.z / 2);
                Bounds cBound = new Bounds(bound.center + centerOffset, cSize);
                childList[index++] = new Node(cBound, layer + 1, belongTree);
            }
        }
    }

    public void DrawLine()
    {
        Gizmos.color = Color.red;   
        Gizmos.DrawWireCube(bound.center,bound.size);
        if (childList == null) return;
        foreach (var child in childList)
        {
            child.DrawLine();
        }
    }



}
