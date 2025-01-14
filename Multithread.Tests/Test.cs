using Multithread.Lib;

namespace Multithread.Tests;

public class Tests
{
    private Producer _producer;
    private Consumer _consumer;
    private Queue<int> _queue;
    
    [SetUp]
    public void Setup()
    {
        _queue = new Queue<int>(); 
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
        var producerCount = 1000000;
        var t1 = Task.Run(() => { _producer.Produce(producerCount); });
        var t2 = Task.Run(() => { _producer.Produce(producerCount); });
        Task.WaitAll(t1, t2);

        Assert.That(_queue, Has.Count.EqualTo(producerCount * 2));
    }
}