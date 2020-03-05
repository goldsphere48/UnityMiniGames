using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class UniqueRandom
{
    private List<int> _cache = new List<int>();
    private Random _random = new Random();

    public void ClearCahce()
    {
        _cache.Clear();
    }

    /// <summary>
    /// Return unique int from 0 to upBound exclude upBound
    /// </summary>
    /// <param name="upBound"></param>
    public int NextInt(int upBound)
    {
        bool isUnique = false;
        int value = 0;
        do
        {
            value = _random.Next(upBound);
            isUnique = !_cache.Contains(value);
            _cache.Add(value);
        } while (!isUnique);
        return value;
    }
}