using Raylib_cs;

Raylib.InitWindow(800, 600, "Paint program");

List<Stroke> drawColor = new List<Stroke>(); 

Color[] colors = new Color[]
{
    Color.White,
    Color.Red,
    Color.Blue,
    Color.Green,
    Color.Brown,
    Color.Gold,
    Color.Orange,
    Color.Yellow,
};

int radius = 10;
int currentColor = 0;

bool eraser = false;

while(!Raylib.WindowShouldClose())
{

    if (Raylib.IsMouseButtonDown(0))
    {

        if (!eraser)
        {

            drawColor.Add(new Stroke((int)Raylib.GetMouseX(), (int)Raylib.GetMouseY(), radius, colors[currentColor]));

        } else
        {
            
            drawColor.Add(new Stroke((int)Raylib.GetMouseX(), (int)Raylib.GetMouseY(), radius, Color.Black));

        }

    } 

    if (Raylib.IsKeyPressed(KeyboardKey.E))
    {
        
        if (!eraser)
        {
            eraser = true;
        }
        else
        {
            eraser = false;
        }

    }

    if (Raylib.IsKeyPressed(KeyboardKey.Space))
    {
        
        drawColor.Clear();

    }

    if (Raylib.IsKeyPressed(KeyboardKey.Right))
    {
        
        radius++;

    }

    if (Raylib.IsKeyPressed(KeyboardKey.Left))
    {
        
        radius--;

    }

    if (Raylib.IsKeyPressed(KeyboardKey.A))
    {
        
        if (currentColor == 0)
        {
            
            currentColor = colors.Count() - 1;

        } else
        {
            
            currentColor--;

        }

    }

    if (Raylib.IsKeyPressed(KeyboardKey.D))
    {
        
        if (currentColor == colors.Count() - 1)
        {
            
            currentColor = 0;

        } else
        {
            
            currentColor++;

        } 

    }

    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.Black);

    foreach (Stroke stroke in drawColor)
    {
        
        Raylib.DrawCircle(stroke.X, stroke.Y, stroke.radius, stroke.color);

    }

    if (!eraser)
    {

        Raylib.DrawCircleLines(Raylib.GetMouseX(), Raylib.GetMouseY(), radius, colors[currentColor]);
    
    } else
    {
        
        Raylib.DrawCircleLines(Raylib.GetMouseX(), Raylib.GetMouseY(), radius, Color.RayWhite);

    }

    Raylib.EndDrawing();

}

Raylib.CloseWindow();