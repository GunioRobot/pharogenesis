categoryWithNameBeginning: aString
	"Look up a category beginning with <aString>. Return nil if missing.
	We return the shortest matching one. We also strip out spaces and
	ignore case in both <aString> and the names."

	| candidates shortest answer searchString |
	searchString := (aString asLowercase) copyWithout: Character space.
	candidates := self categories select: [:cat |
		((cat name asLowercase) copyWithout: Character space)
			beginsWith: searchString ].
	shortest := 1000.
	candidates do: [:ca |
		ca name size < shortest ifTrue:[answer := ca. shortest := ca name size]].
	^answer	