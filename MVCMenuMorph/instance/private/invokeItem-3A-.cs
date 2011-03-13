invokeItem: aMenuItem
	"Called by the MenuItemMorph that the user selects. Record the selection and set the done flag to end this interaction."

	selectedItem _ aMenuItem selector.
	done _ true.
