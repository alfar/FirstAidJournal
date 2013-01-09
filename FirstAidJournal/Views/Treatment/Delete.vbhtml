@ModelType FirstAidJournal.Treatment

@Code
    ViewData("Title") = "Delete"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<fieldset>
    <legend>Treatment</legend>

    <div class="display-label">Name</div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.Name)
    </div>

    <div class="display-label">TreatmentCategory</div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.TreatmentCategory.Name)
    </div>
</fieldset>
@Using Html.BeginForm()
    @<p>
        <input type="submit" value="Delete" class="bigbutton" /> |
        @Html.ActionLink("Back to List", "Index")
    </p>
End Using
