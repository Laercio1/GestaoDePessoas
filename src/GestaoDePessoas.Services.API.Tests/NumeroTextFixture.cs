using Moq.AutoMock;
using GestaoDePessoas.Application.Services.Numeros;

namespace GestaoDePessoas.Services.API.Tests
{
    [CollectionDefinition(nameof(NumeroTextFixtureCollection))]
    public class NumeroTextFixtureCollection : ICollectionFixture<NumeroTextFixture>
    { }

    public class NumeroTextFixture
    {
        public PessoaService numeroService;
        public AutoMocker Mocker;

        public PessoaService ObterNumeroService()
        {
            Mocker = new AutoMocker();

            numeroService = Mocker.CreateInstance<PessoaService>();
            return numeroService;
        }
    }
}
