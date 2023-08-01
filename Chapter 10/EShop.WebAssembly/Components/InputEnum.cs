using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;

namespace EShop.WebAssembly.Components;

public class InputEnum<TEnum> : InputBase<TEnum>
{
    protected override bool TryParseValueFromString(string? value, [MaybeNullWhen(false)] out TEnum result, [NotNullWhen(false)] out string? validationErrorMessage)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            result = default;
            validationErrorMessage = $"{nameof(value)} cannot be null";

            return false;
        }

        if (Enum.TryParse(typeof(TEnum), value, out object convertedEnum))
        {
            result = (TEnum)convertedEnum!;
            validationErrorMessage = null;

            return true;
        }

        result = default;
        validationErrorMessage = $"{nameof(value)} is not valid";

        return false;
    }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        builder.OpenElement(0, "select");
        builder.AddMultipleAttributes(1, AdditionalAttributes);
        builder.AddAttribute(2, "onchange", EventCallback.Factory.CreateBinder<string>(this, value => CurrentValueAsString = value, CurrentValueAsString, null));

        // Add an option element per enum value
        foreach (var value in Enum.GetValues(typeof(TEnum)))
        {
            builder.OpenElement(3, "option");
            builder.AddAttribute(4, "value", value.ToString());
            builder.AddContent(5, value.ToString());
            builder.CloseElement();
        }

        builder.CloseElement(); // close the select element
    }
}