using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using static Raylib_cs.Raymath;
using Raylib_cs;
namespace Examples
{
    abstract class GameObject
    {
        protected Matrix4x4 _transform;
        protected Matrix4x4 _rotationMatrix;
        protected Matrix4x4 _translationMatrix;
        protected GameObject _parent;
        protected Vector3 _velocity;
        protected float _scale;

        public GameObject()
        {
            _scale = 1;
            _transform = MatrixIdentity();
            if (_parent != null)
            {
                _transform = _transform * _parent.GetTransform();
            }
            _rotationMatrix = MatrixIdentity();
            _translationMatrix = MatrixIdentity();
        }

        public GameObject(GameObject parent)
        {
            _scale = 1;
            _transform = MatrixIdentity();
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
            if (_parent != null)
            {
                _transform = _transform * _parent.GetTransform();
            }
            _parent = parent;
            _rotationMatrix = MatrixIdentity();
            _translationMatrix = MatrixIdentity();
        }

        public void Translate(Vector3 direction)
        {
            _translationMatrix.Translation = direction;
        }

        public void Rotate(float angle)
        {
            _rotationMatrix = MatrixRotateY(angle);
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
        }

        public abstract void Draw();
    }
}
