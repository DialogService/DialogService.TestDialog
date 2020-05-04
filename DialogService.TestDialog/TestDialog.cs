using DialogService.Items;
using System;

namespace DialogService
{
    public class TestDialog
    {
        // Do not use this code as production example
        // This was made only to test dialogs in implementations

        public static Dialog GetDialog()
        {
            var items = new IDialogItem[] 
            {
                new Label("Default label"),
                new Button("Some button"),
                new Panel(new IDialogItem[] {new Button("Button 1"),new Button("Button 2")}) { Flow = ItemsFlow.LeftRight },
                new CheckBox() { Content = new Label("CheckBox 1") },
                new RadioBox() { Content = new Label("RadioBox 1") },
                new RadioBox() { Content = new Label("RadioBox 2") }
            };

            var dialog = new Dialog("Test Dialog", items);
            dialog.BottomPanel.Add(new Button("Fine"));
            dialog.BottomPanel.Add(new Button("Good"));

            return dialog;
        }

        public static string GetClosedBy(IDialogResult result)
        {
            string closedText = 
                result.ClosedBy != null 
                ? result.ClosedBy.GetType().Name
                : "unknown thing";

            if (result.ClosedBy != null)
            {
                if (result.ClosedBy is IContainerItem)
                {
                    var c = (IContainerItem)result.ClosedBy;

                    var contentText = c.Content != null ? c.Content.GetType().Name : "(null)";

                    if (c.Content is Label)
                    {
                        var label = c as Label;
                        contentText = "Label " + label.Content;
                    }

                    closedText += " with a content of type " + contentText;
                }
            }

            return closedText;
        }
    }
}
