/* 
Autores:
- Stiven Richardy Silva Rodrigues
- Guilherme Mendes de Sousa
*/

using System.ComponentModel;

namespace tp02.Models;

public class Tarefa : INotifyPropertyChanged
{
    private string titulo = string.Empty;
    private string descricao = string.Empty;
    private DateTime dataCriacao = DateTime.Today;
    private string prioridade = "Média";

    public string Titulo
    {
        get => titulo;
        set { titulo = value; Notificar(nameof(Titulo)); }
    }

    public string Descricao
    {
        get => descricao;
        set { descricao = value; Notificar(nameof(Descricao)); }
    }

    public DateTime DataCriacao
    {
        get => dataCriacao;
        set { dataCriacao = value; Notificar(nameof(DataCriacao)); }
    }

    public string Prioridade
    {
        get => prioridade;
        set
        {
            prioridade = value;
            Notificar(nameof(Prioridade));
            Notificar(nameof(CorPrioridade));
        }
    }

    public Color CorPrioridade => prioridade switch
    {
        "Alta" => Color.FromArgb("#D32F2F"),
        "Média" => Color.FromArgb("#F9A825"),
        _ => Color.FromArgb("#388E3C")
    };

    public event PropertyChangedEventHandler? PropertyChanged;

    private void Notificar(string propriedade)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propriedade));
    }
}