addHandlesTo: aHaloMorph box: box
	aHaloMorph haloBox: box.
	Preferences haloSpecifications do:
		[:aSpec | 
			aHaloMorph perform: aSpec addHandleSelector with: aSpec].
	aHaloMorph innerTarget addOptionalHandlesTo: aHaloMorph box: box