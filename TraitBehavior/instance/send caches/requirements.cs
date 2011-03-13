requirements
	^ self requiredSelectorsCache 
		ifNil: [#()] 
		ifNotNilDo: [:rsc | rsc requirements]