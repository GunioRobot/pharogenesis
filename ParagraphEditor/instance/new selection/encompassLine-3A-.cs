encompassLine: anInterval
	"Return an interval that encompasses the entire line"
	| string left right |
	string := paragraph text string.
	left := (string lastIndexOf: Character cr startingAt: anInterval first - 1 ifAbsent:[0]) + 1.
	right := (string indexOf: Character cr startingAt: anInterval last + 1 ifAbsent: [string size + 1]) - 1.
	^left to: right