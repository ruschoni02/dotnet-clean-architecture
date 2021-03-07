using ProfitDistribution.Api.App.Adapters;

namespace ProfitDistribution.Api.App.Http.Presenters.Distribution
{
    public class DistributionPresenter
    {
        private Core.Modules.Distribution.Response _response;
        private ParticipationsPresenter _participationsPresenter;

        public DistributionPresenter(Core.Modules.Distribution.Response response)
        {
            _response = response;
            _participationsPresenter = new ParticipationsPresenter(_response.Distribution.Participations);
        }

        public object Present()
        {
            return new
            {
                participacoes = _participationsPresenter.Present(),
                total_de_funcionarios = _response.Distribution.Participations.Count,
                total_distribuido = FormatToReal(_response.Distribution.TotalDistributed),
                total_disponibilizado = FormatToReal(_response.Distribution.TotalAvailable),
                saldo_total_disponibilizado = FormatToReal(_response.Distribution.TotalAvailable - _response.Distribution.TotalDistributed),
            };
        }

        private string FormatToReal(long money)
        {
            return MoneyAdapter.FormatToReal(money);
        }
    }
}
