@ModelType FirstAidJournal.Person

@Code
    ViewData("Title") = Resources.FirstAidJournal.PersonCreate
End Code

<h2>@Resources.FirstAidJournal.PersonCreate</h2>

<script src="@Url.Content("~/Scripts/jquery.validate.min.js")" type="text/javascript"></script>
<script src="@Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js")" type="text/javascript"></script>

@Html.Partial("_CreatePerson", New FirstAidJournal.Person)
