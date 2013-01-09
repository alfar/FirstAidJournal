Imports System.Data.Entity
Imports FirstAidJournal

Namespace FirstAidJournal
    <Authorize()>
    Public Class TeamController
        Inherits System.Web.Mvc.Controller

        Private db As FirstAidJournalEntities = New FirstAidJournalEntities

        '
        ' GET: /Team/

        Function Index() As ActionResult
            Dim activeTeam As Guid = DirectCast(HttpContext.Profile.GetPropertyValue("ActiveTeam"), Guid)
            Dim teams = (From t In db.Team From tm In t.TeamMember Where tm.UserId = UserId Select New UserTeam() With {.Id = t.Id, .Name = t.Name, .Administrator = tm.Administrator, .Active = t.Id = activeTeam})

            If teams.Any Then
                Return View(teams)
            End If

            Return RedirectToAction("All", New With {.reason = "noteams"})
        End Function

        Function All(Optional reason As String = Nothing) As ViewResult
            ViewBag.Reason = reason
            Return View(db.Team.ToList())
        End Function

        '
        ' GET: /Team/Details/5

        Function Details(id As Guid) As ViewResult
            Dim team As Team = db.Team.Single(Function(t) t.Id = id)
            ViewBag.IsAdministrator = IsAdministrator(team)
            ViewBag.IsActive = IsActive(team)
            ViewBag.IsMember = ViewBag.IsAdministrator OrElse ViewBag.IsActive OrElse IsMember(team)
            ViewBag.IsPending = IsPending(team)
            Return View(team)
        End Function

        '
        ' GET: /Team/Create

        Function Create() As ViewResult
            Return View()
        End Function

        '
        ' POST: /Team/Create

        <HttpPost()>
        Function Create(team As Team) As ActionResult
            If ModelState.IsValid Then
                team.Id = Guid.NewGuid()
                db.Team.AddObject(team)

                Dim tm As New TeamMember()
                tm.TeamId = team.Id
                tm.UserId = Membership.GetUser().ProviderUserKey
                tm.Administrator = True
                tm.Confirmed = True

                db.TeamMember.AddObject(tm)

                db.SaveChanges()

                HttpContext.Profile.SetPropertyValue("ActiveTeam", team.Id)
                HttpContext.Profile.SetPropertyValue("ActiveTeamName", team.Name)

                Return RedirectToAction("Index")
            End If

            Return View(team)
        End Function

        Private _userId As Guid
        Private ReadOnly Property UserId As Guid
            Get
                If _userId = Guid.Empty Then
                    _userId = Membership.GetUser().ProviderUserKey
                End If

                Return _userId
            End Get
        End Property

        Private Function IsAdministrator(team As Team)
            Return team.TeamMember.Any(Function(tm) tm.UserId = UserId AndAlso tm.Confirmed AndAlso tm.Administrator)
        End Function

        Private Function IsActive(team As Team)
            Return team.Id = HttpContext.Profile.GetPropertyValue("ActiveTeam")
        End Function

        Private Function IsMember(team As Team)
            Return team.TeamMember.Any(Function(tm) tm.UserId = UserId AndAlso tm.Confirmed)
        End Function

        Private Function IsPending(team As Team)
            Return team.TeamMember.Any(Function(tm) tm.UserId = UserId AndAlso Not tm.Confirmed)
        End Function

        Function Join(id As Guid) As ActionResult
            Dim team As Team = db.Team.Single(Function(t) t.Id = id)
            If Not IsMember(team) Then
                team.TeamMember.Add(New TeamMember() With {.UserId = UserId, .Administrator = False, .Confirmed = False, .Active = False})
                db.SaveChanges()
            End If
            Return RedirectToAction("Details", New With {.id = id})
        End Function

        Function Confirm(teamId As Guid, userId As Guid) As ActionResult
            Dim team As Team = db.Team.Single(Function(t) t.Id = teamId)
            If IsAdministrator(team) Then
                Dim tm As TeamMember = team.TeamMember.Single(Function(t) t.UserId = userId)
                tm.Confirmed = True
                db.SaveChanges()
            End If

            Return RedirectToAction("Details", New With {.id = teamId})
        End Function

        Function Promote(teamId As Guid, userId As Guid) As ActionResult
            Dim team As Team = db.Team.Single(Function(t) t.Id = teamId)
            If IsAdministrator(team) Then
                Dim tm As TeamMember = team.TeamMember.Single(Function(t) t.UserId = userId)
                tm.Administrator = True
                db.SaveChanges()
            End If

            Return RedirectToAction("Details", New With {.id = teamId})
        End Function

        Function Demote(teamId As Guid, userId As Guid) As ActionResult
            Dim team As Team = db.Team.Single(Function(t) t.Id = teamId)
            If IsAdministrator(team) Then
                Dim tm As TeamMember = team.TeamMember.Single(Function(t) t.UserId = userId)
                tm.Administrator = False
                db.SaveChanges()
            End If

            Return RedirectToAction("Details", New With {.id = teamId})
        End Function

        Function Kick(teamId As Guid, userId As Guid) As ActionResult
            Dim team As Team = db.Team.Single(Function(t) t.Id = teamId)
            If IsAdministrator(team) Then
                Dim tm As TeamMember = team.TeamMember.Single(Function(t) t.UserId = userId)
                db.TeamMember.DeleteObject(tm)
                db.SaveChanges()
            End If

            Return RedirectToAction("Details", New With {.id = teamId})
        End Function

        Function Activate(id As Guid) As ActionResult
            Dim team As Team = db.Team.Single(Function(t) t.Id = id)
            If IsMember(team) Then
                Me.HttpContext.Profile.SetPropertyValue("ActiveTeam", id)
                Me.HttpContext.Profile.SetPropertyValue("ActiveTeamName", team.Name)
            End If
            Return RedirectToAction("Index", "Event")
        End Function

        '
        ' GET: /Team/Edit/5

        Function Edit(id As Guid) As ActionResult
            Dim team As Team = db.Team.Single(Function(t) t.Id = id)
            If IsAdministrator(team) Then
                Return View(team)
            Else
                Return RedirectToAction("Details", New With {.id = id})
            End If
        End Function

        '
        ' POST: /Team/Edit/5

        <HttpPost()>
        Function Edit(team As Team) As ActionResult
            If ModelState.IsValid Then
                db.Team.Attach(team)
                db.ObjectStateManager.ChangeObjectState(team, EntityState.Modified)
                If IsAdministrator(team) Then
                    db.SaveChanges()
                End If
                Return RedirectToAction("Index")
            End If

            Return View(team)
        End Function

        '
        ' GET: /Team/Delete/5

        Function Delete(id As Guid) As ActionResult
            Dim team As Team = db.Team.Single(Function(t) t.Id = id)
            If IsAdministrator(team) Then
                Return View(team)
            Else
                Return RedirectToAction("Details", New With {.id = id})
            End If
        End Function

        '
        ' POST: /Team/Delete/5

        <HttpPost()>
        <ActionName("Delete")>
        Function DeleteConfirmed(id As Guid) As RedirectToRouteResult
            Dim team As Team = db.Team.Single(Function(t) t.Id = id)
            If IsAdministrator(team) Then
                db.Team.DeleteObject(team)
                db.SaveChanges()
                Return RedirectToAction("Index")
            Else
                Return RedirectToAction("Details", New With {.id = id})
            End If
        End Function

        Protected Overrides Sub Dispose(disposing As Boolean)
            db.Dispose()
            MyBase.Dispose(disposing)
        End Sub

    End Class
End Namespace