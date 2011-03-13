restore
	Smalltalk isMorphic
		ifTrue: [self repaintMorphicDisplay]
		ifFalse: [ScheduledControllers unCacheWindows; restore].