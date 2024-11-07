using System;
using System.Collections.Generic;
using System.Reflection;

namespace Renderite2D_Project.Renderite2D
{
    public class GameObject
    {
        public bool IsEnabled { get { return isEnabled; } set { isEnabled = value; } }

        public Transform2D transform = new();
        
        bool isEnabled = true;
        readonly List<Component> components = new();

        public void Update()
        {
            if (!IsEnabled) return;

            for (int i = 0; i < components.Count; i++)
                if (components[i] != null && components[i].IsEnabled)
                    components[i]?.Update();
        }

        public Component[] GetAllComponents()
        {
            return components.ToArray();
        }

        public T AddComponent<T>() where T : Component
        {
            ConstructorInfo constructor = typeof(T).GetConstructor(new Type[] { typeof(GameObject) });
            T component = (T)constructor.Invoke(new object[] { this });
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
