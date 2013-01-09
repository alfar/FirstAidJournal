@ModelType FirstAidJournal.EventTreatment

@Code
    ViewData("Title") = "Delete"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<fieldset>
    <legend>EventTreatment</legend>

    <div class="display-label">Event</div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.Event.Notes)
    </div>

    <div class="display-label">Treatment</div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.Treatment.Name)
    </div>
</fieldset>
@Using Html.BeginForm()
    @<p>
        <input type="submit" value="Delete" class="bigbutton" /> |
        @Html.ActionLink("Back to List", "Index")
    </p>
End Using
