using EShop.WebAssembly.Components;

namespace EShop.WebAssembly.Pages;

public partial class RequestItem
{
    private Models.RequestItem _requestItem = new Models.RequestItem();
    private RequestItemValidator _validator;

    private void OnSubmit()
    {
        _validator.Clear();
        var messages = new List<ValidationMessage>();

        // validation logic
        if (_requestItem.Count < 1)
        {
            messages.Add(new ValidationMessage(nameof(_requestItem.Count), $"{nameof(_requestItem.Count)} must be positive"));
        }

        if (messages.Count > 0)
        {
            _validator.Show(messages);

            return;
        }

        // submit to the server
        var random = new Random();
        var passServerValidation = random.Next(2) >= 1;
        if (!passServerValidation)
        {
            messages.Add(new ValidationMessage(nameof(_requestItem.EShopItemName), $"{nameof(_requestItem.EShopItemName)} does not pass the server validation"));

            _validator.Show(messages);
        }
    }
}