reverseDirection
	"Changes the direction an animation runs in (forward or in reverse)"

	super reverseDirection.

	children do: [:child | child reverseDirection ].
