openInWorld: aWorld extent: extent
	"This msg and its callees result in the window being activeOnlyOnTop"
	self position: (RealEstateAgent initialFrameFor: self) topLeft; extent: extent.
	aWorld addMorph: self.
	self activate.
	aWorld startSteppingSubmorphsOf: self.