variable

	| varName varStart varEnd |
	varStart _ self startOfNextToken + requestorOffset.
	varName _ self advance.
	varEnd _ self endOfLastToken + requestorOffset.
	^ encoder encodeVariable: varName
		sourceRange: (varStart to: varEnd)
		ifUnknown: [self correctVariable: varName interval: (varStart to: varEnd)]