acceptDroppingMorph: aMorph event: evt
	"Add the given morph to this world and make sure it is getting stepped if it wants to be."
	self addMorphFront: aMorph.
	(aMorph fullBounds intersects: (0@0 extent: self viewBox extent)) ifFalse:
		[self beep.  aMorph position: self bounds center].
	self startSteppingSubmorphsOf: aMorph.
