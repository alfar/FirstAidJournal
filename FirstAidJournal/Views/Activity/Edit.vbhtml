@ModelType FirstAidJournal.Activity

@Code
    ViewData("Title") = "Edit"
End Code

<h2>Edit</h2>

<script src="@Url.Content("~/Scripts/jquery.validate.min.js")" type="text/javascript"></script>
<script src="@Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js")" type="text/javascript"></script>

@Using Html.BeginForm()
    @Html.ValidationSummary(True)
    @<fieldset>
        <legend>Activity</legend>

        @Html.HiddenFor(Function(model) model.Id)

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.Name)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.Name)
            @Html.ValidationMessageFor(Function(model) model.Name)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.StartDate)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.StartDate)
            @Html.ValidationMessageFor(Function(model) model.StartDate)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.EndDate)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.EndDate)
            @Html.ValidationMessageFor(Function(model) model.EndDate)
        </div>

        @Html.HiddenFor(Function(model) model.TeamId)

        <p>
            <input type="submit" value="Save" />
        </p>
    </fieldset>
End Using

<div>
    @Html.ActionLink("Back to List", "Index")
</div>
