﻿using System.Linq;
using System.Collections.Generic;
using ProfitDistribution.Api.Core.Modules.Distribution.Entities;
using ProfitDistribution.Api.Core.Modules.Distribution.Exceptions;

namespace ProfitDistribution.Api.App.Adapters.Modules.Distribution.CalculationInfluence
{
    public class AreaCalculator : CalculatorGateway
    {
        private Dictionary<string, int> Areas = new Dictionary<string, int> {
            { "Diretoria", 1 },
            { "Contabilidade", 2 },
            { "Financeiro", 2 },
            { "Tecnologia", 2 },
            { "Serviços Gerais", 3 },
            { "Relacionamento com o Cliente", 5 }
        };

        public int Calculate(Employee employee)
        {
            var area = Areas.FirstOrDefault(x => x.Key == employee.Area).Value;
            if (area == 0)
            {
                throw new CalculationInfluenceAreaNotFoundException(employee.Area);
            }
            return Areas.FirstOrDefault(x => x.Key == employee.Area).Value;
        }
    }
}
