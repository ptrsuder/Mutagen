namespace Mutagen.Bethesda.Skyrim;

public partial class IsCarryableConditionData : IConditionStringParameter
{
    string? IConditionStringParameterGetter.FirstStringParameter => FirstUnusedStringParameter;

    string? IConditionStringParameterGetter.SecondStringParameter => SecondUnusedStringParameter;

    string? IConditionStringParameter.FirstStringParameter
    {
        get => FirstUnusedStringParameter;
        set => FirstUnusedStringParameter = value;
    }

    string? IConditionStringParameter.SecondStringParameter
    {
        get => SecondUnusedStringParameter;
        set => SecondUnusedStringParameter = value;
    }

}

internal partial class IsCarryableConditionDataBinaryOverlay
{
    public string? FirstUnusedStringParameter => ParameterOneString;

    public string? SecondUnusedStringParameter => ParameterTwoString;

}
