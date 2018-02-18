using System;
using System.Collections.Generic;

namespace myLibrary.Models
{
    public interface IStore<T>
    {
        string Path { get; set; }
        List<T> GetCollection();

        T ConvertItem(string item);
    }
}