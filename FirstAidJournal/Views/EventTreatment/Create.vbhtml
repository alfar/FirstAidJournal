@ModelType FirstAidJournal.EventTreatment

@Code
    ViewData("Title") = "Create"
End Code

<h2>Create</h2>

<script src="@Url.Content("~/Scripts/jquery.validate.min.js")" type="text/javascript"></script>
<script src="@Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js")" type="text/javascript"></script>

@Using Html.BeginForm()
    @Html.ValidationSummary(True)
    @<fieldset>
        <legend>EventTreatment</legend>

        @Html.HiddenFor(Function(et) et.EventId)

        @Html.EditorFor(Function(et) et.TreatmentId, "TreatmentSelector")

        <p>
            <input type="submit" value="Create" class="bigbutton" />
        </p>
    </fieldset>
End Using

<div>
    @Html.ActionLink("Back to List", "Index")
</div>
