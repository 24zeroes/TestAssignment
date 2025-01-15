namespace TestAssignmen.Multithread.Lib;

public class Producer
{
    private readonly BlockingQueue _queue;
    
    public Producer(BlockingQueue queue)
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