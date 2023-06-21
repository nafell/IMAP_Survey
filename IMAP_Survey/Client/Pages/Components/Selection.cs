namespace IMAP_Survey.Client.Pages.Components
{
    public class Selection
    {
        public int Code { get; set; }
        public string Text { get; set; }
    }

    public class SelectionGroup
    {
        public int SelectedValue { get; set; }
        public List<Selection> Selections { get; private set; }
        public SelectionGroup(string[] selections)
        {
            Selections = new List<Selection>();

            var count = 1;
            foreach (var selection in selections)
            {
                Selections.Add(new Selection { Code = count, Text = selection });
                count++;
            }
        }
    }
}
