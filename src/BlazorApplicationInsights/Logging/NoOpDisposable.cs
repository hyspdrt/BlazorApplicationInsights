// ReSharper disable once CheckNamespace
namespace BlazorApplicationInsights;
using System;

/// <summary>Dummy class used where we want a disposable instance that doesn't do anything</summary>
internal sealed class NoOpDisposable : IDisposable
{
    public static IDisposable Instance { get; } = new NoOpDisposable();
    private NoOpDisposable() { }
    public void Dispose() { }
}