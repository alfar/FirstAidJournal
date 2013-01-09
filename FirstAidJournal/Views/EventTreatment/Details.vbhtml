@ModelType FirstAidJournal.EventTreatment

@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

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
<p>

    @Html.ActionLink("Edit", "Edit", New With {.id = Model.Id}) |
    @Html.ActionLink("Back to List", "Index")
</p>
