@ModelType FirstAidJournal.Treatment

@Code
    ViewData("Title") = "Create"
End Code

<h2>Create</h2>

<script src="@Url.Content("~/Scripts/jquery.validate.min.js")" type="text/javascript"></script>
<script src="@Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js")" type="text/javascript"></script>

@Using Html.BeginForm()
    @Html.ValidationSummary(True)
    @<fieldset>
        <legend>Treatment</legend>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.Name)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.Name)
            @Html.ValidationMessageFor(Function(model) model.Name)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.TreatmentCategoryId, "TreatmentCategory")
        </div>
        <div class="editor-field">
            @Html.DropDownList("TreatmentCategoryId", String.Empty)
            @Html.ValidationMessageFor(Function(model) model.TreatmentCategoryId)
        </div>

        <p>
            <input type="submit" value="Create" class="bigbutton" />
        </p>
    </fieldset>
End Using

<div>
    @Html.ActionLink("Back to List", "Index")
</div>
