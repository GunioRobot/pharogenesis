packageWithPI: aPIName
	"Look up a package by exact match on PackageInfo name. Return nil if missing."

	aPIName isEmptyOrNil ifTrue: [^nil].
	^self packages detect: [:package | package packageInfoName = aPIName ] ifNone: [nil]