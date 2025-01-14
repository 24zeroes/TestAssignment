namespace Multithread.Lib;

public class Producer
{
    private readonly Queue<int> _queue;
    
    public Producer(Queue<int> queue)
    {
        _queue = queue;
    }

    public void Produce(int valuesCount)
    {
        for (int i = 0; i < valuesCount; i++)
        {
            _queue.Enqueue(i);
        }
    }
}