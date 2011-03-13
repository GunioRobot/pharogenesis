newDepth: pixelSize
"
	Display newDepth: 8.
	Display newDepth: 1.
"
	self newDepthNoRestore: pixelSize.
	Smalltalk isMorphic
		ifTrue: [World fullRepaintNeeded]
		ifFalse: [ScheduledControllers unCacheWindows; restore].