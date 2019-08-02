using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LinesScript {
    public int[,] line1;
    public int[,] line2;
    public int[,] line3;
    public int[,] line4;
    public int[,] line5;
    public int[,] line6;
    public List<int[,]> list;
    public LinesScript()
    {
        list = new List<int[,]>();
        line1 = new int[,]
        {
            {90 },
            {270 }
        };
        line2 = new int[,]
        {
            {270, 90,270,0},
            {270, 270,0,180}
        };
        line3 = new int[,]
        {
            {180, 90,90,0},
            {180, 270,0,180}
        };
        line4 = new int[,]
        {
            {90, 90,90,0},
            {90, 270,180,180}
        };
        line5 = new int[,]
        {
            {0, 90,270,0},
            {0, 270,180,180}
        };
        line6 = new int[,]
        {
            {90,90},
            {270,270}
        };
        list.Add(line1);
        list.Add(line2);
        list.Add(line3);
        list.Add(line4);
        list.Add(line5);
        list.Add(line6);
    }
}
