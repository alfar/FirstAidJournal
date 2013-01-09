@ModelType FirstAidJournal.ActivityHelper
<div class="helper card">
    @Model.Name (@Model.Initials) @Html.ActionLink("Delete", "Delete", "ActivityHelper", New With {.id = Model.Id}, Nothing)
</div>
