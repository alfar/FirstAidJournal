@ModelType FirstAidJournal.Person    
<a href="@Url.Action("Create", "Event", New With {.PersonId = Model.Id, .HelperId = ViewBag.HelperId})" class="card person block">
    @Html.DisplayFor(Function(m) m.Gender, "Gender")
    @Html.DisplayFor(Function(m) m.Name), 
    @Html.DisplayFor(Function(m) m.Age) - @Model.Event.Count @(If(Model.Event.Count = 1, Resources.FirstAidJournal.EventSingular, Resources.FirstAidJournal.EventPlural))
</a>
