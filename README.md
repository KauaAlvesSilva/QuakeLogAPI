# QuakeLogAPI

Esta API em ASP.NET Core realiza o _parse_ de arquivos de log do jogo **Quake III Arena**, extraindo estatísticas e eventos detalhados de cada partida.

## 🚀 Funcionalidades

- 📄 Leitura e interpretação de arquivos de log (`games.log`)
- 🎯 Separação dos dados por jogo (game_1, game_2, etc.)
- 📊 Cálculo de:
  - 🔫 Total de mortes por jogo
  - 🧑‍🤝‍🧑 Lista de jogadores únicos
  - 📈 Quantidade de mortes por jogador

## 📂 Estrutura de Retorno da API

```json
{
  "games": {
    "game_1": {
      "total_kills": 45,
      "players": ["Isgalamido", "Dono da Bola", "Zeh"],
      "kills": {
        "Isgalamido": 18,
        "Dono da Bola": 5,
        "Zeh": 20
      }
    }
  }
}
```

## 📥 Requisitos

- ✅ .NET 5.0 ou superior
- 🛠️ Visual Studio ou VS Code
- 🧪 (Opcional) Postman ou Swagger para testes

## ⚙️ Como executar o projeto

1. Clone este repositório:

```bash
git clone https://github.com/KauaAlvesSilva/QuakeLogAPI.git
```

2. Navegue até o diretório do projeto:

3. Restaure os pacotes e compile:

```bash
dotnet restore
dotnet build
```

4. Execute a API:

```bash
dotnet run
```

5. Acesse no navegador ou via Postman:

```
GET http://localhost:5000/parser?filePath=caminho do arquivo
```

> 🔁 **Importante:** Passe o caminho do arquivo filePath.

## 🧪 Exemplo de uso

```http
GET /parser?filePath=C:\Logs\games.log
```

### Exemplo de resposta:

```json
{
  "games": {
    "game_1": {
      "total_kills": 3,
      "players": ["Isgalamido", "Dono da Bola"],
      "kills": {
        "Isgalamido": 2,
        "Dono da Bola": -1
      }
    }
  }
}
```

## 🧱 Estrutura de Código

- `Controllers/LogController.cs`: Define o endpoint `/parser`
- `Repositories/LogRepository.cs`: Responsável por interpretar os arquivos de log
- `Models/Report.cs`: Define a estrutura do resultado de cada jogo
- `Models/ParseLogResult.cs`: Classe que agrupa os relatórios em um único JSON

## 📌 Observações

- ❗ Certifique-se de que o caminho do arquivo está correto e acessível.
- 🕵️‍♂️ O arquivo `games.log` deve seguir o formato tradicional dos logs de Quake 3 Arena.
- 🔍 O regex atual suporta linhas como:

```
Kill: 3 2 10: Isgalamido killed Dono da Bola by MOD_RAILGUN
```
