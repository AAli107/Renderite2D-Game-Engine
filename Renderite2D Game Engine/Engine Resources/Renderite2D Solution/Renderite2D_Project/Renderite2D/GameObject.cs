using OpenTK.Mathematics;
using Renderite2D_Project.Renderite2D.Components;
using System;
using System.Collections.Generic;

namespace Renderite2D_Project.Renderite2D
{
    public class GameObject
    {
        public bool IsEnabled { get { return isEnabled; } set { isEnabled = value; } }

        public Transform2D transform = new();
        
        bool isEnabled = true;
        readonly List<Component> components = new();

        public GameObject() { }
        public GameObject(Transform2D transform) => this.transform = transform;
        public GameObject(Vector2d position) => transform.position = position;


        public void Update()
        {
            for (int i = 0; i < components.Count; i++)
                if (components[i].IsEnabled && components[i] is not PhysicsComponent && components[i] is not ColliderComponent)
                    components[i]?.FixedUpdate();

            // The Two for loops below will force the Physics Components within the game objects to update before the colliders
            for (int i = 0; i < components.Count; i++)
                if (components[i] is PhysicsComponent)
                    components[i]?.FixedUpdate();
            for (int i = 0; i < components.Count; i++)
                if (components[i] is ColliderComponent)
                    components[i]?.FixedUpdate();

            Update_();
        }

        protected virtual void Update_() { }

        public Component[] GetAllComponents()
        {
            return components.ToArray();
        }

        public T AddComponent<T>() where T : Component
        {
            T component = (T)(typeof(T).GetConstructor(new Type[] { typeof(GameObject) })).Invoke(new object[] { this });
            components.Add(component);
            return component;
        }

        public T GetComponent<T>() where T : Component
        {
            for (int i = 0; i < components.Count; i++)
            {
                if (components[i] is T)
                    return components[i] as T;
            }
            return null;
        }

        public T[] GetComponents<T>() where T : Component
        {
            List<T> foundComponents = new();
            for (int i = 0; i < components.Count; i++)
            {
                if (components[i] is T t)
                    foundComponents.Add(t);
            }
            return foundComponents.ToArray();
        }
    }
}
