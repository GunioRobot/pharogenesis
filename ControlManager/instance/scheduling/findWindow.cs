findWindow
	"Present a menu of window titles, and activate the one that gets chosen."

	^ self findWindowSatisfying: [:c | true]