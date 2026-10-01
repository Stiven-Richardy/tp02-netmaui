/* 
Autores:
- Stiven Richardy Silva Rodrigues
- Guilherme Mendes de Sousa
*/

using System.Collections.ObjectModel;
using tp02.Models;

namespace tp02.Views;

public partial class TarefaFormPage : ContentPage
{
    private readonly ObservableCollection<Tarefa>? tarefas;
    private readonly Tarefa? tarefaEmEdicao;

    public TarefaFormPage(ObservableCollection<Tarefa> tarefas)
    {
        InitializeComponent();
        this.tarefas = tarefas;
        TituloPagina.Text = "Nova Tarefa";
        PickerData.Date = DateTime.Today;
        PickerPrioridade.SelectedItem = "Média";
    }

    public TarefaFormPage(Tarefa tarefa)
    {
        InitializeComponent();
        tarefaEmEdicao = tarefa;
        TituloPagina.Text = "Editar Tarefa";
        EntryTitulo.Text = tarefa.Titulo;
        EditorDescricao.Text = tarefa.Descricao;
        PickerData.Date = tarefa.DataCriacao;
        PickerPrioridade.SelectedItem = tarefa.Prioridade;
    }

    private async void OnSalvarClicked(object sender, EventArgs e)
    {
        string titulo = EntryTitulo.Text?.Trim() ?? string.Empty;

        if (string.IsNullOrWhiteSpace(titulo))
        {
            await DisplayAlert("Campo obrigatório", "Informe o título da tarefa.", "OK");
            return;
        }

        string descricao = EditorDescricao.Text?.Trim() ?? string.Empty;
        string prioridade = PickerPrioridade.SelectedItem as string ?? "Média";

        if (tarefaEmEdicao is null)
        {
            tarefas?.Add(new Tarefa
            {
                Titulo = titulo,
                Descricao = descricao,
                DataCriacao = PickerData.Date,
                Prioridade = prioridade
            });
        }
        else
        {
            tarefaEmEdicao.Titulo = titulo;
            tarefaEmEdicao.Descricao = descricao;
            tarefaEmEdicao.DataCriacao = PickerData.Date;
            tarefaEmEdicao.Prioridade = prioridade;
        }

        await Navigation.PopModalAsync();
    }

    private async void OnCancelarClicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }
}