using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

struct DiceMaterial
{
    public static DiceMaterial Metallic;
    public static DiceMaterial Plastick;

    static DiceMaterial()
    {
        Metallic = new DiceMaterial();
        Metallic.MetallicIntensity = 1;
        Metallic.Smoothness = 0.486f;

        Plastick = new DiceMaterial();
        Plastick.MetallicIntensity = 0;
        Plastick.Smoothness = 1;
    }

    public float MetallicIntensity;
    public float Smoothness;
}

