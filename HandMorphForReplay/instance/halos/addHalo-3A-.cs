addHalo: evt
	| halo |
	argument isNil
		ifTrue: 
			[halo _ HaloMorph new bounds: self worldBoundsForHalo.
			self world addMorphFront: halo.
			halo target: self.
			halo startStepping]
		ifFalse: [argument addHalo: evt]