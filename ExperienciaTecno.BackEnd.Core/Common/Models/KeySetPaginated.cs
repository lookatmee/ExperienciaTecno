namespace ExperienciaTecno.BackEnd.Core.Common.Models;

public class KeySetPaginated<T> where T : class
{
    public IEnumerable<T> Data { get; set; }
    public bool HasPrevious { get; set; }
    public bool HasNext { get; set; }
}
