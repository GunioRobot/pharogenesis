syntaxErrorFor: aString withComponent: anApplescriptInstance

	|range |
	range _ anApplescriptInstance lastErrorCodeRange.
	self open:
		(super new 
			code: aString 
			errorMessage: anApplescriptInstance lastErrorString
			from: range first
			to: range last)