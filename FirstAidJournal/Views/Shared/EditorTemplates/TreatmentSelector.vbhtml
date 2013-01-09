@Code
    Dim db As New FirstAidJournal.FirstAidJournalEntities
End Code
@Html.HiddenFor(Function(m) m)
<ul class="select">
@For Each tg As FirstAidJournal.TreatmentCategory In db.TreatmentCategories
        @<li id="tg_@(tg.Id)" class="treatmentCategory" onclick="toggleCategory('@tg.Id')">@tg.Name</li>
        @<ul id="gtg_@(tg.Id)" style="display: none;">
        @For Each t As FirstAidJournal.Treatment In tg.Treatments
            @<li id="t_@(t.Id)" class="treatment" onclick="selectTreatment('@t.Id')">@t.Name</li>
        Next
        </ul>
Next
</ul>
<script type="text/javascript">
    function toggleCategory(guid) {
        if (document.getElementById('gtg_' + guid).style.display == 'none') {
            document.getElementById('gtg_' + guid).style.display = 'block';
        } else {
            document.getElementById('gtg_' + guid).style.display = 'none';
        }
    }

    function selectTreatment(guid) {
        var treatment = document.getElementById('TreatmentId');

        if (treatment.value != '' && document.getElementById('t_' + treatment.value)) {
            document.getElementById('t_' + treatment.value).className = 'treatment';
        }
        treatment.value = guid;
        document.getElementById('t_' + treatment.value).className = 'treatment selected';

        document.getElementById('EventTreatmentForm').submit();
    }
</script>
