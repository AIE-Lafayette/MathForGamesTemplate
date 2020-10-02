using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using static Raylib_cs.Raymath;
using Raylib_cs;
namespace raygamecsharp
{
    abstract class GameObject
    {
        protected Matrix4x4 _transform;
        protected Matrix4x4 _rotationMatrix;
        protected Matrix4x4 _translationMatrix;
        protected GameObject _parent;
        protected Vector3 _velocity;
        protected float _scale;
        private GameObject[] children;
        public bool HasParent
        {
            get
            {
                return _parent != null;
            }
        }


        public GameObject()
        {
            children = new GameObject[0];
            _scale = 1;
            _transform = MatrixIdentity();
            _rotationMatrix = MatrixIdentity();
            _translationMatrix = MatrixIdentity();
        }

        public GameObject(GameObject parent)
        {
            _scale = 1;
            _transform = MatrixIdentity();
            children = new GameObject[0];
            if (_parent != null)
            {
                _transform = _transform * _parent.GetTransform();
            }
            _rotationMatrix = MatrixIdentity();
            _translationMatrix = MatrixIdentity();
            _parent = parent;
        }

        public GameObject(Matrix4x4 transform, GameObject parent)
        {
            _scale = 1;
            _transform = transform;
            _parent = parent;
            _rotationMatrix = MatrixIdentity();
            _translationMatrix = MatrixIdentity();
            children = new GameObject[0];
        }

        public void SetParent(GameObject parent)
        {
            _parent = parent;
        }

        public void Translate(Vector3 direction)
        {
            _translationMatrix.Translation = direction;
        }

        public void Rotate(float angle)
        {
            _transform.M11 = (float)Math.Cos(angle);
            _transform.M13 = (float)Math.Sin(angle);
        }

        public Matrix4x4 GetTransform()
        {
            return _transform;
        }

        public virtual void SetScale(float scalar)
        {
            _scale = scalar;
        }

        public virtual void Update()
        {
            if(_parent != null)
            {
                _transform = _parent.GetTransform() * (_translationMatrix * _rotationMatrix * _scale);
                return;
            }
            
            _transform = _translationMatrix * _rotationMatrix * _scale;

            for (int i = 0; i < children.Length; i++)
            {
                children[i].Update();
            }
        }

        public abstract void Draw();
    }
}
