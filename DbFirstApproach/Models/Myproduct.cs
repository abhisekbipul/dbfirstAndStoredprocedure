using System;
using System.Collections.Generic;

namespace DbFirstApproach.Models;

public partial class Myproduct
{
    public int Pid { get; set; }

    public string? Pname { get; set; }

    public string? Pcat { get; set; }

    public string? Picture { get; set; }

    public double Price { get; set; }
}
