removeChild: aChild
	"Remove an object from this instance's list of children"

	myChildren remove: aChild ifAbsent: [].
