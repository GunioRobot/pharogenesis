encompassLine: anInterval
	"Return an interval that encompasses the entire line"
	| string left right |
	string _ paragraph text string.
	left _ (string lastIndexOf: Character cr startingAt: anInterval first - 1 ifAbsent:[0]) + 1.
	right _ (string indexOf: Character cr startingAt: anInterval last + 1 ifAbsent: [string size + 1]) - 1.
	^left to: right