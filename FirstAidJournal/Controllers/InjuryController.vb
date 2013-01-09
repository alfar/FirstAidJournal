Imports System.Data.Entity
Imports FirstAidJournal

Namespace FirstAidJournal
    <Authorize(Roles:="Administrators")>
    Public Class InjuryController
        Inherits System.Web.Mvc.Controller

        Private db As FirstAidJournalEntities = New FirstAidJournalEntities

        '
        ' GET: /Injury/

        Function Index() As ViewResult
            Return View(db.Injuries.ToList())
        End Function

        '
        ' GET: /Injury/Details/5

        Function Details(id As Guid) As ViewResult
            Dim injury As Injury = db.Injuries.Single(Function(i) i.Id = id)
            Return View(injury)
        End Function

        '
        ' GET: /Injury/Create

        Function Create() As ViewResult
            Return View()
        End Function

        '
        ' POST: /Injury/Create

        <HttpPost()>
        Function Create(injury As Injury) As ActionResult
            If ModelState.IsValid Then
                injury.Id = Guid.NewGuid()
                db.Injuries.AddObject(injury)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If

            Return View(injury)
        End Function

        '
        ' GET: /Injury/Edit/5

        Function Edit(id As Guid) As ViewResult
            Dim injury As Injury = db.Injuries.Single(Function(i) i.Id = id)
            Return View(injury)
        End Function

        '
        ' POST: /Injury/Edit/5

        <HttpPost()>
        Function Edit(injury As Injury) As ActionResult
            If ModelState.IsValid Then
                db.Injuries.Attach(injury)
                db.ObjectStateManager.ChangeObjectState(injury, EntityState.Modified)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If

            Return View(injury)
        End Function

        '
        ' GET: /Injury/Delete/5

        Function Delete(id As Guid) As ViewResult
            Dim injury As Injury = db.Injuries.Single(Function(i) i.Id = id)
            Return View(injury)
        End Function

        '
        ' POST: /Injury/Delete/5

        <HttpPost()>
        <ActionName("Delete")>
        Function DeleteConfirmed(id As Guid) As RedirectToRouteResult
            Dim injury As Injury = db.Injuries.Single(Function(i) i.Id = id)
            db.Injuries.DeleteObject(injury)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(disposing As Boolean)
            db.Dispose()
            MyBase.Dispose(disposing)
        End Sub

    End Class
End Namespace