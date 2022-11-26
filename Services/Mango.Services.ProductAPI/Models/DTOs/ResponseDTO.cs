using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mango.Services.ProductAPI.Models.DTOs;

public class ResponseDTO<T>
{
    public bool IsSuccess { get; set; } = true;
    public T? Result { get; set; } 
    public string? DisplayMessage { get; set; }
    public List<string>? ErrorsMessages { get; set; }

}
