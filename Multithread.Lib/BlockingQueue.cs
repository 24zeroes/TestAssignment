namespace Multithread.Lib;

public class BlockingQueue
{
    private int[] Items;
    private int MaxSize;
    private int CurrentSize;
    private int Tail;
    private int Head;
    private Semaphore SemCon;
    private Semaphore SemProd;
    private Semaphore SemLock;
    
    public int Count { get; private set; }   
    public BlockingQueue(int size)
    {
        MaxSize = size;
        CurrentSize = 0;
        Items = new int[size];
        Tail = 0;
        Head = 0;
        Count = 0;
        SemCon = new Semaphore(0, size);
        SemProd = new Semaphore(size, size);
        SemLock = new Semaphore(1, 1);
    }
    
    public void Enqueue(int data)
    {
        SemProd.WaitOne();
        SemLock.WaitOne();
        if (Tail == MaxSize) 
            Tail = 0;
        Items[Tail] = data;
        Tail++;
        Count++;
        SemLock.Release();
        SemCon.Release();
    }
    
    public int Dequeue()
    {
        int result;
        SemCon.WaitOne();
        SemLock.WaitOne();
        if (Head == MaxSize) 
            Head = 0;
        result = Items[Head];
        Head++;
        Count--;
        SemLock.Release();
        SemProd.Release();
        return result;
    }

}