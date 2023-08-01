using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace EShop.WebAssembly.Components;

public class ValidationMessage
{
    public string Field { get; }
    public string Message { get; }

    public ValidationMessage(string field, string message)
    {
        Field = field;
        Message = message;
    }
}

public class RequestItemValidator : ComponentBase
{
    private ValidationMessageStore _validationMessageStore;

    [CascadingParameter]
    private EditContext EditContext { get; set; }

    protected override void OnInitialized()
    {
        base.OnInitialized();

        _validationMessageStore = new ValidationMessageStore(EditContext);

        EditContext.OnValidationRequested += (_, _) => Clear();
        EditContext.OnFieldChanged += (_, e) => Clear(e.FieldIdentifier);
    }

    public void Show(IEnumerable<ValidationMessage> validationMessages)
    {
        foreach (var item in validationMessages)
        {
            _validationMessageStore.Add(EditContext.Field(item.Field), item.Message);
        }

        EditContext.NotifyValidationStateChanged();
    }

    public void Clear()
    {
        _validationMessageStore.Clear();
        EditContext.NotifyValidationStateChanged();
    }

    public void Clear(FieldIdentifier fieldIdentifier)
    {
        _validationMessageStore.Clear(fieldIdentifier);
        EditContext.NotifyValidationStateChanged();
    }
}