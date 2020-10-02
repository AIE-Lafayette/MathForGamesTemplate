using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace raygamecsharp
{
    class Scene
    {
        private Matrix4x4 _transform;
        private GameObject[] gameObjects;
        
        public Scene()
        {
            gameObjects = new GameObject[0];
        }

        public void AddGameObject(GameObject gameObject)
        {
            GameObject[] newObjects = new GameObject[gameObjects.Length + 1];
            for(int i = 0; i < gameObjects.Length; i++)
            {
                newObjects[i] = gameObjects[i];
            }
            newObjects[gameObjects.Length] = gameObject;
            gameObjects = newObjects;
        }

        public void Draw()
        {
            for(int i = 0; i < gameObjects.Length; i++)
            {
                gameObjects[i].Draw();
            }
        }

        public void Update()
        {
            for(int i = 0; i < gameObjects.Length; i++)
            {
                gameObjects[i].Update();
            }
        }
    }
}
