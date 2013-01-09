@ModelType FirstAidJournal.Team

@Code
    ViewData("Title") = Resources.FirstAidJournal.TeamDelete
End Code

<h2>@Resources.FirstAidJournal.TeamDelete</h2>

<h3>@Resources.FirstAidJournal.TeamAreYouSure</h3>
<div>
    <div class="display-label">Name</div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.Name)
    </div>
</div>
@Using Html.BeginForm()
    @<div class="buttonbar">
        <input type="submit" value="@Resources.FirstAidJournal.CommandDelete" class="bigbutton" />
        @Html.ActionLink(Resources.FirstAidJournal.BackToList, "Index", Nothing, New With {.class = "bigbutton"})
    </div>
End Using
