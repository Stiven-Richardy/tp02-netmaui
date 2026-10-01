/* 
Autores:
- Stiven Richardy Silva Rodrigues
- Guilherme Mendes de Sousa
*/

using System.Collections.ObjectModel;
using tp02.Models;

namespace tp02.Views;

public partial class DetalhesTarefaPage : ContentPage
{
    private readonly Tarefa tarefa;
    private readonly ObservableCollection<Tarefa> tarefas;

    public DetalhesTarefaPage(Tarefa tarefa, ObservableCollection<Tarefa> tarefas)
    {
        InitializeComponent();
        this.tarefa = tarefa;
        this.tarefas = tarefas;
        BindingContext = tarefa;
    }

    private async void OnEditarClicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new TarefaFormPage(tarefa));
    }

    private async void OnExcluirClicked(object sender, EventArgs e)
    {
        bool confirmar = await DisplayAlert(
            "Excluir tarefa",
            $"Deseja realmente excluir \"{tarefa.Titulo}\"?",
            "Sim",
            "Não");

        if (!confirmar)
            return;

        tarefas.Remove(tarefa);
        await Navigation.PopAsync();
    }
}