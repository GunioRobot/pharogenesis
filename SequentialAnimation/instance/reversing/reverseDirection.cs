reverseDirection
	"Changes the direction an animation runs in (forward or in reverse)"

	super reverseDirection.

	children _ children reversed.
	childLoopCounts _ childLoopCounts reversed.


