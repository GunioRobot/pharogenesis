packageWithName: aName
	"Look up a package by exact match on name. Return nil if missing."

	^self packages detect: [:package | package name = aName ] ifNone: [nil]