addUpdateItem: newItem
	"Add a new item to the scheduler's update list (a running animation, active script, etc"

	updateList addLast: newItem.
