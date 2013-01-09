@ModelType FirstAidJournal.Event

@Code
    ViewData("Title") = Resources.FirstAidJournal.EventDetails
End Code

<h2>@Resources.FirstAidJournal.EventDetails</h2>

    <div class="display-label">@Resources.FirstAidJournal.Timestamp</div>
    <div class="display-field">
        @Html.DisplayFor(Function(e) e.Timestamp)
    </div>


    <div class="display-label">@Resources.FirstAidJournal.Person</div>
    <div class="display-field">
        @Html.DisplayFor(Function(e) e.Person.Name) (@Html.DisplayFor(Function(e) e.Person.Gender, "GenderText"), @Html.DisplayFor(Function(e) e.Person.Age))
    </div>

    <div class="display-label">@Resources.FirstAidJournal.Injury</div>
    <div class="display-field">
        @Html.DisplayFor(Function(e) e.Injury.Name)
    </div>

    <div class="display-label">@Resources.FirstAidJournal.Area</div>
    <div class="display-field">
        @Html.DisplayFor(Function(e) e.Area.Name)
    </div>

<h2>@Resources.FirstAidJournal.Treatments</h2>
<fieldset style="float: left; width: 300px; padding: 5px; margin-right: 5px; border: 1px solid #666;">
    <legend>@Resources.FirstAidJournal.GeneralAdd</legend>
@Html.Partial("_AddTreatment", New FirstAidJournal.EventTreatment with {.EventId = Model.Id})
</fieldset>
<fieldset style="margin-left: 320px; border: 1px solid #666; padding: 5px;">
    <legend>@Resources.FirstAidJournal.Performed</legend>
    @Html.DisplayFor(Function(e) e.EventTreatments)
</fieldset>
<br style="clear: both;" />
@Html.ActionLink(Resources.FirstAidJournal.EventFinished, "Home", "Activity", Nothing, New With {.class = "bigbutton"})
