state: newState
	"Change the image and invalidate the rect."

	newState == state ifTrue: [^ self].
	state _ newState.
	self invalidRect: bounds.	"All three images must be the same size"