isAbstract
	| marker |
	marker _ self markerOrNil.
	^ marker notNil and: [self class abstractMarkers includes: marker].