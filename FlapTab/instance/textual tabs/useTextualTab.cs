useTextualTab
	| stringToUse colorToUse |
	self preserveDetails.
	colorToUse _ self valueOfProperty: #priorColor ifAbsent: [Color green muchLighter].
	submorphs notEmpty ifTrue: [self removeAllMorphs].
	stringToUse _ self valueOfProperty: #priorWording ifAbsent: ['Unnamed Flap' translated].
	self assumeString: stringToUse font:  Preferences standardFlapFont orientation: self orientation color: colorToUse