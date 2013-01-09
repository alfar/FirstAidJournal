@ModelType FirstAidJournal.Area

@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<fieldset>
    <legend>Area</legend>

    <div class="display-label">Name</div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.Name)
    </div>

    <div class="display-label">X</div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.X)
    </div>

    <div class="display-label">Y</div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.Y)
    </div>
</fieldset>
<p>

    @Html.ActionLink("Edit", "Edit", New With {.id = Model.Id}) |
    @Html.ActionLink("Back to List", "Index")
</p>
