@ModelType FirstAidJournal.Team

@Code
    ViewData("Title") = Resources.FirstAidJournal.TeamDetails
End Code

<h2>@Resources.FirstAidJournal.TeamDetails</h2>

<div>
    <div class="display-label">@Resources.FirstAidJournal.TeamName</div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.Name)
    </div>
</div>

@If ViewBag.IsMember Then
@<fieldset>
    <legend>@Resources.FirstAidJournal.TeamMembers</legend>
    <ul>
        @For Each tm In Model.TeamMember
            @<li>@Membership.GetUser(tm.UserId).UserName
            @If ViewBag.IsAdministrator Then
                If Not tm.Confirmed Then
                    @: - @Html.ActionLink(Resources.FirstAidJournal.TeamMemberConfirm, "Confirm", New With {.teamId = Model.Id, .userId = tm.UserId})
                ElseIf Not tm.Administrator Then
                    @: - @Html.ActionLink(Resources.FirstAidJournal.TeamMemberPromote, "Promote", New With {.teamId = Model.Id, .userId = tm.UserId})
                Else
                    @: - @Html.ActionLink(Resources.FirstAidJournal.TeamMemberDemote, "Demote", New With {.teamId = Model.Id, .userId = tm.UserId})                
                End If
                @: - @Html.ActionLink(Resources.FirstAidJournal.TeamMemberKick, "Kick", New With {.teamId = Model.Id, .userId = tm.UserId})
            End If
            </li>
        Next
    </ul>
</fieldset>    
End If

<p>
    @If ViewBag.IsAdministrator Then
        @:@Html.ActionLink(Resources.FirstAidJournal.TeamEdit, "Edit", New With {.id = Model.Id}) |
        @:@Html.ActionLink(Resources.FirstAidJournal.TeamDelete, "Delete", New With {.id = Model.Id}) |
    End If
    @If ViewBag.IsMember Then
        If Not ViewBag.IsActive Then
            @:@Html.ActionLink(Resources.FirstAidJournal.TeamActivate , "Activate", New With {.id = Model.Id}) |
        Else
            @:@Resources.FirstAidJournal.TeamIsActive |  
        End If
    ElseIf ViewBag.IsPending Then
        @:@Resources.FirstAidJournal.TeamIsPending |
    Else
        @:@Html.ActionLink(Resources.FirstAidJournal.TeamJoin, "Join", New With {.id = Model.Id}) |
    End If
    @Html.ActionLink(Resources.FirstAidJournal.BackToList, "Index")
</p>
