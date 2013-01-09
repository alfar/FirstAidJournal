Imports System.Data.Entity
Imports FirstAidJournal

Namespace FirstAidJournal
    <Authorize(Roles:="Administrators")>
    Public Class TreatmentCategoryController
        Inherits System.Web.Mvc.Controller

        Private db As FirstAidJournalEntities = New FirstAidJournalEntities

        '
        ' GET: /TreatmentCategory/

        Function Index() As ViewResult
            Return View(db.TreatmentCategories.OrderBy(Function(tg) tg.Name).ToList())
        End Function

        '
        ' GET: /TreatmentCategory/Details/5

        Function Details(id As Guid) As ViewResult
            Dim treatmentcategory As TreatmentCategory = db.TreatmentCategories.Single(Function(t) t.Id = id)
            Return View(treatmentcategory)
        End Function

        '
        ' GET: /TreatmentCategory/Create

        Function Create() As ViewResult
            Return View()
        End Function

        '
        ' POST: /TreatmentCategory/Create

        <HttpPost()>
        Function Create(treatmentcategory As TreatmentCategory) As ActionResult
            If ModelState.IsValid Then
                treatmentcategory.Id = Guid.NewGuid()
                db.TreatmentCategories.AddObject(treatmentcategory)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If

            Return View(treatmentcategory)
        End Function

        '
        ' GET: /TreatmentCategory/Edit/5

        Function Edit(id As Guid) As ViewResult
            Dim treatmentcategory As TreatmentCategory = db.TreatmentCategories.Single(Function(t) t.Id = id)
            Return View(treatmentcategory)
        End Function

        '
        ' POST: /TreatmentCategory/Edit/5

        <HttpPost()>
        Function Edit(treatmentcategory As TreatmentCategory) As ActionResult
            If ModelState.IsValid Then
                db.TreatmentCategories.Attach(treatmentcategory)
                db.ObjectStateManager.ChangeObjectState(treatmentcategory, EntityState.Modified)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If

            Return View(treatmentcategory)
        End Function

        '
        ' GET: /TreatmentCategory/Delete/5

        Function Delete(id As Guid) As ViewResult
            Dim treatmentcategory As TreatmentCategory = db.TreatmentCategories.Single(Function(t) t.Id = id)
            Return View(treatmentcategory)
        End Function

        '
        ' POST: /TreatmentCategory/Delete/5

        <HttpPost()>
        <ActionName("Delete")>
        Function DeleteConfirmed(id As Guid) As RedirectToRouteResult
            Dim treatmentcategory As TreatmentCategory = db.TreatmentCategories.Single(Function(t) t.Id = id)
            db.TreatmentCategories.DeleteObject(treatmentcategory)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(disposing As Boolean)
            db.Dispose()
            MyBase.Dispose(disposing)
        End Sub

    End Class
End Namespace