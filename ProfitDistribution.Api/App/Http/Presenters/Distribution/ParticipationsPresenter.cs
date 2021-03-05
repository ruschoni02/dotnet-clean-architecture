using System.Collections.Generic;
using ProfitDistribution.Api.App.Adapters;
using ProfitDistribution.Api.Core.Modules.Distribution.Entities;

namespace ProfitDistribution.Api.App.Http.Presenters.Distribution
{
    public class ParticipationsPresenter
    {
        private List<Participation> _participations;

        public ParticipationsPresenter(List<Participation> participations)
        {
            _participations = participations;
        }

        public List<object> present()
        {
            var presenter = new List<object>();

            foreach (var participation in _participations)
            {
                presenter.Add(new
                {
                    matricula = participation.Employee.Registration,
                    nome = participation.Employee.Name,
                    valor_da_participação = formatToReal(participation.Value),
                });
            }

            return presenter;
        }

        private string formatToReal(int money)
        {
            return MoneyAdapter.FormatToReal(money);
        }
    }
}
