using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternPractice.생성패턴
{
    // **** Product ****
    // Device의 Interface를 정의
    public interface Device
    {
        void Connect();
        void Disconnect();
    }

    // Device Interface를 상속받은 Camera Class
    public class Camera : Device
    {
        public void Connect()
        {
            Console.WriteLine("Camera Connected");
        }
        public void Disconnect()
        {
            Console.WriteLine("Camera Disconnected");
        }
    }

    // Device Interface를 상속받은 Light Class
    public class Light : Device
    {
        public void Connect()
        {
            Console.WriteLine("Camera Connected");
        }

        public void Disconnect()
        {
            Console.WriteLine("Camera Disconnected");
        }
    }

    // **** Creator ****
    public abstract class DeviceFactory
    {
        public Device CreateNewDevice()
        {
            Device device = CreateDevice();
            device.Connect();
            return device;
        }

        // Factory Method
        protected abstract Device CreateDevice();
    }

    public class CameraFactory : DeviceFactory
    {
        protected override Device CreateDevice()
        {
            return new Camera();
        }
    }

    public class LightFactory : DeviceFactory
    {
        protected override Device CreateDevice()
        {
            return new Light();
        }
    }

    public class FactoryMethod
    {
        public static void Run()
        {
            DeviceFactory factory = new CameraFactory();
            Device device = factory.CreateNewDevice();
            device.Disconnect();

            factory = new LightFactory();
            device = factory.CreateNewDevice();
            device.Disconnect();
        }
    }
}
