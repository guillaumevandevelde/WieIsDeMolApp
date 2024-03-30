using DeMol.Domain;
using Microsoft.AspNetCore.Components;

namespace DeMol.App.Components.Votes;

public partial class VotingComponent : ComponentBase
{
    [Parameter]
    public List<Candidate> Candidates { get;set; }
    [Parameter]
    public List<Candidate> Candidates2 { get;set; } 
    
    [Parameter]
    public string title { get;set; }


    private void SortList((int oldIndex, int newIndex) indices)
    {
        var (oldIndex, newIndex) = indices;

        var items = this.Candidates2;
        var itemToMove = items[oldIndex];
        items.RemoveAt(oldIndex);

        if (newIndex < items.Count)
        {
            items.Insert(newIndex, itemToMove);
        }
        else
        {
            items.Add(itemToMove);
        }

        StateHasChanged();
    }
    
    private void ListOneRemove((int oldIndex, int newIndex) indices)
    {
        // get the item at the old index in list 1
        var item = Candidates[indices.oldIndex];

        if (Candidates2.Count > 2)
        {
            Candidates.Add(Candidates2[2]);
            Candidates2.RemoveAt(2);
            
        }
        // add it to the new index in list 2
        Candidates2.Insert(indices.newIndex, item);
      

        // remove the item from the old index in list 1
        Candidates.Remove(Candidates[indices.oldIndex]);
    }

    private void ListTwoRemove((int oldIndex, int newIndex) indices)
    {
        // get the item at the old index in list 2
        var item = Candidates2[indices.oldIndex];

        // add it to the new index in list 1
        Candidates.Insert(indices.newIndex, item);

        // remove the item from the old index in list 2
        Candidates2.Remove(Candidates2[indices.oldIndex]);
    }
}