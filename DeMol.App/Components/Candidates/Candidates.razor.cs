using DeMol.Domain;
using Microsoft.AspNetCore.Components;

namespace DeMol.App.Components.Candidates;

public partial class Candidates : ComponentBase
{
    private List<Candidate?> candidates;

    protected override async Task OnInitializedAsync()
    {
        candidates = await CandidateService.GetCandidatesAsync();
    }

    private void EditCandidate(int candidateId)
    {
        NavigationManager.NavigateTo($"/candidate/edit/{candidateId}");
    }
}