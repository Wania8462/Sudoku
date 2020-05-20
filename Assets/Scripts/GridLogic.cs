using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridLogic : MonoBehaviour
{
    [SerializeField] GameObject Grid; // объект
    // Start is called before the first frame update
    void Start()
    {
        for (int p = -4; p < 5; p++)
        
        for (int P = 0; P < 9; P++)
        
        Instantiate(Grid, new Vector3(p, P, 0), new Quaternion()); // (x, y, z) где будут стоять поле для цифр
    }

    // Update is called once per frame
    void Update()
    {

    }
}
