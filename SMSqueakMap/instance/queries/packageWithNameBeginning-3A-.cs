packageWithNameBeginning: aString
	"Look up a package beginning with <aString>. Return nil if missing.
	We return the shortest matching one. We also strip out spaces and
	ignore case in both <aString> and the names."

	| candidates shortest answer searchString |
	searchString := (aString asLowercase) copyWithout: Character space.
	candidates := self packages select: [:package |
		((package name asLowercase) copyWithout: Character space)
			beginsWith: searchString ].
	shortest := 1000.
	candidates do: [:package |
		package name size < shortest ifTrue:[answer := package. shortest := package name size]].
	^answer	