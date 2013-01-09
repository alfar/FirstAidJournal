@ModelType FirstAidJournal.Team

@Code
    ViewData("Title") = Resources.FirstAidJournal.TeamCreate
End Code

<h2>@Resources.FirstAidJournal.TeamCreate</h2>

<script src="@Url.Content("~/Scripts/jquery.validate.min.js")" type="text/javascript"></script>
<script src="@Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js")" type="text/javascript"></script>

@Using Html.BeginForm()
    @Html.ValidationSummary(True)
    @<div>
        <div class="editor-label">
            @Html.LabelFor(Function(model) model.Name)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.Name)
            @Html.ValidationMessageFor(Function(model) model.Name)
        </div>

        <div class="buttonbar">
            <input type="submit" value="@Resources.FirstAidJournal.CommandCreate" class="bigbutton" />
            @Html.ActionLink(Resources.FirstAidJournal.BackToList, "Index", Nothing, New With {.class = "bigbutton"})
        </div>
    </div>
End Using
