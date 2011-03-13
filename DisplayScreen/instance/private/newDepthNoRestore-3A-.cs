newDepthNoRestore: pixelSize 
	"Change depths. Check if there is enough space! , di"
	| area need |
	pixelSize = depth
		ifTrue: [^ self"no change"].
	pixelSize abs < self depth
		ifFalse: ["Make sure there is enough space"
			area := Display boundingBox area.
			"pixels"
			need := area * (pixelSize abs - self depth) // 8 + Smalltalk lowSpaceThreshold.
			"new bytes needed"
			(Smalltalk garbageCollectMost <= need
					and: [Smalltalk garbageCollect <= need])
				ifTrue: [self error: 'Insufficient free space']].
	self setExtent: self extent depth: pixelSize.
	DisplayScreen startUp