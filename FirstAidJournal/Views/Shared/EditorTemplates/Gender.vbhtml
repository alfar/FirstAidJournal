﻿@Html.RadioButtonFor(Function(m) m, 1, If(Model <> 2, New With {.id = "Gender_1", .checked = "checked"}, New With {.id = "Gender_1"})) <label for="Gender_1"><img src="/Content/Male.png" height="32" width="32" alt="@Resources.FirstAidJournal.Male" title="@Resources.FirstAidJournal.Male" align="absmiddle" /></label>
@Html.RadioButtonFor(Function(m) m, 2, If(Model = 2, New With {.id = "Gender_2", .checked = "checked"}, New With {.id = "Gender_2"})) <label for="Gender_2"><img src="/Content/Female.png" height="32" width="32" alt="@Resources.FirstAidJournal.Female" title="@Resources.FirstAidJournal.Female" align="absmiddle" /></label>
