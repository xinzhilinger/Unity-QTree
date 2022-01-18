using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree 
{
    //�涨����������
    public int maxLayer;
    public Bounds bounds;
    public Node root;


    public Tree(int maxLayer,Bounds bounds)
    {
        this.maxLayer = maxLayer;
        this.bounds = bounds;
        root = new Node(bounds,0,this);
    }


    public void Insert(ObjData obj)
    {
        root.Insert(obj);
    }

    public void DrawLine()
    {
        root.DrawLine();
    }
}
