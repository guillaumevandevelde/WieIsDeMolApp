using DeMol.App.Services;
using DeMol.Domain;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace DeMol.App.Components.Votes;

public partial class VotePage : ComponentBase
{
    private List<Candidate?> candidates = new List<Candidate?>();
    [Inject]
    private CandidateService CandidateService { get; set; }
   

    protected override async Task OnInitializedAsync()
    {
        candidates = await CandidateService.GetCandidatesAsync();
        await JSRuntime.InvokeVoidAsync("enableDragAndDrop");
    }
    
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await JSRuntime.InvokeVoidAsync("enableDragAndDrop");
        }
    }

}