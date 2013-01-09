@ModelType FirstAidJournal.Person

@Code
    ViewData("Title") = Resources.FirstAidJournal.PersonEdit
End Code

<h2>@Resources.FirstAidJournal.PersonEdit</h2>

<script src="@Url.Content("~/Scripts/jquery.validate.min.js")" type="text/javascript"></script>
<script src="@Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js")" type="text/javascript"></script>

@Using Html.BeginForm()
    @Html.ValidationSummary(True)
    @<div>
        @Html.HiddenFor(Function(model) model.Id)

        <div class="editor-label">
            @Resources.FirstAidJournal.Name
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.Name)
            @Html.ValidationMessageFor(Function(model) model.Name)
        </div>

        <div class="editor-label">
            @Resources.FirstAidJournal.Gender 
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.Gender, "Gender")
            @Html.ValidationMessageFor(Function(model) model.Gender)
        </div>

        <div class="editor-label">
            @Resources.FirstAidJournal.Age 
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.Age, "Age")
            @Html.ValidationMessageFor(Function(model) model.Age)
        </div>
        @Html.HiddenFor(Function(model) model.team)
        <div class="buttonbar">
            <input type="submit" value="@Resources.FirstAidJournal.CommandSave" class="bigbutton" />
            @Html.ActionLink(Resources.FirstAidJournal.BackToList, "Index", Nothing, New With {.class = "bigbutton"})
        </div>
    </div>
End Using
    <fieldset>
        <legend>@Resources.FirstAidJournal.EventsListTitle</legend>
        <ul>
@For Each ev As FirstAidJournal.Event In Model.Event
    @<li>@Html.ActionLink(String.Format("{0} - {1} {2}", ev.Timestamp, ev.Injury.Name, ev.Area.Name), "Details", "Event", New With {.Id = ev.Id}, Nothing)</li>    
Next
        </ul>
    </fieldset>

<div>
</div>
