@ModelType FirstAidJournal.Area
<div style="position: relative; width: 300px; height: 300px; overflow: hidden;" onclick="setCoordinates()">
@Html.HiddenFor(Function(m) m.X)
@Html.HiddenFor(Function(m) m.Y)
<img src="/Content/AreaBackground.png" height="300" width="300" />
<img id="marker" src="/Content/Dot.png" height="16" width="16" alt="" style="position: absolute; top: @(If(Model Is Nothing, 0, Model.Y - 8))px; left: @(If(Model Is Nothing, 0, Model.X - 8))px;" />
</div>
<script type="text/javascript">
    function setCoordinates(e) {
        if (!e) {
            e = event;
        }

        document.getElementById('X').value = e.x;
        document.getElementById('Y').value = e.y;

        document.getElementById('marker').style.left = (e.x - 8) + 'px';
        document.getElementById('marker').style.top = (e.y - 8) + 'px';
    }
</script>