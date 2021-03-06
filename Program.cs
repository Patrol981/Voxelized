using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

using Voxelized.Engine.Windowing;
using Voxelized.Engine.Globals;
using Voxelized.Callbacks;
using Voxelized.Engine;

class Program {
  unsafe static void Main() {
    /*
    using (var window = new Voxelized.Windowing.Window(GameWindowSettings.Default, WindowSettings.GetNativeWindowSettings())) {
      // GLFW.SetKeyCallback(window.WindowPtr, KeyCallback.OnKeyPressed);
      // GLFW.SetMouseButtonCallback(window.WindowPtr, MouseCallback.OnMousePressed);
      window.Run();
    }
    */

    var engine = new EngineClass();
    engine.Run();

    GLFW.Terminate();
  }
}

