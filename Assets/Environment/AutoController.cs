using Assets.Environment;
using DataStructureTEST;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;


public class AutoController : MonoBehaviour
{
    public Transform car;

    public Transform Obj1;
    public Transform Obj2;
    public Transform Obj3;
    public Transform Obj4;

    private LineRenderer lr;

    private Timeline Timeline;

    // Start is called before the first frame update
    void Start()
    {
        car = GetComponent<Transform>();
        lr = gameObject.GetComponent<LineRenderer>();
        Timeline = new Timeline(ReadSourceFile().ToList());

        Snapshot firstEver = Timeline.snapshots[0];
        Obj1.transform.position = firstEver.Obstackles[0].Distance;
        Obj2.transform.position = firstEver.Obstackles[1].Distance;
        Obj3.transform.position = firstEver.Obstackles[2].Distance;
        Obj4.transform.position = firstEver.Obstackles[3].Distance;
    }

    int i = 1;
    double timecounter = 0;
    double VehicleAngle = 0;
    Vector2 VehicleDirection;
    double VehicleSpeed;

    Vector3 Obj1VelocityVector;
    Vector3 Obj2VelocityVector;
    Vector3 Obj3VelocityVector;
    Vector3 Obj4VelocityVector;

    //Vector2 Obj1Position;
    // Update is called once per frame
    void Update()
    {
        timecounter += Time.deltaTime;
        Snapshot snapshot = Timeline.snapshots[i];
        Snapshot previous = Timeline.snapshots[i-1];
        // contorary to what you might think, the code is going to use
        // the previous snapshot as current, because the counter starts at 0 to 
        // avoid index out of bounds exception. so yeah, try to keep that in mind
        double dT = snapshot.Timestamp - previous.Timestamp; // deltatime

        if (timecounter >= dT)
        {
            VehicleSpeed = previous.VehicleSpeed;
            double VehicleYawRate = previous.YawRate;

            VehicleAngle += VehicleYawRate * dT;

            VehicleDirection = new Vector2(Mathf.Cos((float)VehicleAngle), Mathf.Sin((float)VehicleAngle));

            VehicleDirection.Normalize();

            //Debug.Log($"Angle: {VehicleAngle} | YawRate: {VehicleYawRate}");

            //Obj1Position = previous.Obstackles[0].Distance;

            Obj1VelocityVector = (Vector3)previous.Obstackles[0].Distance;
            Obj2VelocityVector = (Vector3)previous.Obstackles[1].Distance;
            Obj3VelocityVector = (Vector3)previous.Obstackles[2].Distance;
            Obj4VelocityVector = (Vector3)previous.Obstackles[3].Distance;


            ++i;
            if (i == Timeline.snapshots.Count) { i = 1; VehicleAngle = 0; car.position = new Vector3(); }
            timecounter = 0;
        }

        Vector3 finalVehicleDirection = (VehicleDirection * (float)VehicleSpeed) * (float)dT;
        //Vector3 obj1_finalDirection = Obj1Direction * (float)dT;

        Obj1.transform.position = car.position + Obj1VelocityVector;
        Obj2.transform.position = car.position + Obj2VelocityVector;
        Obj3.transform.position = car.position + Obj3VelocityVector;
        Obj4.transform.position = car.position + Obj4VelocityVector;

        lr.gameObject.SetActive(true);
        lr.positionCount = 2 * 4;
        lr.SetPosition(0, car.position);
        lr.SetPosition(1, Obj1.position);

        lr.SetPosition(2, car.position);
        lr.SetPosition(3, Obj2.position);

        lr.SetPosition(4, car.position);
        lr.SetPosition(5, Obj3.position);

        lr.SetPosition(6, car.position);
        lr.SetPosition(7, Obj4.position);


        car.position += finalVehicleDirection;
    }
    IEnumerable<Snapshot> ReadSourceFile()
    {
        IEnumerable<string> Snapshots = File.ReadAllLines("Assets/Environment/rawdata.csv").Skip(1);
        foreach (string snapshot in Snapshots)
        {
            string[] Data = snapshot.Split(',');
            // Data[0] is the line ID in excel so discard it as its not needed.

            List<Obstacle> objectList = new();
            objectList.Add(new Obstacle(float.Parse(Data[1]), float.Parse(Data[2]), float.Parse(Data[10]), float.Parse(Data[11])));
            objectList.Add(new Obstacle(float.Parse(Data[3]), float.Parse(Data[4]), float.Parse(Data[12]), float.Parse(Data[13])));
            objectList.Add(new Obstacle(float.Parse(Data[5]), float.Parse(Data[6]), float.Parse(Data[14]), float.Parse(Data[15])));
            objectList.Add(new Obstacle(float.Parse(Data[7]), float.Parse(Data[8]), float.Parse(Data[16]), float.Parse(Data[17])));
            double vehicleSpeed = double.Parse(Data[9]);
            double yawRate = double.Parse(Data[18]);
            double timestamp = double.Parse(Data[19]);

            yield return new Snapshot(objectList, vehicleSpeed, yawRate, timestamp);
        }
    }
}
