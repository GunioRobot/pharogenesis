trulyFlashIndicator: aSymbol

	| indicator firstColor |

	indicator _ fields at: aSymbol ifAbsent: [^self].
	firstColor _ indicator 
		valueOfProperty: #firstColor
		ifAbsent: [
			indicator setProperty: #firstColor toValue: indicator color.
			indicator color
		].
	indicator color: (indicator color = firstColor ifTrue: [Color white] ifFalse: [firstColor]).
	self world displayWorldSafely.
