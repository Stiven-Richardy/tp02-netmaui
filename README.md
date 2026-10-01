# 📱 Projeto: Lista de Tarefas com Navegação Hierárquica e Modal em .NET MAUI (C# & XAML)

Este projeto acadêmico foi desenvolvido no âmbito da unidade curricular de **Programação de Dispositivos Móveis (CBTPRDM)**, lecionada pelo professor Me. Wellington Tuler Moraes, no Instituto Federal de Educação, Ciência e Tecnologia de São Paulo (IFSP) — Campus Cubatão. O objetivo central é implementar o segundo trabalho prático (TP02): um aplicativo de lista de tarefas (**tp02**) que combina navegação hierárquica, navegação modal e passagem de dados entre páginas utilizando o framework multiplataforma .NET MAUI.

A aplicação materializa os conceitos de *Navegação Hierárquica* (`NavigationPage` com pilha LIFO via `PushAsync`/`PopAsync`), *Navegação Modal* (`PushModalAsync`/`PopModalAsync`), *Pop-ups* nativos (`DisplayAlert`) e *Passagem de Dados* por argumento de construtor e por `BindingContext`, mantendo a interface sincronizada com o modelo por meio de data binding.

## 🎯 Objetivos

- **Listagem de Tarefas (XAML):** Exibição das tarefas em uma `CollectionView` com `DataTemplate` próprio, apresentando título, descrição resumida (truncada em duas linhas) e um indicador visual de prioridade por cor.
- **Navegação Hierárquica:** Página raiz definida com `NavigationPage`; ao tocar em uma tarefa, a página de detalhes é empilhada via `PushAsync`, exibindo data de criação e prioridade, com retorno pela barra de navegação ou pelo botão Voltar do dispositivo.
- **Navegação Modal (Adicionar e Editar):** Um único formulário (`TarefaFormPage`) aberto via `PushModalAsync`, com dois construtores — um para criação de nova tarefa e outro para edição de tarefa existente — evitando duplicação de interface e lógica.
- **Exclusão com Confirmação:** Uso do `DisplayAlert` com botões de aceitar/cancelar (retorno `bool`) para confirmar a exclusão antes de remover a tarefa e retornar à lista via `PopAsync`.
- **Passagem de Dados entre Páginas:** Envio da tarefa selecionada e da coleção por argumento de construtor e preenchimento da página de detalhes através de `BindingContext`.
- **Sincronização de Estado:** Uso de `ObservableCollection<Tarefa>` para refletir inclusões e exclusões na lista, e de `INotifyPropertyChanged` no modelo para atualizar automaticamente a lista e a página de detalhes após uma edição.
- **Integridade dos Dados (UX):** O formulário trabalha sobre cópias dos valores da tarefa, gravando no objeto apenas ao tocar em "Salvar"; "Cancelar" (ou o botão Voltar do Android) descarta as alterações. O título é validado como campo obrigatório.

## ✅ Requisitos do TP02 Atendidos

| Requisito | Implementação |
|---|---|
| Projeto chamado "tp02" | Solução e namespace `tp02` |
| Página inicial com lista de tarefas (título e breve descrição) | `MainPage` com `CollectionView` e `DataTemplate` |
| Navegação hierárquica para os detalhes | `NavigationPage` + `Navigation.PushAsync(new DetalhesTarefaPage(...))` |
| Detalhes com data de criação e prioridade | `DetalhesTarefaPage` com `{Binding DataCriacao}` e `{Binding Prioridade}` |
| Botão "Editar" abrindo modal de edição | `Navigation.PushModalAsync(new TarefaFormPage(tarefa))` |
| Botão "Excluir" com diálogo de confirmação | `DisplayAlert("...", "...", "Sim", "Não")` |
| Botão "Adicionar" abrindo modal de criação | `Navigation.PushModalAsync(new TarefaFormPage(tarefas))` |
| Passagem de dados entre páginas | Argumento de construtor + `BindingContext` |
| Layout agradável e navegação intuitiva | Cards com `Border`, indicador de prioridade por cor, `EmptyView` e controles nativos (`Entry`, `Editor`, `DatePicker`, `Picker`) |

## 🧭 Fluxo de Navegação

```text
NavigationPage (raiz)
└── MainPage ──────────────── [Adicionar] ──► TarefaFormPage (modal · nova tarefa)
     │
     └── [toque na tarefa] ──► DetalhesTarefaPage (push)
                                 ├── [Editar] ──► TarefaFormPage (modal · edição)
                                 └── [Excluir] ──► DisplayAlert ──► PopAsync
```

