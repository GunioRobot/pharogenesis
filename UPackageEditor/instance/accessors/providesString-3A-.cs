providesString: aString 
	package provides: (self packageNamesFromString: aString).
	self changed: #providesString