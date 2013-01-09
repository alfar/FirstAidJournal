@ModelType FirstAidJournal.Injury

@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<fieldset>
    <legend>Injury</legend>

    <div class="display-label">Name</div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.Name)
    </div>
</fieldset>
<p>

    @Html.ActionLink("Edit", "Edit", New With {.id = Model.Id}) |
    @Html.ActionLink("Back to List", "Index")
</p>
