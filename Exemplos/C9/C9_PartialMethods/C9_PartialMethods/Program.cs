using System;

namespace C9_PartialMethods
{
    //partial class MyService : IMyService
    //{
    //    partial void MyFirstFunction(); // Ok
    //                                    // CS0750 A partial method cannot have access modifiers or the virtual, abstract, override, new, sealed, or extern modifiers
    //    private partial void MySecondFunction();

    //    // CS0750 A partial method cannot have .....
    //    private partial void MyThirdFunction();

    //    // CS0750 E CS0766 Partial methods must have a void return type
    //    private partial object MyFourthFunction();

    //    // CS0750 E CS0766 Partial methods must have a void return type
    //    private partial object MyFifthFunction();

    //    // CS0750 E CS0752 A partial method cannot have out parameters
    //    private partial void MySixthFunction(out int result);

    //    // CS0750 A partial method cannot have .....
    //    public partial void MySeventhFunction();
    //}

    //partial class MyService
    //{
    //    // CS0750 A partial method cannot have .....
    //    private partial void MyThirdFunction() { }


    //    // CS0750 E CS0766 Partial methods must have a void return type
    //    private partial object MyFifthFunction() { return new { }; }

    //    // CS0750 E CS0752 A partial method cannot have out parameters
    //    private partial void MySixthFunction(out int result) { result = 42; return; }

    //    // CS0750 A partial method cannot have .....
    //    public partial void MySeventhFunction() { }
    //}

    //public interface IMyService
    //{
    //    void MySeventhFunction();
    //}


    partial class MyService : IMyService
    {
        partial void MyFirstFunction(); // Ok

        // CS8795 Partial method must have an implementation part because it has accessibility modifiers
        //private partial void MySecondFunction();
        private partial void MyThirdFunction(); // Ok

        // CS8795 Partial method must have an implementation part ....
        //private partial object MyFourthFunction();
        private partial object MyFifthFunction(); // Ok
        private partial void MySixthFunction(out int result);
        public partial void MySeventhFunction(); // Ok
    }

    partial class MyService
    {
        private partial void MyThirdFunction() { } // Ok
        private partial object MyFifthFunction() { return new { }; } // Ok
        private partial void MySixthFunction(out int result) { result = 42; return; } // Ok
        public partial void MySeventhFunction() { } // Ok
    }

    public interface IMyService
    {
        void MySeventhFunction();
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
