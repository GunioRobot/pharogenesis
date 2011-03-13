embedInto: evt 
	"Embed the receiver into some other morph"
	| target |
	target := UIManager default
				chooseFrom: (self potentialEmbeddingTargets
						collect: [:t | t knownName
								ifNil: [t class name asString]])
				values: self potentialEmbeddingTargets
				title: 'Place ' translated, self externalName , ' in...' translated.
	target
		ifNil: [^ self].
	target addMorphFront: self fromWorldPosition: self positionInWorld