@ModelType FirstAidJournal.Activity

@Code
    ViewData("Title") = "Home"
End Code

<h2>@Model.Name</h2>

@For Each ah As FirstAidJournal.ActivityHelper In Model.ActivityHelper
    Html.RenderPartial("PickActivityHelper", ah)
Next
