using Multithread.Lib;

namespace Multithread.Tests;

public class Tests
{
    private Producer _producer;
    private Consumer _consumer;
    private BlockingQueue _queue;
    
    [SetUp]
    public void Setup()
    {
        _queue = new BlockingQueue(100); 
        _producer = new Producer(_queue);
        _consumer = new Consumer(_queue);
    }

    [Test]
    public void Multithread_Naive()
    {
        _producer.Produce(10);
        var result = _consumer.Consume();
        Assert.That(result, Is.EqualTo(0));
    }
    
    
    [Test]
    public void Multithread_TwoProducers()
    {
        var producerCount = 10;
        var t1 = Task.Run(() => { _producer.Produce(producerCount); });
        var t2 = Task.Run(() => { _producer.Produce(producerCount); });
        Task.WaitAll(t1, t2);

        Assert.That(_queue, Has.Count.EqualTo(producerCount * 2));
    }
    
    
    [Test]
    public void Multithread_TwoProducersOneConsumer()
    {
        var producerCount = 1000;
        var t1 = Task.Run(() => { _producer.Produce(producerCount); });
        var t2 = Task.Run(() => { _producer.Produce(producerCount); });

        var result = new List<int>();
        while (_queue.Count is 0)
        {
            Thread.Sleep(1);
        }

        while (_queue.Count > 0)
        {
            result.Add(_consumer.Consume());
        }

        Assert.That(result, Has.Count.EqualTo(producerCount * 2));
    }
}