Imports System.Data.Entity
Imports FirstAidJournal

Namespace FirstAidJournal
    <Authorize()>
    Public Class PersonController
        Inherits System.Web.Mvc.Controller

        Private db As FirstAidJournalEntities = New FirstAidJournalEntities

        '
        ' GET: /Person/

        Function Index() As ViewResult
            Dim activeTeam As Guid = DirectCast(HttpContext.Profile.GetPropertyValue("ActiveTeam"), Guid)
            Return View(From p In db.People Where p.TeamId = activeTeam)
        End Function

        '
        ' GET: /Person/Details/5

        Function Details(id As Guid) As ViewResult
            Dim activeTeam As Guid = DirectCast(HttpContext.Profile.GetPropertyValue("ActiveTeam"), Guid)
            Dim person As Person = db.People.Single(Function(p) p.Id = id AndAlso p.TeamId = activeTeam)
            Return View(person)
        End Function

        '
        ' GET: /Person/Create

        Function Create() As ViewResult
            Return View()
        End Function

        '
        ' POST: /Person/Create

        <HttpPost()>
        Function Create(person As Person, Optional helperId As Guid = Nothing) As ActionResult
            If ModelState.IsValid Then
                person.Id = Guid.NewGuid()
                Dim activeTeam As Guid = DirectCast(HttpContext.Profile.GetPropertyValue("ActiveTeam"), Guid)
                person.TeamId = activeTeam
                db.People.AddObject(person)
                db.SaveChanges()
                Return RedirectToAction("Create", "Event", New With {.PersonId = person.Id, .HelperId = helperId})
            End If

            Return View(person)
        End Function

        '
        ' GET: /Person/Edit/5

        Function Edit(id As Guid) As ViewResult
            Dim activeTeam As Guid = DirectCast(HttpContext.Profile.GetPropertyValue("ActiveTeam"), Guid)
            Dim person As Person = db.People.Single(Function(p) p.Id = id AndAlso p.TeamId = activeTeam)
            Return View(person)
        End Function

        '
        ' POST: /Person/Edit/5

        <HttpPost()>
        Function Edit(person As Person) As ActionResult
            If ModelState.IsValid Then
                db.People.Attach(person)
                db.ObjectStateManager.ChangeObjectState(person, EntityState.Modified)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If

            Return View(person)
        End Function

        '
        ' GET: /Person/Delete/5

        Function Delete(id As Guid) As ViewResult
            Dim activeTeam As Guid = DirectCast(HttpContext.Profile.GetPropertyValue("ActiveTeam"), Guid)
            Dim person As Person = db.People.Single(Function(p) p.Id = id AndAlso p.TeamId = activeTeam)
            Return View(person)
        End Function

        '
        ' POST: /Person/Delete/5

        <HttpPost()>
        <ActionName("Delete")>
        Function DeleteConfirmed(id As Guid) As RedirectToRouteResult
            Dim activeTeam As Guid = DirectCast(HttpContext.Profile.GetPropertyValue("ActiveTeam"), Guid)
            Dim person As Person = db.People.Single(Function(p) p.Id = id AndAlso p.TeamId = activeTeam)
            db.People.DeleteObject(person)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(disposing As Boolean)
            db.Dispose()
            MyBase.Dispose(disposing)
        End Sub

        Function AutoComplete(query As String, helperId As Guid?) As ActionResult
            ViewBag.HelperId = helperId
            Dim activeTeam As Guid = DirectCast(HttpContext.Profile.GetPropertyValue("ActiveTeam"), Guid)
            Response.Cache.SetCacheability(HttpCacheability.NoCache)
            Return PartialView(From p In db.People Where p.TeamId = activeTeam And p.Name.StartsWith(query))
        End Function
    End Class
End Namespace