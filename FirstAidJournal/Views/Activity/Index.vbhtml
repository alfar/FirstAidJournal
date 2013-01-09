@ModelType IEnumerable(Of FirstAidJournal.Activity)

@Code
    ViewData("Title") = "Index"
End Code

<h2>Index</h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<table>
    <tr>
        <th>
            Name
        </th>
        <th>
            StartDate
        </th>
        <th>
            EndDate
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
            @Html.DisplayFor(Function(modelItem) currentItem.StartDate, "Date")
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.EndDate, "Date")
        </td>
        <td>
            @Html.ActionLink("Activate", "Activate", New With {.id = currentItem.Id}) |
            @Html.ActionLink("Edit", "Edit", New With {.id = currentItem.Id}) |
            @Html.ActionLink("Details", "Details", New With {.id = currentItem.Id}) |
            @Html.ActionLink("Delete", "Delete", New With {.id = currentItem.Id})
            @Html.ActionLink("Finish", "Finish", New With {.id = currentItem.Id})
        </td>
    </tr>
Next

</table>
