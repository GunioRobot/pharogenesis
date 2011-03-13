newDepthNoRestore: pixelSize
	"Change depths.  Check if there is enough space!  , di"
	| area need |
	pixelSize = depth ifTrue: [^ self  "no change"].
	pixelSize < depth ifFalse:
		["Make sure there is enough space"
		area _ Display boundingBox area. "pixels"
		Smalltalk isMorphic
		ifTrue:
			[area _ area + area "World canvas bitmap still separate"]
		ifFalse:
			[ScheduledControllers scheduledWindowControllers do:
				[:aController | aController view cacheBitsAsTwoTone ifFalse:
					[area _ area + aController view windowBox area]]].
		need _ (area * pixelSize // 8) - (area * depth // 8)  "new bytes needed"
				+ 80000.  "lowSpaceThreshold (should be shared)"
		(Smalltalk garbageCollectMost <= need
			and: [Smalltalk garbageCollect <= need])
			ifTrue: [self halt: 'Insufficient free space']].
	self depth: pixelSize.  
	self setExtent: self extent.
	ScheduledControllers updateGray.
	DisplayScreen startUp