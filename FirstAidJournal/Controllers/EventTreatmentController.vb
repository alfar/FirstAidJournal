Imports System.Data.Entity
Imports FirstAidJournal

Namespace FirstAidJournal
    <Authorize()>
    Public Class EventTreatmentController
        Inherits System.Web.Mvc.Controller

        Private db As FirstAidJournalEntities = New FirstAidJournalEntities

        '
        ' GET: /EventTreatment/

        Function Index() As ViewResult
            Dim eventtreatments = db.EventTreatments.Include("Event").Include("Treatment")
            Return View(eventtreatments.ToList())
        End Function

        '
        ' GET: /EventTreatment/Details/5

        Function Details(id As Guid) As ViewResult
            Dim eventtreatment As EventTreatment = db.EventTreatments.Single(Function(e) e.Id = id)
            Return View(eventtreatment)
        End Function

        '
        ' GET: /EventTreatment/Create

        Function Create(EventId As Guid) As ViewResult
            ViewBag.EventId = New SelectList(db.Events, "Id", "Notes")
            ViewBag.TreatmentId = New SelectList(db.Treatments, "Id", "Name")
            Return View()
        End Function

        '
        ' POST: /EventTreatment/Create

        <HttpPost()>
        Function Create(eventtreatment As EventTreatment) As ActionResult
            If ModelState.IsValid Then
                eventtreatment.Id = Guid.NewGuid()
                db.EventTreatments.AddObject(eventtreatment)
                db.SaveChanges()
                Return RedirectToAction("Details", "Event", New With {.Id = eventtreatment.EventId})
            End If

            ViewBag.EventId = New SelectList(db.Events, "Id", "Notes", eventtreatment.EventId)
            ViewBag.TreatmentId = New SelectList(db.Treatments, "Id", "Name", eventtreatment.TreatmentId)
            Return View(eventtreatment)
        End Function

        '
        ' GET: /EventTreatment/Edit/5

        Function Edit(id As Guid) As ViewResult
            Dim eventtreatment As EventTreatment = db.EventTreatments.Single(Function(e) e.Id = id)
            ViewBag.EventId = New SelectList(db.Events, "Id", "Notes", eventtreatment.EventId)
            ViewBag.TreatmentId = New SelectList(db.Treatments, "Id", "Name", eventtreatment.TreatmentId)
            Return View(eventtreatment)
        End Function

        '
        ' POST: /EventTreatment/Edit/5

        <HttpPost()>
        Function Edit(eventtreatment As EventTreatment) As ActionResult
            If ModelState.IsValid Then
                db.EventTreatments.Attach(eventtreatment)
                db.ObjectStateManager.ChangeObjectState(eventtreatment, EntityState.Modified)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If

            ViewBag.EventId = New SelectList(db.Events, "Id", "Notes", eventtreatment.EventId)
            ViewBag.TreatmentId = New SelectList(db.Treatments, "Id", "Name", eventtreatment.TreatmentId)
            Return View(eventtreatment)
        End Function

        '
        ' GET: /EventTreatment/Delete/5

        Function Delete(id As Guid) As ActionResult
            Dim eventtreatment As EventTreatment = db.EventTreatments.Single(Function(e) e.Id = id)
            Dim eventId As Guid = eventtreatment.EventId
            db.EventTreatments.DeleteObject(eventtreatment)
            db.SaveChanges()
            Return RedirectToAction("Details", "Event", New With {.Id = eventId})
        End Function

        Protected Overrides Sub Dispose(disposing As Boolean)
            db.Dispose()
            MyBase.Dispose(disposing)
        End Sub

    End Class
End Namespace