1. [Criar_usar_tipos](https://github.com/shyoutarou/Exam-70-483_Criar_usar_tipos/wiki/Criar_usar_tipos)
     - [GitHub Page](https://shyoutarou.github.io/Exam-70-483_Criar_usar_tipos/)
2. [Gerenciar_fluxo](https://github.com/shyoutarou/Exam-70-483_Gerenciar_fluxo/wiki/Gerenciar_fluxo)
     - [GitHub Page](https://shyoutarou.github.io/Exam-70-483_Gerenciar_fluxo/)
3. [Acesso_dados](https://github.com/shyoutarou/Exam-70-483_Acesso_dados/wiki/Acesso_dados)
     - [GitHub Page](https://shyoutarou.github.io/Exam-70-483_Acesso_dados/)
4. [Depurar_segurança](https://github.com/shyoutarou/Exam-70-483_Depurar_seguranca/wiki/Depurar_seguranca)
     - [GitHub Page](https://shyoutarou.github.io/Exam-70-483_Depurar_seguranca/)
5. [Csharp8_Csharp9](https://github.com/shyoutarou/Exam-70-483_Csharp8_Csharp9/wiki/Csharp8_Csharp9)
     - [GitHub Page](https://shyoutarou.github.io/Exam-70-483_Csharp8_Csharp9/)
6. [Questions](https://github.com/shyoutarou/Exam-70-483_Questions/wiki/Questions)

## [Csharp 08](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8)

- [Csharp 08](#csharp-08)
  - [HABILITANDO O C# 8](#habilitando-o-c-8)
  - [Padrões do compilador](#padrões-do-compilador)
  - [Substituir um padrão](#substituir-um-padrão)
  - [Editar o arquivo de projeto](#editar-o-arquivo-de-projeto)
  - [Configurar vários projetos](#configurar-vários-projetos)
- [Csharp 9.0](#csharp-90)
  - [CONFIGURANDO O C# 9](#configurando-o-c-9)
  - [Solução de problemas](#solução-de-problemas)

### HABILITANDO O C# 8

A primeira etapa é garantir que estejamos usando o Visual Studio 2019 versão 16.3 ou superior. Verifique no menu Ajuda > Informações sobre o Visual Studio.
 
<p align="center">
  <img src="https://raw.githubusercontent.com/shyoutarou/Exam-70-483_Csharp8_Csharp9/master/.github/vs163.png" alt="Image" width="100%" />
</p>

Em seguida, precisamos configurar o projeto para o C# 8. Se estivermos acostumados a trabalhar com o Visual Studio, talvez espere alterar de maneira simples a configuração de um projeto. Antes era só ir para Compilar da janela de propriedades do projeto e selecionar a versão do idioma C# :
 
<p align="center">
  <img src="https://raw.githubusercontent.com/shyoutarou/Exam-70-483_Csharp8_Csharp9/master/.github/configurarvs.png" alt="Image" width="100%" />
</p>


Infelizmente, isso não funciona mais. Sob as novas regras, a versão padrão do C# é determinada por qual framework estamos direcionando. Os compiladores do C# que fazem parte da instalação do Visual Studio 2017 ou de versões anteriores do SDK do .NET Core são direcionados ao C# 7.0 por padrão. O C# 8,0 tem suporte apenas no .NET Core 3. x e em versões mais recentes. Muitos dos recursos mais recentes exigem recursos de biblioteca e tempo de execução introduzidos no .NET Core 3. x: 
- A implementação de interface padrão requer novos recursos no .net Core 3,0 CLR.
- Os fluxos assíncronos exigem os novos tipos:
    - System.IAsyncDisposable, 
    - System.Collections.Generic.IAsyncEnumerable<T> 
    - System.Collections.Generic.IAsyncEnumerator<T> .
- Índices e intervalos exigem os novos tipos System.Index e System.Range .
- Os tipos de referência anuláveis fazem uso de vários atributos para fornecer avisos melhores. Esses atributos foram adicionados no .NET Core 3,0. Outras estruturas de destino não foram anotadas com nenhum desses atributos. Isso significa que os avisos anuláveis podem não refletir com precisão possíveis problemas.

O C# 9,0 tem suporte apenas no .NET 5 e em versões mais recentes.

### Padrões do compilador

O compilador determina um padrão com base nestas regras:

|     Estrutura de destino    |     version    |     Padrão da versão da linguagem C#    |
|-----------------------------|----------------|-----------------------------------------|
|     .NET                    |     5          |     C# 9,0                              |
|     .NET Core               |     3.x        |     C# 8.0                              |
|     .NET Core               |     2. x       |     C# 7.3                              |
|     .NET Standard           |     2.1        |     C# 8.0                              |
|     .NET Standard           |     2.0        |     C# 7.3                              |
|     .NET Standard           |     1.x        |     C# 7.3                              |
|     .NET Framework          |     all        |     C# 7.3                              |

Abra o prompt de comando do desenvolvedor para o Visual Studioe execute o comando a seguir para ver a lista de versões de idioma disponíveis em seu computador.

```bash
csc -langversion:?
```


Questionando a opção de compilação -langversion como essa, imprimirá algo semelhante ao seguinte:

<p align="center">
  <img src="https://raw.githubusercontent.com/shyoutarou/Exam-70-483_Csharp8_Csharp9/master/.github/langversion.png" alt="Image" width="100%" />
</p>
 

A tabela a seguir mostra todas as versões atuais da linguagem C#. Seu compilador pode não entender necessariamente todos os valores se for mais antigo. Se você instalar o .NET Core 3,0 ou posterior, terá acesso a todos os itens listados.

|     Valor                    |     Significado         |
|------------------------------|-------------------------|
|     preview                  |     O compilador aceita todas as sintaxes de linguagem válidas da versão   prévia mais recente.     |
|     latest                   |     O compilador aceita a sintaxe da versão lançada mais recente do   compilador (incluindo a versão secundária).    |
|     latestMajor (default)    |     O compilador aceita a sintaxe da versão principal mais recente   lançada do compilador.     |
|     8.0     |     O compilador aceita somente a sintaxe incluída no C# 8.0 ou inferior.     |
|     7.3     |     O compilador aceita somente a sintaxe incluída no C# 7.3 ou inferior.       |
|     7.2    |     O compilador aceita somente a sintaxe incluída no C# 7.2 ou inferior.          |
|     7.1  |     O compilador aceita somente a sintaxe incluída no C# 7.1 ou inferior.       |
|     7    |     O compilador aceita somente a sintaxe incluída no C# 7.0 ou inferior.    |
|     6      |     O compilador aceita somente a sintaxe incluída no C# 6.0 ou inferior.       |
|     5      |     O compilador aceita somente a sintaxe incluída no C# 5.0 ou inferior.         |
|     4      |     O compilador aceita somente a sintaxe incluída no C# 4.0 ou inferior.        |
|     3      |     O compilador aceita somente a sintaxe incluída no C# 3.0 ou inferior.       |
|     ISO-2(ou 2)   |     O compilador aceita apenas a sintaxe que está incluída em ISO/IEC   23270:2006 C# (2,0).                         |

Para saber qual versão de idioma você está usando no momento, coloque #error em seu código. Isso faz com que o compilador produza um diagnóstico, CS8304, com uma mensagem que contém a versão do compilador que está sendo usada e a versão atual do idioma selecionado.

<p align="center">
  <img src="https://raw.githubusercontent.com/shyoutarou/Exam-70-483_Csharp8_Csharp9/master/.github/idiomaselecionado.png" alt="Image" width="100%" />
</p>
 
 

Somente o .NET Core 3.0 e o .NET Standard 2.1 possuem o C# 8, o restante começa com o C# 7.3. Crie um projeto console Core 3.0:

<p align="center">
  <img src="https://raw.githubusercontent.com/shyoutarou/Exam-70-483_Csharp8_Csharp9/master/.github/consolecore.png" alt="Image" width="100%" />
</p>
 
### Substituir um padrão

Se precisar especificar sua versão do C# explicitamente, poderá fazer isso de várias maneiras:
1.	Edite manualmente o arquivo de projeto (csproj).
2.	Definir a versão da linguagem para vários projetos em um subdiretório.
3.	Configure a -langversion opção do compilador.

### Editar o arquivo de projeto

É possível definir a versão da linguagem em seu arquivo de projeto. Por exemplo, se você quiser explicitamente acesso às versões prévias dos recursos, adicione um elemento como este:

```xml
<PropertyGroup>
<LangVersion>preview</LangVersion>    OU    <LangVersion>8.0</LangVersion>
</PropertyGroup>
```

O valor preview usa a versão prévia mais recente da linguagem C# compatível com seu compilador. Se estivermos usando um formato de projeto moderno, podemos abri-lo clicando duas vezes no projeto no Solution Explorer. Podemos reconhecer esse formato porque a raiz do arquivo XML é parecida com esta:

```xml
<Project Sdk="Microsoft.NET.Sdk">
```


Se estivermos usando o formato do projeto legado, podemos editá-lo diretamente, mas será um pouco mais complicado. Uma opção é fechar o Visual Studio e usar o bloco de notas ou algum editor de texto. Como alternativa, podemos instalar o Power Commands do Visual Studio, que adiciona um comando "Edit Project File". Para referência, a raiz do arquivo XML será mais ou menos assim:

```xml
<Project ToolsVersion="14.0" DefaultTargets="Build" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
```

### Configurar vários projetos

Para configurar vários projetos, você pode criar um arquivo Directory. Build. props que contém o ```<LangVersion>``` elemento. Normalmente, você faz isso no diretório da solução. Adicione o seguinte a um arquivo Directory. Build. props no diretório da solução:


```xml
<Project>
    <PropertyGroup>
        <LangVersion>preview</LangVersion>
    </PropertyGroup>
</Project>
```

As compilações em todos os subdiretórios do diretório que contém esse arquivo usarão a versão preview C#. Para obter mais informações, confira o artigo sobre como personalizar o build.  C# 8.0 adiciona os seguintes recursos e aprimoramentos à linguagem  C#:






## [Csharp 9.0](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-9)

- [CONFIGURANDO O C# 9](#configurando-o-c-9)
- [Solução de problemas](#solução-de-problemas)

### CONFIGURANDO O C# 9

Configurar com C# 9 é basicamente o mesmo que configurar com .NET Preview 5. 
- Certifique-se de que sua versão do Visual Studio 2019 seja pelo menos 16.7 clicando em Help => Check For Updates dentro do Visual Studio. Em caso de dúvida, atualize.

<p align="center">
  <img src="https://raw.githubusercontent.com/shyoutarou/Exam-70-483_Csharp8_Csharp9/master/.github/vs167.png" alt="Image" width="100%" />
</p>



- Vá em Ferramentas => Opções dentro de Ambiente, selecione “Versão Prévia de recursos” e marque a caixa que diz “Usar versão prévia do SDK do .NET Core”. Em seguida, reinicie o Visual Studio.

<p align="center">
  <img src="https://raw.githubusercontent.com/shyoutarou/Exam-70-483_Csharp8_Csharp9/master/.github/versaoprevia.png" alt="Image" width="100%" />
</p>

 

- Baixe e instale um SDK do [.NET 5](https://dotnet.microsoft.com/download/dotnet/5.0) compatível com a versão de VS 2019 instalada:

<p align="center">
  <img src="https://raw.githubusercontent.com/shyoutarou/Exam-70-483_Csharp8_Csharp9/master/.github/versaoinstalada.png" alt="Image" width="100%" />
</p>



<p align="center">
  <img src="https://raw.githubusercontent.com/shyoutarou/Exam-70-483_Csharp8_Csharp9/master/.github/sdknet5.png" alt="Image" width="100%" />
</p>


- Após a instalação, você pode executar o comando dotnet info em um prompt de comando:
dotnet –info

<p align="center">
  <img src="https://raw.githubusercontent.com/shyoutarou/Exam-70-483_Csharp8_Csharp9/master/.github/dotnetinfo.png" alt="Image" width="100%" />
</p>


Depois que o SDK do .NET 5 Preview estiver instalado e configurado. Para qualquer projeto existente que você deseja testar em execução no .NET 5 (por exemplo, um pequeno aplicativo de console), tudo o que você precisa fazer é brir o arquivo .csproj. Para abrir o arquivo de projeto * .csproj: Clique com o botão direito do mouse no Gerenciador de Soluções e escolha Editar Arquivo de Projeto.:

<p align="center">
  <img src="https://raw.githubusercontent.com/shyoutarou/Exam-70-483_Csharp8_Csharp9/master/.github/editararquivo.png" alt="Image" width="100%" />
</p>


```xml
<Project Sdk = "Microsoft.NET.Sdk" > 
<PropertyGroup>
  		 <OutputType> Exe </OutputType>
  		 <TargetFramework> netcoreapp3.1 </TargetFramework>
</PropertyGroup>
</Project>
```

Para :

```xml
<Project Sdk = "Microsoft.NET.Sdk" > 
<PropertyGroup>
 <OutputType> Exe </OutputType> 
<TargetFramework> net5.0 </TargetFramework> 
<LangVersion> 9.0 </LangVersion> 
</PropertyGroup> 
</Project>
```

Observe que alguns modelos, como aplicativos de console, não solicitam a versão do SDK ao criar um novo projeto, eles apenas usam o SDK mais recente disponível. Nesse caso, seu “padrão” para Visual Studio repentinamente se torna uma prévia do SDK do .NET Core. 

### Solução de problemas

Se você fez tudo isso e obteve um destes erros:
- Os assemblies de referência para .NET Framework, Version = v5.0 não foram encontrados. 
- Opção inválida '9.0' para / langversion. Use '/ langversion :?' para listar os valores suportados.

Então aqui está sua lista de solução de problemas rápida e fácil:
- Tem certeza de que tem o SDK do .NET 5 mais recente instalado? Lembre-se de que é o SDK, não o runtime, e é .NET 5.
- Tem certeza de que o Visual Studio está atualizado? Mesmo se você tiver o SDK instalado, o Visual Studio segue suas próprias regras e precisa ser atualizado.
- Você está usando o Visual Studio 2019? Qualquer versão anterior não funcionará.
- Tem certeza de que ativou os SDKs de visualização? Lembre-se de Ferramentas => Opções e, em seguida, “Visualizar Recurso”
- Para rodar par Visual Studio 2019 version 16.8 e superior, requer o .NET 5 SDK preview 8. NoVisual Studio 2019 version 16.7 e superior, requer o .NET 5 SDK preview 7. O próprio SDK define um VS mínimo que ele suporta e não carregará nas versões do VS antes desse valor para evitar comportamento interrompido. Cada pré-lançamento contínuo do .NET e do SDK será enviado junto com um pré-lançamento do 16.8 VS com o qual são testados. Por exemplo, .NET 5 preview 8 fornecido com o Visual Studio preview 2. RC1 enviado com preview 3. Recomendamos que você use essas combinações juntas para teste, pois eles têm alguns componentes compartilhados e dependências que farão os cenários funcionarem melhor E2E.

|     Releases              |     Visual   Studio 2019 Preview                   |
|---------------------------|----------------------------------------------------|
|     September 14, 2020    |     version 16.8 Preview 3.1New release icon       |
|     August 31, 2020       |     Visual Studio 2019 version 16.8 Preview 2.1    |
|     August 25, 2020       |     Visual Studio 2019 version 16.8 Preview 2      |
|     August 5, 2020        |     Visual Studio 2019 version 16.8 Preview 1      |

Uma nova versão de amostra do .NET 5/C# 9 é lançada a cada poucos meses. Portanto, se você estiver lendo sobre um novo recurso C# 9 ou .NET 5 que alguém está usando, mas parece que não consegue fazê-lo funcionar, volte sempre para https://dotnet.microsoft.com/download/dotnet/5.0 e baixe a última versão de visualização e instale. Semelhante ao Visual Studio, embora normalmente não seja um problema, tente mantê-lo atualizado, já que muitas vezes os recursos mais recentes que não funcionam são simplesmente porque estou em uma versão que estava perfeitamente bem um mês atrás, mas agora está desatualizada.