@ModelType IEnumerable(Of FirstAidJournal.Event)

@Code
    ViewData("Title") = Resources.FirstAidJournal.EventsListTitle
End Code

<h2>@Resources.FirstAidJournal.EventsListTitle</h2>

<table>
    <tr>
        <th>
            @Resources.FirstAidJournal.Person
        </th>
        <th>
            @Resources.FirstAidJournal.Timestamp
        </th>
        <th>
            @Resources.FirstAidJournal.Injury
        </th>
        <th>
            @Resources.FirstAidJournal.Area
        </th>
        <th>
            @Resources.FirstAidJournal.Helper
        </th>
        <th></th>
    </tr>

@For Each item In Model
    Dim currentItem = item
    @<tr>
        <td>
            @Html.ActionLink(currentItem.Person.Name, "Edit", "Person", New With {.Id = currentItem.PersonId}, Nothing)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.Timestamp)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.Injury.Name)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.Area.Name )
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.ActivityHelper.Initials)
        </td>
        <td>
            @Html.ActionLink(Resources.FirstAidJournal.GeneralEdit, "Edit", New With {.id = currentItem.Id}) |
            @Html.ActionLink(Resources.FirstAidJournal.GeneralDetails , "Details", New With {.id = currentItem.Id}) |
            @Html.ActionLink(Resources.FirstAidJournal.GeneralDelete , "Delete", New With {.id = currentItem.Id})
        </td>
    </tr>
Next
</table>
