using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PuzzleLevelScript {
    public int[,] lvl_0;
    public int[,] lvl_1;
    public int[,] lvl_2;
    public int[,] lvl_3;
    public int[,] lvl_4;
    public PuzzleLevelScript()
    {
     lvl_0 = new int[,]
    {
        {1,0,3,0,2,1,3,0,2 },
        {0,0,0,0,270,270,180,90,0},
        {270,180,500,180,270,0,180,270,0 }
    };
     lvl_1 = new int[,]
    {
        {2,3,2,1,4,1,0,0,3 },
        {90,180,90,90,0,270,180,90,270},
        {90,180,90,180,500,180,500,500,500 }
    };
    lvl_2 = new int[,]
    {
        {3,4,0,0,1,2,3,0,4 },
        {0,0,90,0,180,90,180,90,0},
        {0,500,500,180,90,90,180,270,500 }
    };
    lvl_3 = new int[,]
    {
        {1,1,0,0,4,0,3,0,1 },
        {0,270,0,0,0,0,180,90,270},
        {180,180,500,500,500,500,500,500,500 }
    };
    lvl_4 = new int[,]
    {
        {3,2,1,0,1,3,2,3,4 },
        {0,270,0,0,90,270,270,270,0},
        {0,270,270,180,0,270,270,270,500 }
    };
}
}
