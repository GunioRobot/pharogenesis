selectMVCItem: item
	"Called by the MenuItemMorph that the user selects.
	Record the selection and set the done flag to end this interaction."

	mvcSelection _ item.
	done _ true.
