startScale: evt with: scaleHandle
	"Initialize scaling of my target."

	target isFlexMorph ifFalse: [target addFlexShell].
	growingOrRotating _ true.
	self removeAllHandlesBut: scaleHandle.  "remove all other handles"
	positionOffset _ 0@0.
	target isAlignmentMorph
		ifTrue: [minExtent _ target minWidth@target minHeight]
		ifFalse: [minExtent _ 3@3].
