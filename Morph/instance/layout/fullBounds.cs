fullBounds
	"Return the bounding box of the receiver and all its children. Recompute the layout if necessary."
	fullBounds ifNotNil:[^fullBounds].
	self doLayoutIn: self layoutBounds.
	^fullBounds