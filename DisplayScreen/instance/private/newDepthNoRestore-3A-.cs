newDepthNoRestore: pixelSize
	"Change depths.  Check if there is enough space!  , di"
	| area need |
	pixelSize = depth ifTrue: [^ self  "no change"].
	pixelSize abs < self depth ifFalse:
		["Make sure there is enough space"
		area _ Display boundingBox area. "pixels"
		Smalltalk isMorphic ifFalse:
			[ScheduledControllers scheduledWindowControllers do:
				[:aController | "This should be refined..."
				aController view cacheBitsAsTwoTone ifFalse:
					[area _ area + aController view windowBox area]]].
		need _ (area * (pixelSize abs - self depth) // 8)  "new bytes needed"
				+ Smalltalk lowSpaceThreshold.
		(Smalltalk garbageCollectMost <= need
			and: [Smalltalk garbageCollect <= need])
			ifTrue: [self error: 'Insufficient free space']].
	self setExtent: self extent depth: pixelSize.
	Smalltalk isMorphic ifFalse: [ScheduledControllers updateGray].
	DisplayScreen startUp