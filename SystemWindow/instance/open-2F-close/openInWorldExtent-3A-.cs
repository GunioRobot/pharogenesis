openInWorldExtent: extent
	"This msg and its callees result in the window being activeOnlyOnTop"
	Smalltalk isMorphic ifFalse: [^ self openInMVCExtent: extent].
	self position: (RealEstateAgent initialFrameFor: self) topLeft; extent: extent.
	World addMorph: self.
	self activate