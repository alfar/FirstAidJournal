<!DOCTYPE html>
<html>
<head>
    <title>@ViewData("Title")</title>
    <link href="@Url.Content("~/Content/Site.css")" rel="stylesheet" type="text/css" />
    <link href="@Url.Content("~/Content/themes/base/jquery.ui.base.css")" rel="stylesheet" type="text/css" />
    <link href="@Url.Content("~/Content/themes/base/jquery.ui.core.css")" rel="stylesheet" type="text/css" />
    <link href="@Url.Content("~/Content/themes/base/jquery.ui.theme.css")" rel="stylesheet" type="text/css" />
    <script src="@Url.Content("~/Scripts/jquery-1.5.1.min.js")" type="text/javascript"></script>
    <script src="@Url.Content("~/Scripts/jquery-ui-1.8.11.js")" type="text/javascript"></script>
</head>

<body>
    <div class="page">
        <div id="header">
            <div id="title">
                <h1>@Resources.FirstAidJournal.ApplicationTitle</h1>
            </div>
            <div id="logindisplay">
                @Html.Partial("_LogOn")
            </div>
            <div id="menucontainer">
                <ul id="menu">
                    <li>@Html.ActionLink(Resources.FirstAidJournal.MenuHome, "Home", "Activity")</li>
                    <li>@Html.ActionLink(Resources.FirstAidJournal.MenuEvent, "Index", "Event")</li>
                    <li>@Html.ActionLink(Resources.FirstAidJournal.MenuPerson, "Index", "Person")</li>
                @If Roles.IsUserInRole("Administrators") Then
                    @<li>@Html.ActionLink(Resources.FirstAidJournal.MenuArea, "Index", "Area")</li>
                    @<li>@Html.ActionLink(Resources.FirstAidJournal.MenuInjury, "Index", "Injury")</li>
                    @<li>@Html.ActionLink(Resources.FirstAidJournal.MenuTreatment, "Index", "Treatment")</li>
                    @<li>@Html.ActionLink(Resources.FirstAidJournal.MenuTreatmentCategory, "Index", "TreatmentCategory")</li>
                End If
                    <li>@Html.ActionLink(Resources.FirstAidJournal.MenuTeam, "Index", "Team")</li>
                    <li>@Html.ActionLink(Resources.FirstAidJournal.MenuActivity, "Index", "Activity")</li>
                </ul>
            </div>
        </div>
        <div id="main">
            @RenderBody()
            <br style="clear: both;" />
        </div>
        <div id="footer">
        </div>
    </div>
</body>
</html>
