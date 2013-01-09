@ModelType FirstAidJournal.LogOnModel

@Code
    ViewData("Title") = Resources.FirstAidJournal.AccountLogOn
End Code

<h2>@Resources.FirstAidJournal.AccountLogon</h2>
<p>
    @Resources.FirstAidJournal.PleaseEnterUsernameAndPassword @Html.Raw(String.Format(Resources.FirstAidJournal.IfYouDontHaveLogin,Html.ActionLink(Resources.FirstAidJournal.Register, "Register")))
</p>

<script src="@Url.Content("~/Scripts/jquery.validate.min.js")" type="text/javascript"></script>
<script src="@Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js")" type="text/javascript"></script>

@Html.ValidationSummary(True, Resources.FirstAidJournal.LoginUnsuccessful)

@Using Html.BeginForm()
    @<div>
        <div class="editor-label">
            @Html.LabelFor(Function(m) m.UserName)
        </div>
        <div class="editor-field">
            @Html.TextBoxFor(Function(m) m.UserName)
            @Html.ValidationMessageFor(Function(m) m.UserName)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(m) m.Password)
        </div>
        <div class="editor-field">
            @Html.PasswordFor(Function(m) m.Password)
            @Html.ValidationMessageFor(Function(m) m.Password)
        </div>

        <div class="editor-label">
            @Html.CheckBoxFor(Function(m) m.RememberMe)
            @Html.LabelFor(Function(m) m.RememberMe)
        </div>

        <p>
            <input type="submit" value="@Resources.FirstAidJournal.AccountLogOn" class="bigbutton" />
        </p>
    </div>
End Using
