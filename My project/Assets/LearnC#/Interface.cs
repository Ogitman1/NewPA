using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interface : MonoBehaviour
{
    int aa = 12;
    int bb = 13;
    void LateUpdate(){
        Physics ph = new Physics();
        ph.calc(ref aa, ref bb);
    }
}

public interface IInteração{
    void calc(ref int a, ref int b);
    
}
public class Physics : MonoBehaviour, IInteração{
    public void calc(ref int aa, ref int bb){
        Debug.Log(aa + bb);
    }
}