startScale: evt with: scaleHandle
	"Initialize scaling of my target."

	self obtainHaloForEvent: evt andRemoveAllHandlesBut: scaleHandle.
	target isFlexMorph ifFalse: [target addFlexShellIfNecessary].
	growingOrRotating _ true.
	positionOffset _ 0@0
