using EcommerceShop.Application.Logging;
using EcommerceShop.Application.UseCases.Dto;
using EcommerceShop.DataAccess;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceShop.Implementation.Logging;

public class DatabaseUseCaseLogger : IUseCaseLogger
{
    private readonly DatabaseContext _databaseContext;
    public DatabaseUseCaseLogger(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }
    public void Log(UseCaseLog log)
    {
        var record = new Domain.UseCaseLog
        {
            UseCaseName = log.UseCaseName,
            Username = log.Username,
            ExecutedAt = DateTime.UtcNow,
            UseCaseData = JsonConvert.SerializeObject(log.UseCaseData)
        };

        _databaseContext.Add(record);
        _databaseContext.SaveChanges();
    }
}