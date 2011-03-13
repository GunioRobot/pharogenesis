openInWorld: aWorld
	"This msg and its callees result in the window being activeOnlyOnTop"
	self bounds: (RealEstateAgent initialFrameFor: self world: aWorld).
	aWorld addMorph: self.
	self activate.
	aWorld startSteppingSubmorphsOf: self.
