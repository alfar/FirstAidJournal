@Code
    ViewData("Title") = Resources.FirstAidJournal.EventCreate
End Code

<h2>@Resources.FirstAidJournal.EventCreate</h2>

@Html.Partial("/Views/Person/_CreatePerson.vbhtml", New FirstAidJournal.Person)
