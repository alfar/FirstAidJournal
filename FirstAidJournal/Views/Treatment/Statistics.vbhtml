@ModelType IEnumerable(Of FirstAidJournal.Treatment)

@Code
    ViewData("Title") = "Statistics"
    Dim ActiveTeam As Guid = ViewBag.ActiveTeam
End Code

<h2>@Html.ActionLink("Index", "Index") | Statistics</h2>

<table>
    <tr>
        <th>
            Category
        </th>
        <th>
            Name
        </th>
        <th>
            Used
        </th>
    </tr>

@For Each item In Model
    Dim currentItem = item
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.TreatmentCategory.Name)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.Name )
        </td>
        <td>
            @currentItem.EventTreatments.Where(Function(et) et.Event IsNot Nothing AndAlso et.Event.TeamId.HasValue AndAlso et.Event.TeamId.Value = ViewBag.ActiveTeam).Count
        </td>
    </tr>
Next

</table>
