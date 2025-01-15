namespace Multithread.Lib;

public class Consumer
{
    private readonly BlockingQueue _queue;
 
    public Consumer(BlockingQueue queue)
    {
        _queue = queue;
    }

    public int Consume()
    {
        var res = _queue.Dequeue();
        Console.WriteLine($"Consuming from queue: value {res}"); 
        return res;
    }
}