## 🛠️ Ferramentas Utilizadas

- C# 13 / .NET 9.0
- XAML (eXtensible Application Markup Language)
- .NET MAUI (Multi-platform App UI)
- Visual Studio 2022 (v17.12 ou superior, Workload: .NET Multi-platform App UI development)
- Android Emulator (Hyper-V / HAXM)
- Git & GitHub

## 🗂️ Estrutura do Projeto

```text
📁 TP02/
├── 📁 Models/
│   └── 📄 Tarefa.cs
├── 📁 Views/
│   ├── 📄 DetalhesTarefaPage.xaml
│   ├── 📄 DetalhesTarefaPage.xaml.cs
│   ├── 📄 TarefaFormPage.xaml
│   └── 📄 TarefaFormPage.xaml.cs
├── 📁 Platforms/
├── 📁 Resources/
├── 📄 App.xaml
├── 📄 App.xaml.cs
├── 📄 MainPage.xaml
├── 📄 MainPage.xaml.cs
├── 📄 MauiProgram.cs
└── 📄 tp02.csproj
```

> **Observação:** os arquivos `AppShell.xaml` e `AppShell.xaml.cs`, gerados pelo modelo padrão, foram removidos, pois a `NavigationPage` é incompatível com aplicativos baseados em .NET MAUI Shell.

## 🚀 Como Executar

1. **Configuração do Ambiente (Visual Studio):**
   - Clone este repositório para a sua máquina local.
   - Certifique-se de que o **Visual Studio 2022** (v17.12 ou superior) está instalado com o workload **Desenvolvimento de interface do usuário de aplicativo multiplataforma do .NET (.NET MAUI)** e o SDK do **.NET 9**.
   - Abra a solução do projeto (`tp02.sln`) na sua IDE.

2. **Iniciando a Aplicação (Android Emulator):**
   - Na barra de ferramentas superior do Visual Studio, localize o menu *dropdown* de *Target* (Destino de Depuração).
   - Selecione **Android Emulators** e escolha o dispositivo configurado (ex: `pixel_7 - api_35`). Caso não tenha um emulador configurado, utilize o *Gerenciador de Dispositivos Android* no menu *Ferramentas* para criar um.
   - Pressione `F5` ou clique em **Iniciar Depuração**. O Visual Studio compilará o projeto e fará o *deploy* da aplicação no emulador.

3. **Roteiro de Teste Sugerido:**
   - Toque em uma tarefa para abrir os detalhes e volte pela barra de navegação.
   - Edite uma tarefa, altere a prioridade e salve: a cor e os dados devem ser atualizados na lista e nos detalhes.
   - Edite uma tarefa e toque em "Cancelar": nenhuma alteração deve ser aplicada.
   - Exclua uma tarefa, confirmando no diálogo: o app retorna à lista sem o item.
   - Adicione uma tarefa sem título (deve exibir alerta) e depois com todos os campos preenchidos.

## ⚠️ Limitações Conhecidas

- **Sem persistência:** as tarefas são mantidas apenas em memória durante a execução; ao fechar o aplicativo, a lista retorna às tarefas de exemplo. A persistência local não faz parte do escopo do TP02.
- **Data de criação editável:** mantida editável por exigência explícita do enunciado, embora semanticamente uma data de criação devesse ser definida pelo sistema.

## 👨‍🏫 Autores

- **Stiven Richardy Silva Rodrigues** Estudante de Análise e Desenvolvimento de Sistemas | IFSP — Campus Cubatão  
  [@Stiven-Richardy](https://github.com/Stiven-Richardy)

- **Guilherme Mendes de Sousa** Estudante de Análise e Desenvolvimento de Sistemas | IFSP — Campus Cubatão  
  [@Guilh3rme-M3ndes](https://github.com/Guilh3rme-M3ndes)

## 📚 Referências

- Documentação Oficial do .NET MAUI: https://learn.microsoft.com/pt-br/dotnet/maui/
- ListView — .NET MAUI (base de consulta do TP02): https://learn.microsoft.com/pt-br/dotnet/maui/user-interface/controls/listview
- CollectionView — .NET MAUI: https://learn.microsoft.com/pt-br/dotnet/maui/user-interface/controls/collectionview/
- NavigationPage — .NET MAUI: https://learn.microsoft.com/pt-br/dotnet/maui/user-interface/pages/navigationpage
- Navegação Modal — .NET MAUI: https://learn.microsoft.com/pt-br/dotnet/maui/user-interface/pages/modal
- CBTPRDM (Programação de Dispositivos Móveis) - Material Didático (Aulas 01 a 05)
