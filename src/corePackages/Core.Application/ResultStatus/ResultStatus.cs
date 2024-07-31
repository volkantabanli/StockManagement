using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Core.Application.ResultStatus;
public class ResultStatus
{
    public bool result { get; }
    public string message { get; }
    public object data { get; }

    public ResultStatus(bool result, string message)
    {
        this.result = result;
        this.message = message;
    }

    public ResultStatus(bool result, string message, object data)
        : this(result, message)
    {
        this.data = data;
    }
}
