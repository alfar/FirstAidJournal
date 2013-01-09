@ModelType IEnumerable(Of FirstAidJournal.Team)

@Code
    ViewData("Title") = Resources.FirstAidJournal.AllTeams
End Code

<h2>@Html.ActionLink(Resources.FirstAidJournal.YourTeams, "Index") | @Resources.FirstAidJournal.AllTeams</h2>

<p>
    @Html.ActionLink(Resources.FirstAidJournal.TeamCreate, "Create")
</p>
<table>
    <tr>
        <th>
            @Resources.FirstAidJournal.Name
        </th>
        <th></th>
    </tr>

@For Each item In Model
    Dim currentItem = item
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.Name)
        </td>
        <td>
            @Html.ActionLink(Resources.FirstAidJournal.GeneralDetails, "Details", New With {.id = currentItem.Id})
        </td>
    </tr>
Next

</table>
