@ModelType IEnumerable(Of FirstAidJournal.UserTeam)

@Code
    ViewData("Title") = Resources.FirstAidJournal.YourTeams
End Code

<h2>@Resources.FirstAidJournal.YourTeams | @Html.ActionLink(Resources.FirstAidJournal.AllTeams, "All")</h2>

<p>
    @Html.ActionLink(Resources.FirstAidJournal.TeamCreate, "Create")
</p>
<table>
    <tr>
        <th>
            @Resources.FirstAidJournal.TeamName
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
            @If Not currentItem.Active Then
                @:@Html.ActionLink(Resources.FirstAidJournal.TeamActivate, "Activate", New With {.id = currentItem.Id}) |
            Else
                @:@Resources.FirstAidJournal.TeamActive |
            End If
            @If currentItem.Administrator Then
                @:@Html.ActionLink(Resources.FirstAidJournal.GeneralEdit, "Edit", New With {.id = currentItem.Id}) |
                @:@Html.ActionLink(Resources.FirstAidJournal.GeneralDelete, "Delete", New With {.id = currentItem.Id}) |
            End If
            @Html.ActionLink(Resources.FirstAidJournal.GeneralDetails, "Details", New With {.id = currentItem.Id})
        </td>
    </tr>
Next

</table>
