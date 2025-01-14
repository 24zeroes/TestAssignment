namespace Multithread.Lib;

public class Producer
{
    private readonly Queue<int> _queue;
    private object _queueLock;
    
    public Producer(Queue<int> queue)
    {
        _queue = queue;
        _queueLock = new object();
    }

    public void Produce(int valuesCount)
    {
        for (int i = 0; i < valuesCount; i++)
        {
            lock (_queueLock)
            {
                _queue.Enqueue(i);    
            }
        }
    }
}