Namespace FirstAidJournal
    Public Class ActivityController
        Inherits System.Web.Mvc.Controller
        Private db As FirstAidJournalEntities = New FirstAidJournalEntities

        Function Home() As ActionResult
            Dim activityId As Guid = ProfileHelper.GetActiveActivity()

            If activityId = Guid.Empty Then
                Return RedirectToAction("Start", "Event", Nothing)
            End If
            Return View(db.Activity.Single(Function(a) a.Id = activityId))
        End Function

        '
        ' GET: /Activity/

        Function Index() As ViewResult
            Dim teamId As Guid = ProfileHelper.GetActiveTeam()
            Dim ownerId As Guid = ProfileHelper.GetActiveUserId()

            If teamId <> Guid.Empty Then
                Return View(db.Activity.Where(Function(a) Not a.Finished AndAlso (a.TeamId = teamId OrElse a.OwnerId = ownerId)).OrderBy(Function(a) a.Name).ToList())
            End If

            Return View(db.Activity.Where(Function(a) Not a.Finished AndAlso a.OwnerId = ownerId).OrderBy(Function(a) a.Name).ToList())
        End Function

        Function Activate(id As Guid) As ActionResult
            Me.HttpContext.Profile.SetPropertyValue("ActiveActivity", id)
            Return RedirectToAction("Home")
        End Function

        '
        ' GET: /Activity/Details/5

        Function Details(id As Guid) As ViewResult
            Dim userId As Guid = ProfileHelper.GetActiveUserId()
            Dim Activity As Activity = db.Activity.Single(Function(t) t.Id = id AndAlso (t.OwnerId = userId OrElse t.Team.TeamMember.Any(Function(tm) tm.UserId = userId AndAlso tm.Confirmed)))
            Return View(Activity)
        End Function

        '
        ' GET: /Activity/Create

        Function Create() As ViewResult
            Return View(New Activity With {.StartDate = Today(), .EndDate = Today(), .TeamId = ProfileHelper.GetActiveTeam()})
        End Function

        '
        ' POST: /Activity/Create

        <HttpPost()>
        Function Create(Activity As Activity) As ActionResult
            If ModelState.IsValid Then
                Activity.Id = Guid.NewGuid()
                Activity.OwnerId = ProfileHelper.GetActiveUserId()
                db.Activity.AddObject(Activity)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If

            Return View(Activity)
        End Function

        '
        ' GET: /Activity/Edit/5

        Function Edit(id As Guid) As ViewResult
            Dim userId As Guid = ProfileHelper.GetActiveUserId()
            Dim Activity As Activity = db.Activity.Single(Function(t) t.Id = id AndAlso (t.OwnerId = userId OrElse t.Team.TeamMember.Any(Function(tm) tm.UserId = userId AndAlso tm.Administrator AndAlso tm.Confirmed)))
            Return View(Activity)
        End Function

        '
        ' POST: /Activity/Edit/5

        <HttpPost()>
        Function Edit(Activity As Activity) As ActionResult
            If ModelState.IsValid Then
                db.Activity.Attach(Activity)
                db.ObjectStateManager.ChangeObjectState(Activity, EntityState.Modified)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If

            Return View(Activity)
        End Function

        '
        ' GET: /Activity/Delete/5

        Function Delete(id As Guid) As ViewResult
            Dim userId As Guid = ProfileHelper.GetActiveUserId()
            Dim Activity As Activity = db.Activity.Single(Function(t) t.Id = id AndAlso (t.OwnerId = userId OrElse t.Team.TeamMember.Any(Function(tm) tm.UserId = userId AndAlso tm.Administrator AndAlso tm.Confirmed)))
            Return View(Activity)
        End Function

        '
        ' POST: /Activity/Delete/5

        <HttpPost()>
        <ActionName("Delete")>
        Function DeleteConfirmed(id As Guid) As RedirectToRouteResult
            Dim userId As Guid = ProfileHelper.GetActiveUserId()
            Dim Activity As Activity = db.Activity.Single(Function(t) t.Id = id AndAlso (t.OwnerId = userId OrElse t.Team.TeamMember.Any(Function(tm) tm.UserId = userId AndAlso tm.Administrator AndAlso tm.Confirmed)))
            db.Activity.DeleteObject(Activity)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        Function Finish(id As Guid) As RedirectToRouteResult
            Dim userId As Guid = ProfileHelper.GetActiveUserId()
            Dim Activity As Activity = db.Activity.SingleOrDefault(Function(t) t.Id = id AndAlso (t.OwnerId = userId OrElse t.Team.TeamMember.Any(Function(tm) tm.UserId = userId AndAlso tm.Administrator AndAlso tm.Confirmed)))

            If Activity IsNot Nothing Then
                If Activity.Id = ProfileHelper.GetActiveActivity() Then
                    Me.HttpContext.Profile.SetPropertyValue("ActiveActivity", Guid.Empty)
                End If
                Activity.Finished = True
                db.SaveChanges()
            End If
            Return RedirectToAction("Index")
        End Function

        <HttpPost()>
        Function AddHelper(activityId As Guid, name As String, initials As String)
            Dim ah As New ActivityHelper() With {.Id = Guid.NewGuid(), .ActivityId = activityId, .Name = name, .Initials = initials}

            db.ActivityHelper.AddObject(ah)
            db.SaveChanges()

            Return RedirectToAction("Details", New With {.id = activityId})
        End Function

        Protected Overrides Sub Dispose(disposing As Boolean)
            db.Dispose()
            MyBase.Dispose(disposing)
        End Sub

    End Class
End Namespace
