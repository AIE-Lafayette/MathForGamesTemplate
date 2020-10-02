using static Raylib_cs.Raylib;  // core methods (InitWindow, BeginDrawing())
using static Raylib_cs.Color;   // color (RAYWHITE, MAROON, etc.)
using static Raylib_cs.Raymath; // mathematics utilities and operations (Vector2Add, etc.)
using System.Numerics;          // mathematics types (Vector2, Vector3, etc.)
using Raylib_cs;

namespace raygamecsharp
{
    class Sphere : GameObject
    {
        private float _radius;
        private Color _color;

        
        public Sphere() : base()
        {
            _radius = 1;
            _color = BLUE;
        }
        /// <summary>
        /// Creates a sphere with the given radius and color.
        /// </summary>
        /// <param name="radius"> The radius or scale of the sphere.</param>
        /// <param name="color"> The color of the sphere.</param>
        /// /// <param name="parent"> The game object the sphere's transform will be childed to.</param>
        public Sphere(float radius, Color color, GameObject parent) : base(parent)
        {
            _radius = radius;
            _color = color;
        }

        /// <summary>
        /// Creates a sphere with the given radius and color.
        /// </summary>
        /// <param name="radius"> The radius or scale of the sphere.</param>
        /// <param name="color"> The color of the sphere.</param>
        public Sphere(float radius, Color color) : base()
        {
            _radius = radius;
            _color = color;
        }
        public override void SetScale(float radius)
        {
            _radius = radius;
        }

        public override void Draw()
        {
            DrawSphere(_transform.Translation, _radius, _color);
        }

    }
}
