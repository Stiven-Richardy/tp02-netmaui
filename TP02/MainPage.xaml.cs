/* 
Autores:
- Stiven Richardy Silva Rodrigues
- Guilherme Mendes de Sousa
*/

using System.Collections.ObjectModel;
using tp02.Models;
using tp02.Views;

namespace tp02;

public partial class MainPage : ContentPage
{
    private readonly ObservableCollection<Tarefa> tarefas = new()
    {
        new Tarefa
        {
            Titulo = "Entregar TP02",
            Descricao = "Finalizar o TarefasApp com navegação hierárquica e modal.",
            DataCriacao = DateTime.Today,
            Prioridade = "Alta"
        },
        new Tarefa
        {
            Titulo = "Revisar Aula 05",
            Descricao = "Estudar PushAsync, PopAsync, PushModalAsync e BindingContext.",
            DataCriacao = DateTime.Today.AddDays(-1),
            Prioridade = "Média"
        },
        new Tarefa
        {
            Titulo = "Organizar materiais",
            Descricao = "Separar os PDFs das aulas por disciplina.",
            DataCriacao = DateTime.Today.AddDays(-3),
            Prioridade = "Baixa"
        }
    };

    public MainPage()
    {
        InitializeComponent();
        ListaTarefas.ItemsSource = tarefas;
    }

    private async void OnTarefaSelecionada(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is not Tarefa tarefa)
            return;

        ListaTarefas.SelectedItem = null;
        await Navigation.PushAsync(new DetalhesTarefaPage(tarefa, tarefas));
    }

    private async void OnAdicionarClicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new TarefaFormPage(tarefas));
    }
}