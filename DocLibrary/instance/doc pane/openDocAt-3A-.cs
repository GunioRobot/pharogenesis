openDocAt: classAndMethod

	| docPane |
	(docPane _ self docObjectAt: classAndMethod) ifNotNil: [
		docPane setProperty: #initialExtent toValue: docPane bounds extent.
		docPane topLeft: (RealEstateAgent initialFrameFor: docPane) origin.
		Smalltalk currentWorld addMorph: docPane].
	^ docPane