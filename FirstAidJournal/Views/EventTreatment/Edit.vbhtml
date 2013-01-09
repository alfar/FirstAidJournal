@ModelType FirstAidJournal.EventTreatment

@Code
    ViewData("Title") = "Edit"
End Code

<h2>Edit</h2>

<script src="@Url.Content("~/Scripts/jquery.validate.min.js")" type="text/javascript"></script>
<script src="@Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js")" type="text/javascript"></script>

@Using Html.BeginForm()
    @Html.ValidationSummary(True)
    @<fieldset>
        <legend>EventTreatment</legend>

        @Html.HiddenFor(Function(model) model.Id)

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.EventId, "Event")
        </div>
        <div class="editor-field">
            @Html.DropDownList("EventId", String.Empty)
            @Html.ValidationMessageFor(Function(model) model.EventId)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.TreatmentId, "Treatment")
        </div>
        <div class="editor-field">
            @Html.DropDownList("TreatmentId", String.Empty)
            @Html.ValidationMessageFor(Function(model) model.TreatmentId)
        </div>

        <p>
            <input type="submit" value="Save" class="bigbutton" />
        </p>
    </fieldset>
End Using

<div>
    @Html.ActionLink("Back to List", "Index")
</div>
