@ModelType FirstAidJournal.Event

@Code
    ViewData("Title") = Resources.FirstAidJournal.EventCreate
End Code

<h2>@Resources.FirstAidJournal.EventCreate</h2>

<script src="@Url.Content("~/Scripts/jquery.validate.min.js")" type="text/javascript"></script>
<script src="@Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js")" type="text/javascript"></script>

@Using Html.BeginForm()
    @Html.ValidationSummary(True)
    @<table width="100%">
        <tr>
            <td valign="top">
                <div class="editor-label">
                    @Resources.FirstAidJournal.Injury 
                </div>
                <div class="editor-field">
                    @Html.DropDownList("InjuryId", String.Empty)
                    @Html.ValidationMessageFor(Function(model) model.InjuryId)
                </div>

                <div class="editor-label">
                    @Resources.FirstAidJournal.Area 
                </div>
                <div class="editor-field">
                    @Html.EditorFor(Function(model) model.AreaId, "AreaSelector")
                    @Html.ValidationMessageFor(Function(model) model.AreaId)
                </div>
            </td>
            <td valign="top">
                <div class="editor-label">
                    @Resources.FirstAidJournal.Notes
                </div>
                <div class="editor-field">
                    @Html.TextAreaFor(Function(model) model.Notes, 10, 50, nothing)
                    @Html.ValidationMessageFor(Function(model) model.Notes)
                </div>

                @Html.HiddenFor(Function(model) model.HelperId)
                @Html.HiddenFor(Function(model) model.PersonId)
            </td>
         </tr>
    </table>
    @<div class="buttonbar">
        <input type="submit" value="@Resources.FirstAidJournal.CommandCreate" class="bigbutton" />
        @Html.ActionLink(Resources.FirstAidJournal.BackToList, "Index", Nothing, New With {.class = "bigbutton"})
    </div>
End Using
