restore
	Smalltalk isMorphic
		ifTrue: [World fullRepaintNeeded]
		ifFalse: [ScheduledControllers unCacheWindows; restore].