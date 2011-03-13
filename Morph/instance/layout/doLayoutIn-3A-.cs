doLayoutIn: layoutBounds
	"Compute a new layout based on the given layout bounds."
	| layout box priorBounds |
	"Note: Testing for #bounds or #layoutBounds would be sufficient to
	figure out if we need an invalidation afterwards but #outerBounds
	is what we need for all leaf nodes so we use that."
	priorBounds _ self outerBounds.
	submorphs size = 0 ifTrue:[^fullBounds _ priorBounds].
	"Send #ownerChanged to our children"
	submorphs do:[:m| m ownerChanged].
	layout _ self layoutPolicy.
	layout ifNotNil:[layout layout: self in: layoutBounds].
	self adjustLayoutBounds.
	fullBounds _ self privateFullBounds.
	box _ self outerBounds.
	box = priorBounds
		ifFalse:[self invalidRect: (priorBounds quickMerge: box)].