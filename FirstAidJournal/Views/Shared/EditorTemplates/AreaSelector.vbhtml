<div style="position: relative; width: 300px; height: 300px; overflow: hidden;">
@Html.HiddenFor(Function(m) m)
<img src="/Content/AreaBackground.png" height="300" width="300" />
@Code
    Dim db As New FirstAidJournal.FirstAidJournalEntities
    
    For Each area In db.Areas
        @<img id="area_@(area.id)" src="/Content/@(If(area.Id = Model, "Selected", ""))Dot.png" height="16" width="16" alt="@area.Name" title="@area.Name" style="position: absolute; top: @(area.Y - 8)px; left: @(area.X - 8)px;" onclick="selectArea('@area.Id');" />
    Next
End Code
</div>
<script type="text/javascript">
    function selectArea(guid) {
        var area = document.getElementById('AreaId');

        if (area.value != '')
        {
            document.getElementById('area_' + area.value).src = "/Content/Dot.png";
        }

        area.value = guid;
        document.getElementById('area_' + area.value).src = "/Content/SelectedDot.png";
    }
</script>
