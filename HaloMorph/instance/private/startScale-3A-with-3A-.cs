startScale: evt with: scaleHandle
	"Initialize scaling of my target."
	evt hand obtainHalo: self.
	target isFlexMorph ifFalse: [target addFlexShell].
	growingOrRotating _ true.
	self removeAllHandlesBut: scaleHandle.  "remove all other handles"
	positionOffset _ 0@0.
