removeUpdateItem: anItem
	"Add a new item to the scheduler's update list (a running animation, active script, etc)"

	updateList remove: anItem ifAbsent: [].
