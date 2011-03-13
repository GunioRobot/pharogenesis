fullBounds
	| subBounds |
	fullBounds ifNil:[
		fullBounds := self bounds.
		submorphs do:[:m|
			subBounds := (self transform localBoundsToGlobal: m fullBounds).
			fullBounds := fullBounds quickMerge: subBounds.
		].
	].
	^fullBounds