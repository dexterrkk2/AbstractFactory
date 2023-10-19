using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Client : MonoBehaviour
{
    public int NumberofWheels;
    public bool Engine;
    public int Passengers;
    public bool Cargo;
    public Text text;
    public Text passengers;
    public Text Wheels;
    VehicleRequirements requirements;
    IVehicle v;
    private void Start()
    {
        NumberofWheels = Mathf.Max(NumberofWheels, 1);
        Passengers = Mathf.Max(Passengers, 1);
        Engine = Cargo;

        requirements = new VehicleRequirements();
        UpdateRequirements();
    }
    public void Update()
    {
        text.text = "" + v;
        passengers.text = "Number of Passengers" + Passengers;
        Wheels.text = "Number of Wheels" + NumberofWheels;
    }
    private static IVehicle GetVehicle(VehicleRequirements requirements)
    {
        VehicleFactory factory = new VehicleFactory(requirements);
        return factory.Create();
    }
    public void UpdateRequirements()
    {
        requirements.NumberOfWheels = NumberofWheels;
        requirements.Engine = Engine;
        requirements.Passengers = Passengers;
        v = GetVehicle(requirements);
    }
    public void UpdateWheels(int num)
    {
        NumberofWheels += num;
    }
    public void UpdatePassengers(int num)
    {
        Passengers += num;
    }
    public void UpdateEngine()
    {
        Engine = !Engine;
    }
    public void UpdateCargo()
    {
        Cargo = !Cargo;
    }
}
