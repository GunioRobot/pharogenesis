startGrow: evt with: growHandle
	"Initialize resizing of my target."

	growingOrRotating _ true.
	self removeAllHandlesBut: growHandle.  "remove all other handles"
	positionOffset _ growHandle center - target bottomRight.
	target isLayoutMorph
		ifTrue: [minExtent _ target minWidth@target minHeight]
		ifFalse: [minExtent _ 1@1].
