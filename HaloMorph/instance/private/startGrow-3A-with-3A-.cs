startGrow: evt with: growHandle
	| botRt |
	"Initialize resizing of my target."

	growingOrRotating _ true.
	self removeAllHandlesBut: growHandle.  "remove all other handles"
	botRt _ target pointInWorld: target bottomRight.
	(self world viewBox containsPoint: botRt)
		ifTrue: [positionOffset _ evt cursorPoint - botRt]
		ifFalse: [positionOffset _ 0@0].
	target isAlignmentMorph
		ifTrue: [minExtent _ target minWidth@target minHeight]
		ifFalse: [minExtent _ 1@1].
