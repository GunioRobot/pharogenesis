aReadThis
	"When a list pane in a complex window has fairly simple action, you can use an instance of GeneralListController directly.  You don't need to make a separate class for your kind of list pane.
	The model makes and holds the YellowButtonMenu and the YellowButtonMessages and submits them to this instance using yellowButtonMenu: aSystemMenu yellowButtonMessages: anArray.  Having specialized menus is the usual reason for a new subclass for each pane.
	When the user clicks on a list item, redButtonActivity sends changeModelSelection: which sends toggleListIndex: to the model.
	"