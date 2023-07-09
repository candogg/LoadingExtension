# LoadingExtension

This application is a sample of a loading control used in Windows Forms project.
When its called from a control (its an extension method), it shows up async until heavy load operation is done.
You don't need to create a panel and picturebox while in design mode. This extension will show up and dock's filled on called control.
It has a callback method to cancel async operation.
When the calling control is resized like maximize form, it will replace itself to be the center of the form again.
