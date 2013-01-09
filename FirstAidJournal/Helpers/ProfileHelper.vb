Public NotInheritable Class ProfileHelper
    Private Sub New()
    End Sub

    Public Shared Function GetActiveUserId() As Guid
        Dim mem As MembershipUser = Membership.GetUser()

        If mem IsNot Nothing Then
            Return DirectCast(mem.ProviderUserKey, Guid)
        End If

        Return Guid.Empty
    End Function

    Public Shared Function GetActiveActivity() As Guid
        Return GetGuid("ActiveActivity")
    End Function

    Public Shared Function GetActiveTeam() As Guid
        Return GetGuid("ActiveTeam")
    End Function

    Private Shared Function GetGuid(propertyName As String) As Guid
        Dim val As Object = HttpContext.Current.Profile.GetPropertyValue(propertyName)
        If val IsNot Nothing Then
            Return DirectCast(val, Guid)
        End If

        Return Guid.Empty
    End Function

End Class
