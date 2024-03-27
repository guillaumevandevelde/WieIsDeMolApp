using DeMol.App.Services;
using DeMol.Domain;
using Microsoft.AspNetCore.Components;

namespace DeMol.App.Components.Candidates;

public partial class CandidatesPage : ComponentBase
{
    private List<Candidate?> candidates;
    
    [Inject]
    private CandidateService CandidateService { get; set; } = default!;
    [Inject]
    private NavigationManager NavigationManager { get; set; } = default!;

    protected override async Task OnInitializedAsync()
    {
        candidates = await CandidateService.GetCandidatesAsync() ?? [];
    }

    private void EditCandidate(int candidateId)
    {
        NavigationManager.NavigateTo($"/candidate/edit/{candidateId}");
    }

    private void CreateCandidate()
    {
        NavigationManager.NavigateTo("/candidate/edit");
    }
}