@Code
    Dim list As New List(Of SelectListItem)
    For c As Integer = 0 To 115
        list.Add(New SelectListItem() with {.Value = c, .Text = c.ToString(), .Selected = Model = c})
    Next
End Code
@Html.DropDownListFor(Function(m) m, list)
