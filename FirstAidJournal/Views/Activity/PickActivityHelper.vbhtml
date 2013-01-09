@ModelType FirstAidJournal.ActivityHelper
@Html.ActionLink(If(String.IsNullOrWhiteSpace(Model.Initials), Model.Name, Model.Initials), "Start", "Event", New With {.helperid = Model.Id}, New With {.class = "bigbutton"})
