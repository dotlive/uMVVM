using System;
using System.Collections;
using System.Threading;

public class ThreadJob
{
    private volatile bool _isDown;
    private Thread _thread;

    private readonly Action _onBeginHandler;
    private readonly Action _onFinishHandler;

    public ThreadJob(Action onBeginHandler, Action onFinishedHandler)
    {
        this._onBeginHandler = onBeginHandler;
        this._onFinishHandler = onFinishedHandler;
    }

    public virtual void Start()
    {
        _thread = new Thread(Run);
        _thread.Start();
    }

    public virtual void Abort()
    {
        _thread.Abort();
    }

    public void ThreadHandler()
    {
        this._onBeginHandler?.Invoke();
    }

    public void OnFinished()
    {
        this._onFinishHandler?.Invoke();
    }

    public virtual bool Update()
    {
        if (_isDown)
        {
            OnFinished();
            return true;
        }

        return false;
    }

    public IEnumerator WaitFor()
    {
        while (!Update())
        {
            //暂停协同程序，下一帧再继续往下执行
            yield return null;
        }
    }

    private void Run()
    {
        ThreadHandler();
        _isDown = true;
    }
}
