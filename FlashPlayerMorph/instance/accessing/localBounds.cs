localBounds
	^localBounds ifNil:[localBounds := self transform globalBoundsToLocal: self bounds]