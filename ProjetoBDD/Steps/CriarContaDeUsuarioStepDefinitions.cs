using Bogus;
using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ProjetoBDD.Helpers;
using TechTalk.SpecFlow;

namespace ProjetoBDD.Steps
{
    [Binding]
    public class CriarContaDeUsuarioStepDefinitions
    {
        private IWebDriver? _driver;

        private static string nomeUsuario;
        private static string emailUsuario;

        [Given(@"eu acesso a página de criação de conta de usuário")]
        public void GivenEuAcessoAPaginaDeCriacaoDeContaDeUsuario()
        {
            _driver = new ChromeDriver(); //abrindo o google chrome
            _driver?.Manage().Window.Maximize(); //maximizando a janela do navegador

            //acessando a página do sistema
            _driver?.Navigate().GoToUrl("http://localhost:5252/Account/Register");
        }

        [Given(@"eu informo nome, email e senha válidos")]
        public void GivenEuInformoNomeEmailESenhaValidos()
        {
            //capturando a referencia de cada campo através do XPATH
            var nome = _driver?.FindElement(By.XPath("//*[@id=\"Nome\"]"));
            var email = _driver?.FindElement(By.XPath("//*[@id=\"Email\"]"));
            var senha = _driver?.FindElement(By.XPath("//*[@id=\"Senha\"]"));
            var senhaConfirmacao = _driver?.FindElement(By.XPath("//*[@id=\"SenhaConfirmacao\"]"));

            //preenchendo os campos
            var faker = new Faker();

            nomeUsuario = faker.Person.FullName;
            emailUsuario = faker.Internet.Email();

            nome?.SendKeys(nomeUsuario);
            email?.SendKeys(emailUsuario);
            senha?.SendKeys("@Admin123");
            senhaConfirmacao?.SendKeys("@Admin123");
        }

        [When(@"eu solicito a realização do cadastro")]
        public void WhenEuSolicitoARealizacaoDoCadastro()
        {
            //capturando a referencia do botão
            var botao = _driver?.FindElement(By.XPath("/html/body/div/div/div/div/div/form/div[1]/input"));
            //clicando no botão
            botao?.Click();
        }

        [Then(@"o sistema informa que o usuário foi cadastrado com sucesso")]
        public void ThenOSistemaInformaQueOUsuarioFoiCadastradoComSucesso()
        {
            //capturando a referencia da mensagem
            var mensagem = _driver?.FindElement(By.XPath("/html/body/div/div/div/div/div/div[2]"));
            //verificando o texto da mensagem
            mensagem?.Text.Should().Be("Sucesso! Usuário cadastrado com sucesso!");

            var screenshotHelper = new ScreenshotHelper(_driver);
            screenshotHelper.TakeScreenshot("Criar Conta de usuário - cadastro realizado com sucesso");

            //fechar o navegador
            _driver?.Close();
        }

        [Given(@"eu informo nome, senha e um email já cadastrado")]
        public void GivenEuInformoNomeSenhaEUmEmailJaCadastrado()
        {
            //capturando a referencia de cada campo através do XPATH
            var nome = _driver?.FindElement(By.XPath("//*[@id=\"Nome\"]"));
            var email = _driver?.FindElement(By.XPath("//*[@id=\"Email\"]"));
            var senha = _driver?.FindElement(By.XPath("//*[@id=\"Senha\"]"));
            var senhaConfirmacao = _driver?.FindElement(By.XPath("//*[@id=\"SenhaConfirmacao\"]"));

            nome?.SendKeys(nomeUsuario); //usuário já cadastro no passo anterior.
            email?.SendKeys(emailUsuario); //email já cadastro no passo anterior.
            senha?.SendKeys("@Admin123");
            senhaConfirmacao?.SendKeys("@Admin123");
        }

        [Then(@"o sistema informa que o email já foi cadastrado para outro usuário")]
        public void ThenOSistemaInformaQueOEmailJaFoiCadastradoParaOutroUsuario()
        {
            //capturando a referencia da mensagem
            var mensagem = _driver?.FindElement(By.XPath("/html/body/div/div/div/div/div/div[2]"));
            //verificando o texto da mensagem
            mensagem?.Text.Should().Be("Erro! O email informado já está cadastrado. Tente outro.");

            var screenshotHelper = new ScreenshotHelper(_driver);
            screenshotHelper.TakeScreenshot("Criar Conta de usuário - email já cadastrado");

            //fechar o navegador
            _driver?.Close();
        }

        [Given(@"eu não preencho nome, email e senha")]
        public void GivenEuNaoPreenchoNomeEmailESenha()
        {
            //capturando a referencia de cada campo através do XPATH
            var nome = _driver?.FindElement(By.XPath("//*[@id=\"Nome\"]"));
            var email = _driver?.FindElement(By.XPath("//*[@id=\"Email\"]"));
            var senha = _driver?.FindElement(By.XPath("//*[@id=\"Senha\"]"));
            var senhaConfirmacao = _driver?.FindElement(By.XPath("//*[@id=\"SenhaConfirmacao\"]"));

            nome?.Clear();
            email?.Clear();
            senha?.Clear();
            senhaConfirmacao?.Clear();
        }

        [Then(@"o sistema informa que todos os campos são de preenchimento obrigatório")]
        public void ThenOSistemaInformaQueTodosOsCamposSaoDePreenchimentoObrigatorio()
        {
            //capturando cada mensagem de erro
            var nomeObrigatorio = _driver?.FindElement(By.XPath("/html/body/div/div/div/div/div/form/span[1]/span"));
            var emailObrigatorio = _driver?.FindElement(By.XPath("/html/body/div/div/div/div/div/form/span[2]/span"));
            var senhaObrigatorio = _driver?.FindElement(By.XPath("/html/body/div/div/div/div/div/form/span[3]/span"));
            var senhaConfirmacaoObrigatorio = _driver?.FindElement(By.XPath("/html/body/div/div/div/div/div/form/span[4]/span"));

            //verificando as mensagens
            nomeObrigatorio?.Text.Should().Be("Por favor, informe o nome.");
            emailObrigatorio?.Text.Should().Be("Por favor, informe o email.");
            senhaObrigatorio?.Text.Should().Be("Por favor, informe a senha.");
            senhaConfirmacaoObrigatorio?.Text.Should().Be("Por favor, confirme a senha.");

            var screenshotHelper = new ScreenshotHelper(_driver);
            screenshotHelper.TakeScreenshot("Criar Conta de usuário - validação de campos obrigatórios");

            //fechar o navegador
            _driver?.Close();
        }
    }
}
