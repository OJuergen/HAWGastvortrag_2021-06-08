using UnityEngine;

namespace HAWGastvortrag
{
    /// <summary>
    /// The base class for ScriptableObject events. These are persistent assets in your project folder.
    /// Objects can link to them and either invoke the event or register/unregister as listeners.
    /// This base class has a generic parameter type T that holds the event parameters. This can be a primitive type,
    /// a class or struct.
    /// </summary>
    /// <typeparam name="TAsset">The type of the event asset</typeparam>
    /// <typeparam name="TSource">The type of the event source object</typeparam>
    /// <typeparam name="TArgs">The type of the event parameters</typeparam>
    public abstract class ScriptableObjectEvent<TAsset, TSource, TArgs> : ScriptableObject where TAsset : ScriptableObjectEvent<TAsset, TSource, TArgs>
    {
        // we use a delegate with a source parameter so we can use the same event asset for multiple event sources.
        public delegate void EventDelegate(TSource source, TArgs args);

        private event EventDelegate Invoked;

        public void Invoke(TSource source, TArgs args)
        {
            Invoked?.Invoke(source, args);
        }

        public static TAsset operator +(ScriptableObjectEvent<TAsset, TSource, TArgs> a, EventDelegate listener)
        {
            a.Invoked += listener;
            return a as TAsset;
        }

        public static TAsset operator -(ScriptableObjectEvent<TAsset, TSource, TArgs> a, EventDelegate listener)
        {
            a.Invoked -= listener;
            return a as TAsset;
        }
    }
}