using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    class InitTableSpritePreview : MonoBehaviour
    {
        private void Awake()
        {
            GetComponent<Button>().image.sprite = TableMaterialLoader.LoadSpriteFromPlayerPrefs();
        }
    }
}
