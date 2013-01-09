@ModelType FirstAidJournal.EventTreatment
<div style="width: 300px;">
@Using Html.BeginForm("Create", "EventTreatment", Nothing, FormMethod.Post, New With {.id = "EventTreatmentForm"})
    @Html.HiddenFor(Function(et) et.EventId)
    @Html.EditorFor(Function(et) et.TreatmentId, "TreatmentSelector")
End Using
</div>