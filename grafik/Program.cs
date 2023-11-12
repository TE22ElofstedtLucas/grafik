﻿﻿using Raylib_cs;
using System.Numerics;

// - Vektorer för förflyttning
// - Vektorer för positioner (cirklar)
// - Rektanglar
// - Texturer
// - Färger
// - Input

// - Olika scener
// - Kollisioner

Raylib.InitWindow(800, 600, "Hello");
Raylib.SetTargetFPS(60);

int floorY = 550;
int floorSpeedY = -1;
Vector2 movement = new Vector2(0.1f, 0.1f);
Color hotPink = new Color(255, 105, 180, 255);


Texture2D characterImage = Raylib.LoadTexture("Katt.png");
Rectangle characterRect = new Rectangle(10, 10, 32, 32);
characterRect.width = characterImage.width;
characterRect.height = characterImage.height;

List<Rectangle> walls = new();
walls.Add(new Rectangle(32,32,32,128));
walls.Add(new Rectangle(64,32,128,32));
walls.Add(new Rectangle(192,32,32,128));
walls.Add(new Rectangle(256,32,32,128));

Rectangle doorRect = new Rectangle(760, 460, 32, 32);

float speed = 5;

string scene = "start";

int points = 0;

while (!Raylib.WindowShouldClose())
{
  // --------------------------------------------------------------------------
  // GAME LOGIC
  // --------------------------------------------------------------------------

  if (scene == "start")
  {
    if (Raylib.IsKeyDown(KeyboardKey.KEY_SPACE))
    {
      scene = "game";
    }
  }
  else if (scene == "game")
  {
    movement = Vector2.Zero;

    // kod här: läsa in knapptryck, ändra på movement
    if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
    {
      movement.X = -1;
    }
    else if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
    {
      movement.X = 1;
    }
    if (Raylib.IsKeyDown(KeyboardKey.KEY_UP))
    {
      movement.Y = -1;
    }
    else if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN))
    {
      movement.Y = 1;
    }

    if (movement.Length() > 0)
    {
      movement = Vector2.Normalize(movement);
    }

    movement *= speed;

    characterRect.x += movement.X;
    characterRect.y += movement.Y;

    if (characterRect.x < 0 || characterRect.x > 800-64)
    {
      characterRect.x -= movement.X;
    }
    if (characterRect.y < 0 || characterRect.y > 600-64)
    {
      characterRect.y -= movement.Y;
    }

    if (Raylib.CheckCollisionRecs(characterRect, doorRect))

    foreach (Rectangle wall in walls)
    {
      points++;
    }

    // x++;
    // floorY += floorSpeedY;
    // if (floorY < 0)
    // {
    //   floorSpeedY = 1;
    // }
    // else if (floorY > 550)
    // {
    //   floorSpeedY = -1;
    // }

    // position += movement;
  }

  // --------------------------------------------------------------------------
  // RENDERING
  // --------------------------------------------------------------------------

  Raylib.BeginDrawing();
  if (scene == "start")
  {
    Raylib.ClearBackground(Color.SKYBLUE);
    Raylib.DrawText("Press SPACE to start", 10, 10, 32, Color.BLACK);
  }
  else if (scene == "game")
  {
    Raylib.ClearBackground(Color.GOLD);

    Raylib.DrawRectangle(0, floorY, 800, 30, Color.BLACK);

    
    Raylib.DrawTexture(characterImage, (int)characterRect.x, (int)characterRect.y, Color.WHITE);

    Raylib.DrawRectangleRec(doorRect, Color.BROWN);

      Raylib.DrawRectangleRec(wall1, Color.BLACK);
      Raylib.DrawRectangleRec(wall2, Color.BLACK);
      Raylib.DrawRectangleRec(wall3, Color.BLACK);

    Raylib.DrawText($"Points: {points}", 10, 10, 32, Color.WHITE);

  }

  Raylib.EndDrawing();
}