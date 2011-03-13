truncateTo: grid
	"Answer a Point that is the receiver's x and y truncated to grid x and 
	grid y."
	| gridPoint |
	gridPoint _ grid asPoint.
	^(x truncateTo: gridPoint x) @ (y truncateTo: gridPoint y)