using DeMol.Domain;
using Microsoft.AspNetCore.Components;

namespace DeMol.App.Components.Candidates;

public partial class CandidateEdit : ComponentBase
{

    private Candidate? _candidate;
    
    [Parameter]
    public int? Id { get; set; }
  

    protected override async Task OnInitializedAsync()
    {
        if (Id.HasValue)
        {
            _candidate = await CandidateService.GetCandidateByIdAsync(Id.Value);
        }
        else
        {
            _candidate = new Candidate
            {
                Name = null,
                PhotoUrl = null
            };
        }
    }

    private async Task HandleValidSubmit()
    {
        if (_candidate is {Id: 0})
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