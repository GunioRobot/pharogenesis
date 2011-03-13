matchesVersionReference: aVersionReference
	^ (super matchesVersionReference: aVersionReference) and: [ constraintBlock value: aVersionReference ]