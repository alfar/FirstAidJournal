@ModelType FirstAidJournal.Person

@Code
    ViewData("Title") = Resources.FirstAidJournal.PersonDelete
End Code

<h2>@Resources.FirstAidJournal.PersonDelete</h2>

<h3>@Resources.FirstAidJournal.PersonAreYouSure</h3>
<fieldset>
    <div class="display-label">@Resources.FirstAidJournal.Name</div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.Name)
    </div>

    <div class="display-label">@Resources.FirstAidJournal.Gender</div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.Gender, "Gender")
    </div>

    <div class="display-label">@Resources.FirstAidJournal.Age</div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.Age)
    </div>
</fieldset>
@Using Html.BeginForm()
    @<div class="buttonbar">
        <input type="submit" value="@Resources.FirstAidJournal.CommandDelete" class="bigbutton" />
        @Html.ActionLink(Resources.FirstAidJournal.BackToList, "Index", Nothing, New With {.class = "bigbutton"})
    </div>
End Using
