append: child
	"Adds a child animation to the composite animation."

	child stop.
	children addLast: child.
	childLoopCounts addLast: (child getLoopCount).


