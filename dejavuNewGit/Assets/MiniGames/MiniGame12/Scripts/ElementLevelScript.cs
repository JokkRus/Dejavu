using UnityEngine;
using System.Collections;

public class ElementLevelScript : MonoBehaviour {
    public int[,] lvl0;
    public int[,] lvl1;
    public int[,] lvl2;
    public int[,] lvl3;
    public int[,] lvl4;
    public int[,] lvl5;
    public int[] questlvl;
    public ElementLevelScript()
    {
        lvl0 = new int[,]
        {
            {3,3,3,3,0,0,4,4,5,3},
            {0,1,2,3,4,5,0,1,2,2}
        };
        lvl1 = new int[,]
        {
            {0,1,2,3,4,5,0,1,2,0},
            {1,1,1,1,2,3,4,5,0,1}
        };
        lvl2 = new int[,]
        {
            {1,1,1,1,0,0,5,2,2,1 },
            {1,2,3,4,5,0,0,0,0,0 }
        };
        lvl3 = new int[,]
        {
            {5,5,4,3,2,1,0,5,5,5 },
            {4,4,4,4,5,5,0,0,1,4 }
        };
        lvl4 = new int[,]
        {
            {4,4,4,4,3,3,3,1,5,4 },
            {4,2,3,0,1,1,5,5,5,5 }
        };
        lvl5 = new int[,]
        {
            {2,2,0,0,1,1,5,5,3,2 },
            {0,3,5,4,3,1,3,2,3,3 }
        };
        questlvl = new int[]
        {
            0,1,0,1,0,1
        };
    }
}
