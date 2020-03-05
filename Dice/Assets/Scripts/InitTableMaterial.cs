using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    class InitTableMaterial : MonoBehaviour
    {
        [SerializeField] private GameObject[] _boxSides = new GameObject[5];

        private void Awake()
        {
            var material = TableMaterialLoader.LoadMaterialFromPlayerPrefs();
            foreach (var child in _boxSides)
            {
                child.GetComponent<Renderer>().material = material;
            }
        }
    }
}
