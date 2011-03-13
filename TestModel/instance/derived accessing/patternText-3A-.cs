patternText: aTextOrString

	| patternInput |
	patternInput := aTextOrString asString.
	self
		classPattern: (self classPatternFrom: patternInput);
		selectorPattern: (self selectorPatternFrom: patternInput);
		updatePatternHistory;
		changed: #patternText.
	^true