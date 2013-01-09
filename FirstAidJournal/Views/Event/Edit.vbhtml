@ModelType FirstAidJournal.Event

@Code
    ViewData("Title") = Resources.FirstAidJournal.EditEvent
End Code

<h2>@Resources.FirstAidJournal.EditEvent</h2>

<script src="@Url.Content("~/Scripts/jquery.validate.min.js")" type="text/javascript"></script>
<script src="@Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js")" type="text/javascript"></script>

@Using Html.BeginForm()
    @Html.ValidationSummary(True)
    @<div>
        @Html.HiddenFor(Function(model) model.PersonId)
        @Html.HiddenFor(Function(model) model.Timestamp)

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.InjuryId)
        </div>
        <div class="editor-field">
            @Html.DropDownList("InjuryId")
            @Html.ValidationMessageFor(Function(model) model.InjuryId)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.AreaId)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.AreaId, "AreaSelector")
            @Html.ValidationMessageFor(Function(model) model.AreaId)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.Notes)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.Notes)
            @Html.ValidationMessageFor(Function(model) model.Notes)
        </div>
        @Html.HiddenFor(Function(model) model.TeamId)
        <div class="buttonbar">
            <input type="submit" value="@Resources.FirstAidJournal.CommandSave" class="bigbutton" />
            @Html.ActionLink(Resources.FirstAidJournal.BackToList, "Index", Nothing, New With {.class = "bigbutton"})
        </div>
    </div>
End Using
