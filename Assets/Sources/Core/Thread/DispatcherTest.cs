using UnityEngine;
using System.Threading;
using AssemblyCSharp;
using System;

public class DispatcherTest : MonoBehaviour
{
    public UnityEngine.UI.InputField output;

    private void Start()
    {
        Debug.Log("Main Thread Id:" + Thread.CurrentThread.ManagedThreadId);
        for (var i = 0; i < 10; ++i)
        {
            var t = new Thread(ThreadFunction);
            t.Start("Dispatched from Thread :" + i);
        }
    }

    private void ThreadFunction(object param)
    {
        Debug.Log("Current Thread Id :" + Thread.CurrentThread.ManagedThreadId);
        try
        {
            UnityDispatcher.Current.BeginInvoke(() =>
            {
                Debug.Log(" Is Main Thread:" + Thread.CurrentThread.ManagedThreadId);

                output.text += param;
                output.text += "\n";
            });
        }
        catch (Exception e)
        {
            Debug.Log(e.ToString());
        }
    }
}
