hasProperty: propName
	"Answer whether the receiver has the given property.  Deemed to have it only if I have a property dictionary entry for it and that entry is neither nil nor false"
	| prop |
	^ properties ~~ nil and:
		[((prop _ properties at: propName ifAbsent: [nil]) ~~ false) and:
			[prop ~~ nil]]