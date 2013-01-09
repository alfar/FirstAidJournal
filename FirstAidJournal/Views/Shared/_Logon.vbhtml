@If Request.IsAuthenticated Then
    @<text>@Resources.FirstAidJournal.Welcome <strong>@User.Identity.Name</strong>!
    [ @Resources.FirstAidJournal.Team: @Context.Profile.GetPropertyValue("ActiveTeamName") | @Html.ActionLink(Resources.FirstAidJournal.SwitchTeam, "Index", "Team") ] |
    [ @Html.ActionLink(Resources.FirstAidJournal.AccountLogOff, "LogOff", "Account") ]</text>
Else
    @:[ @Html.ActionLink(Resources.FirstAidJournal.AccountLogOn, "LogOn", "Account") ]
End If
@DateTime.now
