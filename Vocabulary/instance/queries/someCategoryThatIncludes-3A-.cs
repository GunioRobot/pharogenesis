someCategoryThatIncludes: aSelector
	"Answer the name of a category that includes the selector, nil if none"

	^ categories detect: [:c | c includesKey: aSelector] ifNone: [nil]