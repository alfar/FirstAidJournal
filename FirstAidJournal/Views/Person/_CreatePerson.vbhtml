@ModelType FirstAidJournal.Person

<script src="@Url.Content("~/Scripts/jquery.validate.min.js")" type="text/javascript"></script>
<script src="@Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js")" type="text/javascript"></script>

@Using Html.BeginForm("Create", "Person")
    @Html.ValidationSummary(True)
    @<table width="100%">
        <tr>
            <td valign="top" width="50%">
                <div class="editor-label">
                    @Resources.FirstAidJournal.Name
                </div>
                <div class="editor-field">
                    @Html.EditorFor(Function(model) model.Name)
                    @Html.ValidationMessageFor(Function(model) model.Name)
                </div>

                <div class="editor-label">
                    @Resources.FirstAidJournal.Gender
                </div>
                <div class="editor-field">
                    @Html.EditorFor(Function(model) model.Gender, "Gender")
                    @Html.ValidationMessageFor(Function(model) model.Gender)
                </div>

                <div class="editor-label">
                    @Resources.FirstAidJournal.Age
                </div>
                <div class="editor-field">
                    @Html.EditorFor(Function(model) model.Age, "Age")
                    @Html.ValidationMessageFor(Function(model) model.Age)
                </div>

                @Html.Hidden("helperId", ViewBag.HelperId)
                <div class="buttonbar">
                    <input type="submit" value="@Resources.FirstAidJournal.CommandCreate" class="bigbutton" />
                </div>
            </td>
            <td valign="top" width="50%">
                <div id="PeopleList"></div>
            </td>
        </tr>
    </table>
    @<script type="text/javascript">
         var search_timeout = undefined;

         $(document).ready(function () {
             $('#Name').select().focus();
             $('#Name').bind('keyup', function () {
                 var query = $(this).val();

                 if (search_timeout != undefined) {
                     clearTimeout(search_timeout);
                 }

                 if (query == '') {
                     $('#PeopleList').html('');
                 }
                 else {
                     search_timeout = setTimeout(function () {
                         search_timeout = undefined;
                         $.ajax({
                             method: 'POST',
                             url: '/Person/AutoComplete',
                             data: { 'query': query, 'helperId': '@ViewBag.HelperId' },
                             success: function (data) {
                                 $('#PeopleList').html(data);
                             }
                         });
                     }, 500);
                 }
             });
         });
    </script>
End Using
