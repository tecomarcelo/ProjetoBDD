# 🧪 Projeto BDD com SpecFlow + Selenium + FluentAssertions

Este projeto demonstra a implementação de **Behavior Driven Development (BDD)** em .NET utilizando:

- [SpecFlow](https://specflow.org/) → para escrita e execução de cenários em Gherkin  
- [Selenium WebDriver](https://www.selenium.dev/) → para automação de testes no navegador  
- [FluentAssertions](https://fluentassertions.com/) → para asserções mais legíveis e expressivas  
- [Bogus](https://github.com/bchavez/Bogus) → para geração de dados de teste (nome, email etc.)  

---

## 📌 Cenário de Teste Implementado

Funcionalidade: **Cadastro de Usuário**

Cenários contemplados:

1. ✅ Cadastro de usuário com dados válidos  
2. ⚠️ Cadastro com **email já existente**  
3. ❌ Tentativa de cadastro com **campos obrigatórios em branco**  

---

## 🚀 Tecnologias e Dependências

- .NET 6+  
- [SpecFlow](https://specflow.org/)  
- [Selenium WebDriver](https://www.selenium.dev/)  
- [ChromeDriver](https://chromedriver.chromium.org/)  
- [FluentAssertions](https://fluentassertions.com/)  
- [Bogus](https://github.com/bchavez/Bogus)  

---

## ⚙️ Configuração do Ambiente

### 1. Instalar dependências
No terminal, dentro do projeto:

```bash
dotnet restore
