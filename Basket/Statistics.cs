namespace Basket;

public class Statistics
{
    private double _min;
    private double _max;

    public double Min
    {
        get
        {
            if (this.Count == 0)
            {
                return 0;
            }
            else
            {
                return _min;
            }
        }
        set { _min = value; }
    }

    public double Max
    {
        get
        {
            if (this.Count == 0)
            {
                return 0;
            }
            else
            {
                return _max;
            }
        }
        set { _max = value; }
    }

    public double Sum { get; set; }
    public int Count { get; set; }

    public double Average
    {
        get
        {
            if (this.Count != 0)
            {
                return this.Sum / this.Count;
            }
            else
            {
                return 0;
            }
        }
    }

    public Statistics()
    {
        this.Count = 0;
        this.Sum = 0;
        this.Min = double.MaxValue;
        this.Max = double.MinValue;
    }

    public void AddItemValue(double price)
    {
        this.Count++;
        this.Sum += price;
        this.Min = Math.Min(price, this.Min);
        this.Max = Math.Max(price, this.Max);
    }
}