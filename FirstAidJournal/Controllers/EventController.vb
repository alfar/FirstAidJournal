Namespace FirstAidJournal
    <Authorize()>
    Public Class EventController
        Inherits System.Web.Mvc.Controller

        Private db As FirstAidJournalEntities = New FirstAidJournalEntities

        '
        ' GET: /Event

        Function Index() As ActionResult
            Dim activeTeam As Guid = ProfileHelper.GetActiveTeam()
            If activeTeam = Guid.Empty Then
                Dim activeActivity As Guid = ProfileHelper.GetActiveActivity()
                If activeActivity = Guid.Empty Then
                    Dim userId As Guid = ProfileHelper.GetActiveUserId()
                    Return View(From e In db.Events Where e.OwnerId = userId)
                End If
                Return View(From e In db.Events Where e.ActivityId = activeActivity)
            End If
            Return View(From e In db.Events Where e.TeamId = activeTeam)
        End Function

        Function Start(Optional helperId As Guid? = Nothing) As ActionResult
            ViewBag.HelperId = helperId.GetValueOrDefault()
            Return View()
        End Function

        Function Create(PersonId As Guid, Optional HelperId As Guid? = Nothing) As ActionResult
            ViewBag.InjuryId = New SelectList(db.Injuries, "Id", "Name")
            Return View()
        End Function

        <HttpPost()>
        Function Create(ev As [Event]) As ActionResult
            If ModelState.IsValid Then
                ev.Id = Guid.NewGuid()
                ev.Timestamp = DateTime.Now()
                ev.TeamId = ProfileHelper.GetActiveTeam()
                ev.ActivityId = ProfileHelper.GetActiveActivity()
                ev.OwnerId = ProfileHelper.GetActiveUserId()
                db.Events.AddObject(ev)
                db.SaveChanges()
                Return RedirectToAction("Details", New With {.Id = ev.Id})
            End If

            ViewBag.InjuryId = New SelectList(db.Injuries, "Id", "Name", ev.InjuryId.ToString())
            Return View(ev)
        End Function

        Function Details(Id As Guid) As ActionResult
            Return View(db.Events.FirstOrDefault(Function(e) e.Id = Id))
        End Function

        Function Edit(Id As Guid) As ActionResult
            Dim ev As [Event] = db.Events.FirstOrDefault(Function(e) e.Id = Id)

            ViewBag.InjuryId = New SelectList(db.Injuries, "Id", "Name", ev.InjuryId)

            Return View(ev)
        End Function

        <HttpPost()>
        Function Edit(ev As [Event]) As ActionResult
            If ModelState.IsValid Then
                db.Events.Attach(ev)
                db.ObjectStateManager.ChangeObjectState(ev, EntityState.Modified)
                db.SaveChanges()
                Return RedirectToAction("Details", New With {.Id = ev.Id})
            End If

            ViewBag.InjuryId = New SelectList(db.Injuries, "Id", "Name", ev.InjuryId)
            Return View(ev)
        End Function
    End Class
End Namespace
