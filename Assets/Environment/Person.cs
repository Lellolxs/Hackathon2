//using DataStructureTEST;
//using System.Collections;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using UnityEngine;

//public class Person : MonoBehaviour
//{
//    Timeline timeline;

//    public Transform Obj;
//    public int PersonID;

//    // Start is called before the first frame update
//    void Start()
//    {
//        //timeline = new Timeline(ReadSourceFile().ToList());
//        Obj = GetComponent<Transform>();
//        //for (int i = 1; i < timeline.snapshots.Count; ++i)
//        //{
//        //    Debug.Log($"{(timeline.snapshots[i].Timestamp - timeline.snapshots[i - 1].Timestamp) * 1000:F1}ms");
//        //}
//    }

//    private int i = 1;
//    // Update is called once per frame
//    private float timecounter = 0;
//    void Update()
//    {
//        timecounter += Time.deltaTime;

//        if (timecounter >= timeline.snapshots[i].Timestamp - timeline.snapshots[i - 1].Timestamp)
//        {
//            //Debug.Log(timeline.snapshots[i].Objects[0]);
//            DataStructureTEST.Object obj = timeline.snapshots[i].Objects[PersonID];

//            Obj.position = new Vector3(
//            obj.Distance.X, 
//            obj.Distance.Y, 1);

//            Debug.Log($"${timeline.snapshots[i + 1].Objects[1].Distance.X} == {timeline.snapshots[i].Objects[1].Distance.X + timeline.snapshots[i].Objects[1].Speed.X}");

//            i += 1;
//            if (i == timeline.snapshots.Count) { i = 1; }
//            timecounter = 0f;
//        }
//    }
//}
