deselectAll 
	"Deselect all items in the list pane, and clear the code pane"

	listIndex _ 0.
	listSelections atAllPut: false.
	self changed: #allSelections.
	self contentsChanged