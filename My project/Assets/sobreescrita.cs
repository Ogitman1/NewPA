using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sobreescrita : MonoBehaviour
{
    private int num2;

    public void Setting(int num2)
    {
        this.num2 = num2;
    }

    public int Retrieved()
    {
        return this.num2;
    }
    void Start()
    {
        Matematica mat = new Matematica();
        Fisica fis = new Fisica();
        num2 = Retrieved();
        Setting(1); // Set the value of num2
        Debug.Log(mat.Soma(11, 12)); // Sum of numbers 11 and 12
        Debug.Log(fis.Soma(11, 12)); // Method overridden from mat that adds 10
        Debug.Log(num2); // Print the value of the private variable num2
    }

    public class Matematica {
        public virtual int Soma(int a, int b)
        {
            return a + b;
        }
    }

    public class Fisica : Matematica
    {
        public override int Soma(int a, int b)
        {
            int resultado = base.Soma(a, b);
            int resultadofinal = resultado + 10;
            return resultadofinal;
        }
    }
}
