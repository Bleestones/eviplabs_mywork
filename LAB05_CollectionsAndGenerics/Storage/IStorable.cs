using System;
using System.Collections.Generic;
using System.Text;

namespace Storage
{
    public interface IStorable
    {
        string Id { get; set; }
        int InStock { get; set; }
    }
}
