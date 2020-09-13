using ImGuiNET;
using ImGuiSfmlNet;
using SFML.Graphics;
using SFML.System;
using System;
using OpenTK.Graphics;
using SFML.Window;

namespace ImGuiSfmlTest
{
    class Program
    {
        static void Main(string[] args)
        {
            ContextSettings contextSettings = new ContextSettings(24, 0, 0);
            var window = new RenderWindow(new SFML.Window.VideoMode(640, 480), "ImGui + SFML + .Net = <3",Styles.Default ,contextSettings);

            OpenTK.Graphics.GraphicsMode graphicsMode = new OpenTK.Graphics.GraphicsMode(32, (int)contextSettings.DepthBits, (int)contextSettings.StencilBits, (int)contextSettings.AntialiasingLevel);
            OpenTK.Platform.IWindowInfo windowInfo = OpenTK.Platform.Utilities.CreateWindowsWindowInfo(window.SystemHandle);
            
            OpenTK.Graphics.GraphicsContext context = new OpenTK.Graphics.GraphicsContext(graphicsMode, windowInfo);
            context.MakeCurrent(windowInfo);
            context.LoadAll();


            window.SetFramerateLimit(60);
            ImGuiSfml.Init(window);

            window.Closed += (s, e) => window.Close();

            CircleShape shape = new CircleShape(100);
            shape.FillColor = Color.Green;

            Clock deltaClock = new Clock();
            while ( window.IsOpen )
            {
                window.DispatchEvents();

                ImGuiSfml.Update(window, deltaClock.Restart());

                ImGui.ShowDemoWindow();
                //ImGui.ShowTestWindow();

                /*
                ImGui.Begin("Hello, world!");
                ImGui.Button("Look at this pretty button");
                ImGui.End();
                */

                window.Clear();
                window.Draw(shape);
                ImGuiSfml.Render(window);
                window.Display();
            }
        }
    }
}
