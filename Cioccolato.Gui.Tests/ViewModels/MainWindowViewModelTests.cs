using Cioccolato.Gui.ViewModels;
using FluentAssertions;

namespace Cioccolato.Gui.Tests.ViewModels;

/// <summary>
/// Tests for <see cref="MainWindowViewModel"/> verifying add, remove, and remove-all command behavior.
/// </summary>
public class MainWindowViewModelTests
{
    private readonly MainWindowViewModel _sut = new();

    [Fact]
    public void Add_WithNullInput_DoesNotAddToList()
    {
        _sut.NewVarietyName = null!;

        _sut.AddCommand.CanExecute(null).Should().BeFalse();
    }

    [Fact]
    public void Add_WithEmptyInput_DoesNotAddToList()
    {
        _sut.NewVarietyName = string.Empty;

        _sut.AddCommand.CanExecute(null).Should().BeFalse();
    }

    [Fact]
    public void Add_WithBlankInput_DoesNotAddToList()
    {
        _sut.NewVarietyName = "   ";

        _sut.AddCommand.CanExecute(null).Should().BeFalse();
    }

    [Fact]
    public void Add_WithExistingVariety_DoesNotAddToList()
    {
        var existingName = _sut.Varieties[0].Name;
        var initialCount = _sut.Varieties.Count;

        _sut.NewVarietyName = existingName;

        _sut.AddCommand.CanExecute(null).Should().BeFalse();
        _sut.Varieties.Should().HaveCount(initialCount);
    }

    [Fact]
    public void Add_WithNewVariety_AddsToListAndClearsInput()
    {
        var initialCount = _sut.Varieties.Count;

        _sut.NewVarietyName = "Bittersweet";
        _sut.AddCommand.Execute(null);

        _sut.Varieties.Should().HaveCount(initialCount + 1);
        _sut.Varieties.Should().Contain(v => v.Name == "Bittersweet");
        _sut.NewVarietyName.Should().BeEmpty();
    }

    [Fact]
    public void Remove_WithNoSelection_CannotExecute()
    {
        _sut.SelectedVarieties.Clear();

        _sut.RemoveCommand.CanExecute(null).Should().BeFalse();
    }

    [Fact]
    public void Remove_WithSelectedVarieties_RemovesThemFromList()
    {
        var itemToRemove = _sut.Varieties[0];
        _sut.SelectedVarieties.Add(itemToRemove);

        _sut.RemoveCommand.Execute(null);

        _sut.Varieties.Should().NotContain(itemToRemove);
    }

    [Fact]
    public void RemoveAll_WithNonEmptyList_ClearsAllVarieties()
    {
        _sut.Varieties.Should().NotBeEmpty();

        _sut.RemoveAllCommand.Execute(null);

        _sut.Varieties.Should().BeEmpty();
    }

    [Fact]
    public void RemoveAll_WithEmptyList_CannotExecute()
    {
        _sut.Varieties.Clear();

        _sut.RemoveAllCommand.CanExecute(null).Should().BeFalse();
    }
}
