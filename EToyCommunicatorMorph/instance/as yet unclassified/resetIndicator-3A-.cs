resetIndicator: aSymbol

	| indicator firstColor |
	indicator _ fields at: aSymbol ifAbsent: [^self].
	firstColor _ indicator 
		valueOfProperty: #firstColor
		ifAbsent: [^self].
	indicator color: firstColor.
	self world displayWorldSafely.
