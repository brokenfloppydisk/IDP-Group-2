using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDump : MonoBehaviour
{
    public void TestClick() {
        DataDump.Initialize();
        List<object> testInputs = new List<object>() {1,2,3,4,5,6,7,8,9,10};
        DataDump.CreateEntry("A","J",testInputs);
        foreach (IList<object> list in DataDump.ReadEntries("A1", "J26")) {
            foreach (object item in list) {
                Debug.Log(item);
            }
        }
    }
}
