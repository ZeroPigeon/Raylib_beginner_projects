using System.Numerics;
using Raylib_cs;

const int screenWidth = 800;
const int screenHeight = 600;
int state = 0;

Raylib.InitWindow(screenWidth, screenHeight, "Particle Simulator");
Raylib.SetTargetFPS(60);

//SnowFlake list
List<SnowFlake> flakes = new List<SnowFlake>();

//RainDrop List
List<RainDrop> drops = new List<RainDrop>();

//Fire List
List<FireParticle> fire = new List<FireParticle>();

Color[] fireColors = new Color[]
{
    Color.Orange,
    Color.Yellow,
    Color.Red
};

float deltaTime;
float rainWind;

rainWind = Raylib.GetRandomValue(-100, 100);

while (!Raylib.WindowShouldClose())
{

    if (Raylib.IsKeyPressed(KeyboardKey.Space))
    {
        
        rainWind = Raylib.GetRandomValue(-100, 100);

    }

    deltaTime = Raylib.GetFrameTime();

    if (Raylib.IsKeyPressed(KeyboardKey.S))
    {
        
        state = 0;
        drops.Clear();
        fire.Clear();

    }

    if (Raylib.IsKeyPressed(KeyboardKey.R))
    {
        
        state = 1;
        flakes.Clear();
        fire.Clear();

    }

    if (Raylib.IsKeyPressed(KeyboardKey.F))
    {
        
        state = 2;
        drops.Clear();
        flakes.Clear();

    }

    //SnowFlake state
    if (state == 0)
    {

        for (int i = 0; i <= 1; i++)
        {
            
            SpawnSnowParticle();

        }

    }else if (state == 1)
    {
        
        for (int i = 0; i <= 5; i++)
        {
            
            SpawnRainParticle();

        }

    }else if (state == 2)
    {
        
        for (int i = 0; i <= 20; i++)
        {
            
            SpawnFireParticle();

        }

    }

    for (int i = flakes.Count() - 1; i >= 0; i--)
    {
        
        flakes[i].position.Y += flakes[i].velocity.Y * deltaTime;
        flakes[i].position.X += flakes[i].velocity.X * deltaTime;   
        flakes[i].driftTimer -= deltaTime;

        if (flakes[i].driftTimer <= 0)
        {
            
            int velocity_X = Raylib.GetRandomValue(-30, 30);
            float driftTimer = Raylib.GetRandomValue(1, 5);

            flakes[i].velocity.X = velocity_X;
            flakes[i].driftTimer = driftTimer;

        }

        if (flakes[i].position.Y + flakes[i].flakeRadius >= screenHeight)
        {
            
            flakes.RemoveAt(i);

        }

    }

    for (int i = drops.Count() - 1; i >= 0; i--)
    {
        
        drops[i].position.Y += drops[i].velocity.Y * deltaTime;
        drops[i].position.X -= rainWind * deltaTime;

        if (drops[i].position.Y + drops[i].height >= screenHeight)
        {
            
            drops.RemoveAt(i);

        }

    }

    for (int i = fire.Count() - 1; i >= 0; i--)
    {
        
        fire[i].velocity.Y += fire[i].accelaration * deltaTime;
        fire[i].velocity.X += fire[i].accelaration * deltaTime;

        fire[i].position.Y -= fire[i].velocity.Y * deltaTime;
        fire[i].position.X += fire[i].velocity.X * deltaTime;   
        fire[i].lifeTime -= deltaTime;
        fire[i].driftTimer -= deltaTime;

        if (fire[i].driftTimer <= 0)
        {
            
            int velX = Raylib.GetRandomValue(-50, 50);
            float driftTimer = Raylib.GetRandomValue(1, 4);

            fire[i].velocity.X = velX;
            fire[i].driftTimer = driftTimer;

        }

        if (fire[i].lifeTime <= 0)
        {
            
            fire[i].radius -= 2 * deltaTime;
            fire[i].accelaration += 100 * deltaTime;


            if (fire[i].radius <= 2)
            {
                
                fire.RemoveAt(i);

            }

        }

    }

    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.Black);    

    for (int i = 0; i <= flakes.Count() - 1; i++)
    {
       
        Raylib.DrawCircle((int)flakes[i].position.X, (int)flakes[i].position.Y, (int)flakes[i].flakeRadius, Color.White);

    }

    for (int i = 0; i <= drops.Count() - 1; i++)
    {
        
        Raylib.DrawRectanglePro( new Rectangle(
                                (int)drops[i].position.X,
                                (int)drops[i].position.Y,
                                drops[i].width,
                                drops[i].height
                            ),
                            new Vector2(drops[i].width / 2, drops[i].height / 2),
                                drops[i].angle,
                                Color.DarkBlue
        );

    }

    for (int i = 0; i <= fire.Count - 1; i++)
    {
        
        Raylib.DrawCircle((int)fire[i].position.X, (int)fire[i].position.Y, fire[i].radius, fire[i].fireColor);

    }

    Raylib.EndDrawing();

}

Raylib.CloseWindow();

void SpawnSnowParticle()
{
    
    int XPos = Raylib.GetRandomValue(10, screenWidth - 10);
    int YPos = -10;

    int velocity_Y = Raylib.GetRandomValue(50, 100);
    int velocity_X = Raylib.GetRandomValue(-30, 30);
    int radius = Raylib.GetRandomValue(2, 7);

    float driftTimer = Raylib.GetRandomValue(1, 5);

    flakes.Add(new SnowFlake(XPos, YPos, velocity_X, velocity_Y, radius, driftTimer));

}

void SpawnRainParticle() 
{
    
    int XPos = Raylib.GetRandomValue(-50, screenWidth + 50);
    int YPos = -10;

    int velocity_Y = Raylib.GetRandomValue(450, 600);
    int velocity_X = 0;
    int width = Raylib.GetRandomValue(2, 4);
    int height = Raylib.GetRandomValue(30, 35);
    float angle = rainWind / 10;

    drops.Add(new RainDrop(XPos, YPos, width, height, velocity_X, velocity_Y, angle));   

}

void SpawnFireParticle()
{
    
    int XPos = Raylib.GetRandomValue(10, screenWidth - 10);
    int YPos = screenHeight;

    float accelaration = 0;

    int velX = Raylib.GetRandomValue(-50, 50);
    int velY = Raylib.GetRandomValue(100, 150);

    float radius = Raylib.GetRandomValue(3, 6);
    
    float lifeTime = Raylib.GetRandomValue(500, 1500) / 1000;
    float driftTimer = Raylib.GetRandomValue(1, 4);

    Random random = new Random();
    float rand = random.NextSingle();

    Color color;

    if (rand >= 0.7)
    {
        color = fireColors[0];

    }else if (rand >= 0.4)
    {
        
        color = fireColors[1];

    }
    else
    {
        
        color = fireColors[2];

    }

    fire.Add(new FireParticle(XPos, YPos, accelaration, velX, velY, radius, lifeTime, driftTimer, color));

}