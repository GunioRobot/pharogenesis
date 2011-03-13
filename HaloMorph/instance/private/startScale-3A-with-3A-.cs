startScale: evt with: scaleHandle
	"Initialize scaling of my target."

	target isFlexMorph ifFalse: [target addFlexShell].
	growingOrRotating _ true.
	self removeAllHandlesBut: scaleHandle.  "remove all other handles"
	positionOffset _ scaleHandle center - target bottomRight.
	target isAlignmentMorph
		ifTrue: [minExtent _ target minWidth@target minHeight]
		ifFalse: [minExtent _ 1@1].
