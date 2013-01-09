Imports System.Data.Entity
Imports FirstAidJournal

Namespace FirstAidJournal
    <Authorize(Roles:="Administrators")>
    Public Class TreatmentController
        Inherits System.Web.Mvc.Controller

        Private db As FirstAidJournalEntities = New FirstAidJournalEntities

        '
        ' GET: /Treatment/

        Function Index() As ViewResult
            Dim treatments = db.Treatments.Include("TreatmentCategory").OrderBy(Function(t) t.TreatmentCategory.Name).ThenBy(Function(t) t.Name)
            Return View(treatments.ToList())
        End Function

        '
        ' GET: /Treatment/Details/5

        Function Details(id As Guid) As ViewResult
            Dim treatment As Treatment = db.Treatments.Single(Function(t) t.Id = id)
            Return View(treatment)
        End Function

        '
        ' GET: /Treatment/Create

        Function Create() As ViewResult
            ViewBag.TreatmentCategoryId = New SelectList(db.TreatmentCategories, "Id", "Name")
            Return View()
        End Function

        '
        ' POST: /Treatment/Create

        <HttpPost()>
        Function Create(treatment As Treatment) As ActionResult
            If ModelState.IsValid Then
                treatment.Id = Guid.NewGuid()
                db.Treatments.AddObject(treatment)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If

            ViewBag.TreatmentCategoryId = New SelectList(db.TreatmentCategories, "Id", "Name", treatment.TreatmentCategoryId)
            Return View(treatment)
        End Function

        '
        ' GET: /Treatment/Edit/5

        Function Edit(id As Guid) As ViewResult
            Dim treatment As Treatment = db.Treatments.Single(Function(t) t.Id = id)
            ViewBag.TreatmentCategoryId = New SelectList(db.TreatmentCategories, "Id", "Name", treatment.TreatmentCategoryId)
            Return View(treatment)
        End Function

        '
        ' POST: /Treatment/Edit/5

        <HttpPost()>
        Function Edit(treatment As Treatment) As ActionResult
            If ModelState.IsValid Then
                db.Treatments.Attach(treatment)
                db.ObjectStateManager.ChangeObjectState(treatment, EntityState.Modified)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If

            ViewBag.TreatmentCategoryId = New SelectList(db.TreatmentCategories, "Id", "Name", treatment.TreatmentCategoryId)
            Return View(treatment)
        End Function

        '
        ' GET: /Treatment/Delete/5

        Function Delete(id As Guid) As ViewResult
            Dim treatment As Treatment = db.Treatments.Single(Function(t) t.Id = id)
            Return View(treatment)
        End Function

        '
        ' POST: /Treatment/Delete/5

        <HttpPost()>
        <ActionName("Delete")>
        Function DeleteConfirmed(id As Guid) As RedirectToRouteResult
            Dim treatment As Treatment = db.Treatments.Single(Function(t) t.Id = id)
            db.Treatments.DeleteObject(treatment)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(disposing As Boolean)
            db.Dispose()
            MyBase.Dispose(disposing)
        End Sub

        Function Statistics() As ViewResult
            ViewBag.ActiveTeam = DirectCast(HttpContext.Profile.GetPropertyValue("ActiveTeam"), Guid)
            Dim treatments = db.Treatments.Include("TreatmentCategory").OrderBy(Function(t) t.TreatmentCategory.Name).ThenBy(Function(t) t.Name) ' .Where(Function(t) t.EventTreatments.Any)
            Return View(treatments.ToList())
        End Function
    End Class
End Namespace