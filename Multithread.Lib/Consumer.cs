namespace Multithread.Lib;

public class Consumer
{
    private readonly Queue<int> _queue;
 
    public Consumer(Queue<int> queue)
    {
        _queue = queue;
    }

    public int Consume()
    {
        var res = _queue.Dequeue();
        Console.WriteLine($"Consuming from queue: {_queue.Count} value {res}"); 
        return res;
    }
}