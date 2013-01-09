@ModelType FirstAidJournal.Area

@Code
    ViewData("Title") = "Delete"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
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
@Using Html.BeginForm()
    @<p>
        <input type="submit" value="Delete" class="bigbutton" /> |
        @Html.ActionLink("Back to List", "Index")
    </p>
End Using
