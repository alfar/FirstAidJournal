@ModelType IEnumerable(Of FirstAidJournal.Person)

@Code
    ViewData("Title") = Resources.FirstAidJournal.PersonListTitle
End Code

<h2>@Resources.FirstAidJournal.PersonListTitle</h2>

<table>
    <tr>
        <th>
            @Resources.FirstAidJournal.Name
        </th>
        <th>
            @Resources.FirstAidJournal.Gender
        </th>
        <th>
            @Resources.FirstAidJournal.Age
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
            @Html.DisplayFor(Function(modelItem) currentItem.Gender, "Gender")
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.Age)
        </td>
        <td>
            @Html.ActionLink(Resources.FirstAidJournal.EventCreate, "Create", "Event", New With {.PersonId = currentItem.Id}, Nothing) |
            @Html.ActionLink(Resources.FirstAidJournal.GeneralEdit, "Edit", New With {.id = currentItem.Id}) |
            @Html.ActionLink(Resources.FirstAidJournal.GeneralDelete, "Delete", New With {.id = currentItem.Id})
        </td>
    </tr>
Next

</table>
<script type="text/javascript">
    $(function () {
        $('#Name').focus();
    });
</script>