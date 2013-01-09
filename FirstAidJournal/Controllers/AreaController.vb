Imports System.Data.Entity
Imports FirstAidJournal

Namespace FirstAidJournal
    <Authorize(Roles:="Administrators")>
    Public Class AreaController
        Inherits System.Web.Mvc.Controller

        Private db As FirstAidJournalEntities = New FirstAidJournalEntities

        '
        ' GET: /Area/

        Function Index() As ViewResult
            Return View(db.Areas.ToList())
        End Function

        '
        ' GET: /Area/Details/5

        Function Details(id As Guid) As ViewResult
            Dim area As Area = db.Areas.Single(Function(a) a.Id = id)
            Return View(area)
        End Function

        '
        ' GET: /Area/Create

        Function Create() As ViewResult
            Return View()
        End Function

        '
        ' POST: /Area/Create

        <HttpPost()>
        Function Create(area As Area) As ActionResult
            If ModelState.IsValid Then
                area.Id = Guid.NewGuid()
                db.Areas.AddObject(area)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If

            Return View(area)
        End Function

        '
        ' GET: /Area/Edit/5

        Function Edit(id As Guid) As ViewResult
            Dim area As Area = db.Areas.Single(Function(a) a.Id = id)
            Return View(area)
        End Function

        '
        ' POST: /Area/Edit/5

        <HttpPost()>
        Function Edit(area As Area) As ActionResult
            If ModelState.IsValid Then
                db.Areas.Attach(area)
                db.ObjectStateManager.ChangeObjectState(area, EntityState.Modified)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If

            Return View(area)
        End Function

        '
        ' GET: /Area/Delete/5

        Function Delete(id As Guid) As ViewResult
            Dim area As Area = db.Areas.Single(Function(a) a.Id = id)
            Return View(area)
        End Function

        '
        ' POST: /Area/Delete/5

        <HttpPost()>
        <ActionName("Delete")>
        Function DeleteConfirmed(id As Guid) As RedirectToRouteResult
            Dim area As Area = db.Areas.Single(Function(a) a.Id = id)
            db.Areas.DeleteObject(area)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(disposing As Boolean)
            db.Dispose()
            MyBase.Dispose(disposing)
        End Sub

    End Class
End Namespace