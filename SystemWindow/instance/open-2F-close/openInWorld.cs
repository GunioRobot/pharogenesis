openInWorld
	"This msg and its callees result in the window being activeOnlyOnTop"
	Smalltalk isMorphic ifFalse: [^ self openInMVC].
	self bounds: (RealEstateAgent initialFrameFor: self).
	World addMorph: self.
	self activate