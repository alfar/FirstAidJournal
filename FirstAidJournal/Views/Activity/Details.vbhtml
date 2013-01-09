@ModelType FirstAidJournal.Activity

@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<fieldset>
    <legend>Activity</legend>

    <div class="display-label">Name</div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.Name)
    </div>

    <div class="display-label">StartDate</div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.StartDate)
    </div>

    <div class="display-label">EndDate</div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.EndDate)
    </div>
</fieldset>

@Using Html.BeginForm("AddHelper", "Activity")
    @<fieldset>
        <legend>Add</legend>
        <div class="display-label">Name</div>
        <div class="display-field">
            @Html.TextBox("name", "")
        </div>

        <div class="display-label">Initials</div>
        <div class="display-field">
            @Html.TextBox("initials", "")
        </div>

        <div class="commandbar"><input type="submit" value="Add" class="bigbutton" /></div>
        @Html.Hidden("activityId", Model.Id)
    </fieldset>
End Using

<fieldset>
    <legend>Helpers</legend>

    @Html.DisplayFor(Function (model) model.ActivityHelper)
</fieldset>

<p>

    @Html.ActionLink("Edit", "Edit", New With {.id = Model.Id}) |
    @Html.ActionLink("Back to List", "Index")
</p>
