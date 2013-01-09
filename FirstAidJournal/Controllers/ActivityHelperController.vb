Namespace FirstAidJournal
    Public Class ActivityHelperController
        Inherits System.Web.Mvc.Controller

        Private db As FirstAidJournalEntities = New FirstAidJournalEntities

        '
        ' GET: /ActivityHelper

        Function Delete(id As Guid) As ActionResult
            Dim ah As ActivityHelper = db.ActivityHelper.Single(Function(ahe) ahe.Id = id)

            If ah IsNot Nothing Then
                Dim activityId As Guid = ah.ActivityId
                db.DeleteObject(ah)
                db.SaveChanges()
                Return RedirectToAction("Details", "Activity", New With {.Id = activityId})
            End If

            Return RedirectToAction("Home", "Activity")
        End Function

    End Class
End Namespace
