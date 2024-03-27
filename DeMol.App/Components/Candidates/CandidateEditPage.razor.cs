using DeMol.Domain;
using Microsoft.AspNetCore.Components;

namespace DeMol.App.Components.Candidates;

public partial class CandidateEditPage : ComponentBase{
    
    [Parameter]
    public int? Id { get; set; }

    private Candidate _candidate = new Candidate();

    protected override async Task OnInitializedAsync()
    {
        if (Id.HasValue)
        {
            _candidate = await CandidateService.GetCandidateByIdAsync(Id.Value) ?? new Candidate();
        }
        else
        {
            _candidate = new Candidate();
        }
    }

    private async Task HandleValidSubmit()
    {
        if (_candidate.Id == 0)
        {
            await CandidateService.AddCandidateAsync(_candidate);
        }
        else
        {
            await CandidateService.UpdateCandidateAsync(_candidate);
        }

        NavigationManager.NavigateTo("/candidates");
    }
}
